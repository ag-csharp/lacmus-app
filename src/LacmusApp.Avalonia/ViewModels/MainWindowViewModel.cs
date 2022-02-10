﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using System.Reactive;
using System.Reactive.Linq;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Avalonia.Controls;
using Avalonia.Threading;
using DynamicData;
using DynamicData.Binding;
using MessageBox.Avalonia;
using MessageBox.Avalonia.DTO;
using MessageBox.Avalonia.Enums;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using LacmusApp.Avalonia.Extensions;
using LacmusApp.Avalonia.Managers;
using LacmusApp.Avalonia.Models;
using LacmusApp.Avalonia.Models.Photo;
using LacmusApp.Avalonia.Services;
using LacmusApp.Avalonia.Services.IO;
using LacmusApp.Avalonia.Services.Plugin;
using LacmusApp.Avalonia.Services.VM;
using LacmusApp.Avalonia.Views;
using LacmusApp.Screens.ViewModels;
using Octokit;
using Serilog;
using Splat;
using Language = LacmusApp.Appearance.Enums.Language;
using Attribute = LacmusApp.Avalonia.Models.Photo.Attribute;
using Object = LacmusApp.Avalonia.Models.Object;

namespace LacmusApp.Avalonia.ViewModels
{
    public class MainWindowViewModel : ReactiveObject
    {
        private readonly ApplicationStatusManager _applicationStatusManager;
        private readonly Window _window;
        private ThemeManager _themeManager;
        private SettingsViewModel _settingsViewModel;
        
        private int itemPerPage = 500;
        private int itemcount;
        private int _totalPages;
        SourceList<PhotoViewModel> _photos { get; set; } = new SourceList<PhotoViewModel>();
        private ReadOnlyObservableCollection<PhotoViewModel> _photoCollection;
        
        public MainWindowViewModel(Window window, SettingsViewModel settingsViewModel, ThemeManager themeManager)
        {
            _window = window;
            _themeManager = themeManager;
            _settingsViewModel = settingsViewModel;


            var pageFilter = this
                .WhenValueChanged(x => x.CurrentPage)
                .Select(PageFilter);
            var typeFilter = this
                .WhenValueChanged(x => x.FilterIndex)
                .Select(TypeFilter);
            
            _photos.Connect()
                .Filter(pageFilter)
                .Filter(typeFilter)
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out _photoCollection)
                .DisposeMany()
                .Subscribe();
            
            _applicationStatusManager = new ApplicationStatusManager();
            ApplicationStatusViewModel = new ApplicationStatusViewModel(_applicationStatusManager);
            
            var canGoNext = this
                .WhenAnyValue(x => x.SelectedIndex)
                .Select(index => index < _photos.Count - 1);

            // The bound button will stay disabled, when
            // there is no more frames left.
            NextImageCommand = ReactiveCommand.Create(
                () => { SelectedIndex++; },
                canGoNext);

            var canGoBack = this
                .WhenAnyValue(x => x.SelectedIndex)
                .Select(index => index > 0);

            // The bound button will stay disabled, when
            // there are no frames before the current one.
            PrevImageCommand = ReactiveCommand.Create(
                () => { SelectedIndex--; },
                canGoBack);
            
            var canSwitchBoundBox = this
                .WhenAnyValue(x => x.PhotoViewModel.Photo)
                .Select(count => PhotoViewModel.Photo?.Attribute == Attribute.WithObject);
            
            // Update UI when the index changes
            // TODO: Make photo update without index
            this.WhenAnyValue(x => x.SelectedIndex)
                .Skip(1)
                .Subscribe(async x =>
                {
                    await UpdateUi();
                });

            // Add here newer commands
            SetupCommand(CanSetup(), canSwitchBoundBox);

            LocalizationContext = new LocalizationContext();
            
            // load settings from config
            LocalizationContext.Language = _settingsViewModel.Language;

            Task.Run(CheckUpdate);

            Log.Information("Application started.");
        }

        private void SetupCommand(IObservable<bool> canExecute, IObservable<bool> canSwitchBoundBox)
        {
            IncreaseCanvasCommand = ReactiveCommand.Create(IncreaseCanvas);
            ShrinkCanvasCommand = ReactiveCommand.Create(ShrinkCanvas);
            ResetCanvasCommand = ReactiveCommand.Create(ResetCanvas);
            PredictAllCommand = ReactiveCommand.Create(PredictAll, canExecute);
            OpenFileCommand = ReactiveCommand.Create(OpenFile, canExecute);
            SaveAllCommand = ReactiveCommand.Create(SaveAll, canExecute);
            OpenModelManagerCommand = ReactiveCommand.Create(OpenModelManager, canExecute);
            OpenBugReportCommand = ReactiveCommand.Create(OpenBugReport, canExecute);
            
            NextPageCommand = ReactiveCommand.Create(ShowNextPage);
            PreviousPageCommand = ReactiveCommand.Create(ShowPreviousPage);
            FirstPageCommand = ReactiveCommand.Create(ShowFirstPage);
            LastPageCommand = ReactiveCommand.Create(ShowLastPage);
            
            ImportAllCommand = ReactiveCommand.Create(ImportFromXml, canExecute);
            SaveAsCommand = ReactiveCommand.Create(SaveAs, canExecute);
            ShowGeoDataCommand = ReactiveCommand.Create(ShowGeoData, canExecute);
            AddToFavoritesCommand = ReactiveCommand.Create(AddToFavorites, canExecute);
            HelpCommand = ReactiveCommand.Create(Help);
            AboutCommand = ReactiveCommand.Create(About);
            CheckUpdateCommand = ReactiveCommand.Create(CheckUpdate);
            OpenWizardCommand = ReactiveCommand.Create(OpenWizard);
            ExitCommand = ReactiveCommand.Create(Exit);
            OpenSettingsWindowCommand = ReactiveCommand.Create(OpenSettingsWindowAsync, canExecute);
        }

        private IObservable<bool> CanSetup()
        {
            return _applicationStatusManager.AppStatusInfoObservable
                .Select(status => status.Status != Enums.Status.Working && status.Status != Enums.Status.Unauthenticated);
        }

        #region Public API
        public ReadOnlyObservableCollection<PhotoViewModel> PhotoCollection => _photoCollection;
        [Reactive] public int SelectedIndex { get; set; }
        [Reactive] public int CurrentPage { get; set; } = 0;
        [Reactive] public int FilterIndex { get; set; } = 0;
        [Reactive] public PhotoViewModel PhotoViewModel { get; set; }
        [Reactive] public ApplicationStatusViewModel ApplicationStatusViewModel { get; set; }
        [Reactive] public int TotalPages
        {
            get => _totalPages;
            set => _totalPages = value;
        }
        // TODO: update with locales
        [Reactive] public string FavoritesStateString { get; set; } = "Add to favorites";
        [Reactive] public double CanvasWidth { get; set; } = 500;
        [Reactive] public double CanvasHeight { get; set; } = 500;
        [Reactive] public LocalizationContext LocalizationContext {get; set;}

        public ReactiveCommand<Unit, Unit> PredictAllCommand { get; set; }
        public ReactiveCommand<Unit, Unit> NextImageCommand { get; }
        public ReactiveCommand<Unit, Unit> PrevImageCommand { get; }
        public ReactiveCommand<Unit, Unit> ShrinkCanvasCommand { get; set; }
        public ReactiveCommand<Unit, Unit> IncreaseCanvasCommand { get; set; }
        public ReactiveCommand<Unit, Unit> ResetCanvasCommand { get; set; }
        public ReactiveCommand<Unit, Unit> OpenFileCommand { get; set; }
        public ReactiveCommand<Unit, Unit> SaveAllCommand { get; set; }
        public ReactiveCommand<Unit, Unit> ImportAllCommand { get; set; }
        public ReactiveCommand<Unit, Unit> OpenModelManagerCommand { get; set; }
        public ReactiveCommand<Unit, Unit> OpenBugReportCommand { get; set; }
        public ReactiveCommand<Unit, Unit> SaveAsCommand { get; set; }
        public ReactiveCommand<Unit, Unit> FirstPageCommand { get; set; }
        public ReactiveCommand<Unit, Unit> PreviousPageCommand { get; set; }
        public ReactiveCommand<Unit, Unit> NextPageCommand { get; set; }
        public ReactiveCommand<Unit, Unit> LastPageCommand { get; set; }
        public ReactiveCommand<Unit, Unit> ShowGeoDataCommand { get; set; }
        public ReactiveCommand<Unit, Unit> AddToFavoritesCommand { get; set; }
        public ReactiveCommand<Unit, Unit> HelpCommand { get; set; }
        public ReactiveCommand<Unit, Unit> AboutCommand { get; set; }
        public ReactiveCommand<Unit, Unit> CheckUpdateCommand { get; set; }
        public ReactiveCommand<Unit, Unit> ExitCommand { get; set; }
        public ReactiveCommand<Unit, Unit> OpenWizardCommand { get; set; }
        public ReactiveCommand<Unit, Unit> OpenSettingsWindowCommand{get; set;}

        #endregion

        private async void ShowNextPage()
        {
            if (CurrentPage < TotalPages)
            {
                CurrentPage++;
                SelectedIndex = 0;
                await UpdateUi();
            }
        }

        private async void ShowPreviousPage()
        {
            if (CurrentPage > 0)
            {
                CurrentPage--;
                SelectedIndex = 0;
                await UpdateUi();
            }
        }

        private async void ShowFirstPage()
        {
            CurrentPage = 0;
            SelectedIndex = 0;
            await UpdateUi();
        }

        private async void ShowLastPage()
        {
            if (TotalPages > 0)
            {
                CurrentPage = TotalPages;
                SelectedIndex = 0;
                await UpdateUi();
            }
        }
        
        private Func<PhotoViewModel, bool> PageFilter(int currentPage)
        {
           return x =>
                x.Id >= itemPerPage * currentPage && x.Id < itemPerPage * (currentPage + 1);
        }
        private Func<PhotoViewModel, bool> TypeFilter(int fitlerType)
        {
            SelectedIndex = 0;
            switch (fitlerType)
            {
                case 0:
                    return x => true;
                case 1:
                    return x => x.Photo.Attribute == Attribute.WithObject;
                case 2:
                    return x => x.Photo.Attribute == Attribute.Favorite;
                default:
                    return x => true;
            }
        }
        
        private void CalculateTotalPages()
        {
            itemcount = _photos.Count;
            if (itemcount % itemPerPage == 0)
            {
                TotalPages = (itemcount / itemPerPage) - 1;
            }
            else
            {
                TotalPages = (itemcount / itemPerPage);
            }
        }
        
        public async void OpenModelManager()
        {
            //_applicationStatusManager.ChangeCurrentAppStatus(Enums.Status.Working, "");
            //ModelManagerWindow window = new ModelManagerWindow(LocalizationContext, ref _appConfig, _applicationStatusManager, _themeManager);
            //_appConfig = await window.ShowResult();
        }

        public async void OpenBugReport()
        {
            BugReportWindow window = new BugReportWindow(_themeManager);
            var context = new BugReportViewModel(window, LocalizationContext);
            window.DataContext = context;
            window.Show();
        }
        
        private async void PredictAll()
        {
            _applicationStatusManager.ChangeCurrentAppStatus(Enums.Status.Working, "");
            try
            {
                var plugin = _settingsViewModel.Plugin;
                using (var model = plugin.LoadModel(0.15f))
                {
                    var count = 0;
                    var objectCount = 0;
                    foreach (var photoViewModel in _photos.Items)
                    {
                        try
                        {
                            photoViewModel.Annotation.Objects = new List<Object>();
                            var detections = await Dispatcher.UIThread.InvokeAsync( () =>
                                Task.Run(() =>  model.Infer(photoViewModel.Path,
                                    photoViewModel.Photo.Width,
                                    photoViewModel.Photo.Height)));
                            foreach (var det in detections)
                            {
                                photoViewModel.Annotation.Objects.Add(new Object()
                                {
                                    Box = new Box()
                                    {
                                        Xmax = det.XMax,
                                        Xmin = det.XMin,
                                        Ymax = det.YMax,
                                        Ymin = det.YMin
                                    },
                                    Difficult = 0,
                                    Name = det.Label
                                });
                            }
                            photoViewModel.BoundBoxes = photoViewModel.GetBoundingBoxes();
                            if (photoViewModel.BoundBoxes.Any())
                            {
                                photoViewModel.Photo.Attribute = Attribute.WithObject;
                                photoViewModel.IsHasObject = true;
                            }
                            objectCount += photoViewModel.BoundBoxes.Count();
                            count++;
                            Console.WriteLine($"\tProgress: {(double) count / _photos.Items.Count() * 100} %");
                            _applicationStatusManager.ChangeCurrentAppStatus(Enums.Status.Working, $"Working | {(int)((double) count / _photos.Items.Count() * 100)} %, [{count} of {_photos.Items.Count()}]");
                        }
                        catch (Exception e)
                        {
                            Log.Error(e,$"Unable to process file {photoViewModel.Path}. Slipped.");
                        }
                    }
                    Log.Information($"Successfully predict {_photos.Items.Count()} photos. Find {objectCount} objects.");
                }
                plugin = null;
            }
            catch (Exception e)
            {
                Log.Error(e, "Unable to get prediction.");
            }
            GC.Collect();
            _applicationStatusManager.ChangeCurrentAppStatus(Enums.Status.Ready, "");
        }

        private void ShrinkCanvas()
        {
            Zoomer.Zoom(0.8);
        }

        private void IncreaseCanvas()
        {
            Zoomer.Zoom(1.2);
        }
        
        private void ResetCanvas()
        {
            Zoomer.Reset();
        }

        private async void OpenFile()
        {
            try
            {
                _applicationStatusManager.ChangeCurrentAppStatus(Enums.Status.Working, "");
                var reader = new PhotoVMReader(_window);
                reader.Notify += (status, statusString) =>
                {
                    _applicationStatusManager.ChangeCurrentAppStatus(status, statusString);
                };
                var photos = await reader.ReadAllFromDirByPhoto();
                if(!photos.Any())
                {
                    Log.Warning("There are no photos to load.");
                    _applicationStatusManager.ChangeCurrentAppStatus(Enums.Status.Ready, "");
                    return;
                }
                _photos.Clear();
                _photos.AddRange(photos);
                _applicationStatusManager.ChangeCurrentAppStatus(Enums.Status.Ready, "");
                CalculateTotalPages();
                SelectedIndex = 0;
                await UpdateUi();
                Log.Information($"Loads {_photos.Count} photos.");
            }
            catch (Exception ex)
            {
                Log.Error(ex,"Unable to load photos.");
            }
            _applicationStatusManager.ChangeCurrentAppStatus(Enums.Status.Ready, "");
        }

        private async void ImportFromXml()
        {
            try
            {
                _applicationStatusManager.ChangeCurrentAppStatus(Enums.Status.Working, "");
                var reader = new PhotoVMReader(_window);
                reader.Notify += (status, statusString) =>
                {
                    _applicationStatusManager.ChangeCurrentAppStatus(status, statusString);
                };
                var photos = await reader.ReadAllFromDirByAnnotation();
                if(!photos.Any())
                {
                    Log.Warning("There are no photos to load.");
                    _applicationStatusManager.ChangeCurrentAppStatus(Enums.Status.Ready, "");
                    return;
                }
                _photos.Clear();
                _photos.AddRange(photos);
                _applicationStatusManager.ChangeCurrentAppStatus(Enums.Status.Ready, "");
                CalculateTotalPages();
                SelectedIndex = 0;
                await UpdateUi();
                Log.Information($"Loads {_photos.Count} photos.");
            }
            catch (Exception ex)
            {
                Log.Error(ex,"Unable to load photos.");
            }
            _applicationStatusManager.ChangeCurrentAppStatus(Enums.Status.Ready, "");
        }

        private async void SaveAll()
        {
            try
            {
                if (!_photos.Items.Any())
                {
                    Log.Warning("There are no photos to save.");
                    return;
                }
                _applicationStatusManager.ChangeCurrentAppStatus(Enums.Status.Working, "");
                var writer = new PhotoVMWriter(_window);
                await writer.WriteMany(_photos.Items);
                _applicationStatusManager.ChangeCurrentAppStatus(Enums.Status.Ready, "Success | saved");
                Log.Information($"Saved {_photos.Items.Count()} photos.");
            }
            catch (Exception ex)
            {
                Log.Error(ex, "Unable to save photos.");
            }
            _applicationStatusManager.ChangeCurrentAppStatus(Enums.Status.Ready, "");
        }

        private async void SaveAs()
        {
            SaveAsWindow window = new SaveAsWindow(_themeManager);
            var context = new SaveAsWindowViewModel(window, _photos, _applicationStatusManager, LocalizationContext);
            window.DataContext = context;
            window.Show();
        }

        public async void OpenWizard()
        {
            Locator.CurrentMutable.Register(() => new FirstWizardView(), typeof(IViewFor<FirstWizardViewModel>));
            Locator.CurrentMutable.Register(() => new SecondWizardView(), typeof(IViewFor<SecondWizardViewModel>));
            Locator.CurrentMutable.Register(() => new ThirdWizardView(), typeof(IViewFor<ThirdWizardViewModel>));
            Locator.CurrentMutable.Register(() => new FourthWizardView(), typeof(IViewFor<FourthWizardViewModel>));
            var window = new WizardWindow(LocalizationContext, _themeManager);
            var context = new WizardWindowViewModel(window, _settingsViewModel, _applicationStatusManager, _photos, SelectedIndex);
            window.DataContext = context;
            window.Show();
            Log.Debug("Open Wizard");
        }

        public void Help()
        {
            switch (_settingsViewModel.Language)
            {
                case Language.English:
                    OpenUrl("https://docs.lacmus.ml");
                    break;
                case Language.Russian:
                    OpenUrl("https://docs.lacmus.ml/v/russian/");
                    break;
                default:
                    OpenUrl("https://docs.lacmus.ml");
                    break;
            }
        }

        public void ShowGeoData()
        {
            var window = new MetadataWindow(_themeManager);
            var context = new MetadataViewModel(window, PhotoViewModel.Photo.MetaDataDirectories, LocalizationContext);
            window.DataContext = context;
            window.Show();
        }

        public async void AddToFavorites()
        {
            if (_photoCollection[SelectedIndex].Photo.Attribute != Attribute.Favorite)
            {
                _photoCollection[SelectedIndex].Photo.Attribute = Attribute.Favorite;
                _photoCollection[SelectedIndex].IsFavorite = true;
            }
            else
            {
                if(_photoCollection[SelectedIndex].BoundBoxes.Any())
                    _photoCollection[SelectedIndex].Photo.Attribute = Attribute.WithObject;
                else
                {
                    _photoCollection[SelectedIndex].Photo.Attribute = Attribute.Empty;
                }
                _photoCollection[SelectedIndex].IsFavorite = false;
            }
            await UpdateUi();
        }

        public void About()
        {
            var window = new AboutWindow(_themeManager);
            var context = new AboutViewModel(window, LocalizationContext);
            window.DataContext = context;
            window.Show();
        }

        public async void Exit()
        {
            var window = MessageBoxManager.GetMessageBoxStandardWindow(new MessageBoxStandardParams
            {
                ContentTitle = "Exit",
                ContentMessage = "Do you really want to exit?",
                Icon = Icon.Info,
                Style = Style.None,
                ShowInCenter = true,
                ButtonDefinitions = ButtonEnum.YesNo
            });
            var result = await window.Show();
            if (result == ButtonResult.Yes)
                _window.Close();
        }

        private void OpenUrl(string url)
        {
            try
            {
                if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                {
                    using (Process proc = new Process {StartInfo = {UseShellExecute = true, FileName = url}})
                    {
                        proc.Start();
                    }
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.Linux))
                {
                    Process.Start("x-www-browser", url);
                }
                else if (RuntimeInformation.IsOSPlatform(OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                    throw new Exception();
            }
            catch (Exception e)
            {
                Log.Error(e,$"Unable to ope url {url}.");
            }
        }
        
        private async Task UpdateUi()
        {
            try
            {
                PhotoCollection[SelectedIndex].IsWatched = true;
                PhotoViewModel = null;
                var currentMiniaturePhotoViewModel = PhotoCollection[SelectedIndex];
                var photoLoader = new PhotoLoader();
                var fullPhoto = await photoLoader.Load(currentMiniaturePhotoViewModel.Path, PhotoLoadType.Full);
                var annotation = currentMiniaturePhotoViewModel.Annotation;
                var id = currentMiniaturePhotoViewModel.Id;
                PhotoViewModel = new PhotoViewModel(id, fullPhoto, annotation);
                PhotoViewModel.BoundBoxes = PhotoCollection[SelectedIndex].BoundBoxes;
                
                CanvasHeight = PhotoViewModel.Photo.ImageBrush.Source.PixelSize.Height;
                CanvasWidth = PhotoViewModel.Photo.ImageBrush.Source.PixelSize.Width;
                
                if (_applicationStatusManager.AppStatusInfo.Status == Enums.Status.Ready)
                    _applicationStatusManager.ChangeCurrentAppStatus(Enums.Status.Ready,
                        $"{Enums.Status.Ready.ToString()} | {PhotoViewModel.Path}");

                FavoritesStateString = PhotoCollection[SelectedIndex].Photo.Attribute == Attribute.Favorite ? "Remove from favorites" : "Add to favorites";
                    
                Log.Debug($"Ui updated to index {SelectedIndex}, contains {PhotoViewModel.BoundBoxes.Count()} objects");
            }
            catch (Exception ex)
            {
                //Log.Error(ex, "Unable to update ui.");
            }
        }

        private async void OpenSettingsWindowAsync()
        {
            Settings settingsWindow = new Settings();
            settingsWindow.DataContext = _settingsViewModel;
            var themeManager = new ThemeManager(settingsWindow);
            themeManager.UseTheme(_settingsViewModel.Theme);
            _settingsViewModel.OnRequestClose += (s, e) => settingsWindow.Close();
            _settingsViewModel.OnRequestRestart += (sender, args) => RestartApp();
            settingsWindow.Show();
        }

        private async void CheckUpdate()
        {
            try
            {
                var github = new GitHubClient(new ProductHeaderValue("LacmusApp.Avalonia"));
                var release = await github.Repository.Release.GetLatest("lacmus-foundation", "lacmus-app");
                if (release.Prerelease == false)
                {
                    var newVersion = int.Parse(Regex.Replace(release.TagName, @"[^\d]", ""));

                    var version = typeof(Program).Assembly.GetName().Version;
                    if (version != null)
                    {
                        var currentVersion = version.Major * 100 +
                                             version.Minor * 10 +
                                             version.Build;
                        if (newVersion > currentVersion)
                        {
                            Log.Information($"Fid new Lacmus Application version: {release.TagName}");
                            
                            Dispatcher.UIThread.Post(async () =>
                            {
                                var msg =
                                    $"Find new release of Lacmus Application: {release.TagName}.\nPlease update your application.\nOpen new release?";
                                if (LocalizationContext.Language == Language.Russian)
                                    msg =
                                        $"Найдена новая версия приложения Lacmus: {release.TagName}.\nПожалуйста обнвите ваше приложение.\nПерейти к загрузке новой версии?";
                            
                                var msgbox = MessageBoxManager.GetMessageBoxStandardWindow(new MessageBoxStandardParams
                                {
                                    ButtonDefinitions = ButtonEnum.YesNo,
                                    ContentTitle = "Update",
                                    ContentMessage = msg,
                                    Icon = MessageBox.Avalonia.Enums.Icon.Info,
                                    Style = Style.None,
                                    ShowInCenter = true
                                });
                                var result = await msgbox.Show();
                                if (result == ButtonResult.Yes)
                                {
                                    OpenUrl("https://github.com/lacmus-foundation/lacmus-app/releases/latest");
                                }
                            });
                        }
                        else
                        {
                            Log.Information($"Application is up to date.");
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Log.Error(e, "Can not check for updates");
            }
        }

        private async void RestartApp()
        {
            var msg = "To apply settings you need to restart application.";
            if (LocalizationContext.Language == Language.Russian)
                msg = "Чтобы применить настройки необходим перезапуск программы.";
            var msgbox = MessageBoxManager.GetMessageBoxStandardWindow(new MessageBoxStandardParams
            {
                ButtonDefinitions = ButtonEnum.Ok,
                ContentTitle = "Need to restart",
                ContentMessage = msg,
                Icon = MessageBox.Avalonia.Enums.Icon.Info,
                Style = Style.None,
                ShowInCenter = true
            });
            var result = await msgbox.Show();
            Environment.Exit(0);
        }
    }
}