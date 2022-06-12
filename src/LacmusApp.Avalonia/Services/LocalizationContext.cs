using System;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;
using LacmusApp.Appearance.Enums;

namespace LacmusApp.Avalonia.Services
{
    public class LocalizationContext : ReactiveObject
    {
        [Reactive] public Language Language {get; set;}

        #region STRINGS FOR LOCALIZING MAIN WINDOW
        private string _file;
        [Reactive] public string File 
        {
            get { return _file; }
            set { this.RaiseAndSetIfChanged(ref _file, value); }
        }
        private string _openDirectory;
        [Reactive] public string OpenDirectory
        {
            get { return _openDirectory; }
            set { this.RaiseAndSetIfChanged(ref _openDirectory, value); }
        }
        private string _importAllFromXml;
        [Reactive] public string ImportAllFromXml
        {
            get { return _importAllFromXml; }
            set { this.RaiseAndSetIfChanged(ref _importAllFromXml, value); }
        }
        private string _settings;
        [Reactive] public string Settings
        {
            get { return _settings; }
            set { this.RaiseAndSetIfChanged(ref _settings, value); }
        }
        private string _exit;
        [Reactive] public string Exit
        {
            get { return _exit; }
            set { this.RaiseAndSetIfChanged(ref _exit, value); }
        }
        private string _model;
        [Reactive] public string Model
        {
            get { return _model; }
            set { this.RaiseAndSetIfChanged(ref _model, value); }
        }
        private string _loadModel;
        [Reactive] public string LoadModel
        {
            get { return _loadModel; }
            set { this.RaiseAndSetIfChanged(ref _loadModel, value); }
        }
        private string _updateModel;
        [Reactive] public string UpdateModel
        {
            get { return _updateModel; }
            set { this.RaiseAndSetIfChanged(ref _updateModel, value); }
        }
        private string _modelManager;
        [Reactive] public string ModelManager
        {
            get { return _modelManager; }
            set { this.RaiseAndSetIfChanged(ref _modelManager, value); }
        }
        private string _bugReport;
        [Reactive] public string BugReport
        {
            get { return _bugReport; }
            set { this.RaiseAndSetIfChanged(ref _bugReport, value); }
        }
        private string _image;
        [Reactive] public string Image
        {
            get { return _image; }
            set { this.RaiseAndSetIfChanged(ref _image, value); }
        }
        private string _predictAll;
        [Reactive] public string PredictAll
        {
            get { return _predictAll; }
            set { this.RaiseAndSetIfChanged(ref _predictAll, value); }
        }
        private string _increase;
        [Reactive] public string Increase
        {
            get { return _increase; }
            set { this.RaiseAndSetIfChanged(ref _increase, value); }
        }
        private string _shrink;
        [Reactive] public string Shrink
        {
            get { return _shrink; }
            set { this.RaiseAndSetIfChanged(ref _shrink, value); }
        }
        private string _reset;
        [Reactive] public string Reset
        {
            get { return _reset; }
            set { this.RaiseAndSetIfChanged(ref _reset, value); }
        }
        private string _next;
        [Reactive] public string Next
        {
            get { return _next; }
            set { this.RaiseAndSetIfChanged(ref _next, value); }
        }
        private string _previous;
        [Reactive] public string Previous
        {
            get { return _previous; }
            set { this.RaiseAndSetIfChanged(ref _previous, value); }
        }
        private string _help;
        [Reactive] public string Help
        {
            get { return _help; }
            set { this.RaiseAndSetIfChanged(ref _help, value); }
        }
        private string _openUserGuide;
        [Reactive] public string OpenUserGuide
        {
            get { return _openUserGuide; }
            set { this.RaiseAndSetIfChanged(ref _openUserGuide, value); }
        }
        private string _about;
        [Reactive] public string About
        {
            get { return _about; }
            set { this.RaiseAndSetIfChanged(ref _about, value); }
        }
        private string _saveAll;
        [Reactive] public string SaveAll
        {
            get { return _saveAll; }
            set { this.RaiseAndSetIfChanged(ref _saveAll, value); }
        }
        private string _showGeoPosition;
        [Reactive] public string ShowGeoPosition
        {
            get { return _showGeoPosition; }
            set { this.RaiseAndSetIfChanged(ref _showGeoPosition, value); }
        }
        private string _selectLanguage;
        [Reactive] public string OsErrorMesageGPU
        {
            get { return _selectLanguage; }
            set { this.RaiseAndSetIfChanged(ref _selectLanguage, value); }
        }
         private string _saveAs;
        [Reactive] public string SaveAs
        {
            get { return _saveAs; }
            set { this.RaiseAndSetIfChanged(ref _saveAs, value); }
        }
        private string _allPhotos;
        [Reactive] public string AllPhotos
        {
            get { return _allPhotos; }
            set { this.RaiseAndSetIfChanged(ref _allPhotos, value); }
        }
         private string _photosWithObject;
        [Reactive] public string PhotosWithObject
        {
            get { return _photosWithObject; }
            set { this.RaiseAndSetIfChanged(ref _photosWithObject, value); }
        }
         private string _favoritePhotos;
        [Reactive] public string FavoritePhotos
        {
            get { return _favoritePhotos; }
            set { this.RaiseAndSetIfChanged(ref _favoritePhotos, value); }
        }
         private string _wizard;
        [Reactive] public string Wizard
        {
            get { return _wizard; }
            set { this.RaiseAndSetIfChanged(ref _wizard, value); }
        }
         private string _border;
        [Reactive] public string Border
        {
            get { return _border; }
            set { this.RaiseAndSetIfChanged(ref _border, value); }
        }
        private string _favoritesStateString;
        [Reactive] public string FavoritesStateString
        {
            get { return _favoritesStateString; }
            set { this.RaiseAndSetIfChanged(ref _favoritesStateString, value); }
        }
        
        private string _checkUpdate;
        [Reactive] public string CheckUpdate
        {
            get { return _checkUpdate; }
            set { this.RaiseAndSetIfChanged(ref _checkUpdate, value); }
        }
        #endregion

        #region ABOUT WINDOW

        private string _aboutAppName;
        [Reactive] public string AboutAppName
        {
            get { return _aboutAppName; }
            set { this.RaiseAndSetIfChanged(ref _aboutAppName, value); }
        }
        
        private string _aboutVersion;
        [Reactive] public string AboutVersion
        {
            get { return _aboutVersion; }
            set { this.RaiseAndSetIfChanged(ref _aboutVersion, value); }
        }
        
        private string _aboutGintubPage;
        [Reactive] public string AboutGintubPage
        {
            get { return _aboutGintubPage; }
            set { this.RaiseAndSetIfChanged(ref _aboutGintubPage, value); }
        }
        
        private string _aboutPoweredBy;
        [Reactive] public string AboutPoweredBy
        {
            get { return _aboutPoweredBy; }
            set { this.RaiseAndSetIfChanged(ref _aboutPoweredBy, value); }
        }
        
        private string _aboutLicense;
        [Reactive] public string AboutLicense
        {
            get { return _aboutLicense; }
            set { this.RaiseAndSetIfChanged(ref _aboutLicense, value); }
        }
        
        private string _aboutLicenseButton;
        [Reactive] public string AboutLicenseButton
        {
            get { return _aboutLicenseButton; }
            set { this.RaiseAndSetIfChanged(ref _aboutLicenseButton, value); }
        }
        
        private string _aboutGinhubButton;
        [Reactive] public string AboutGinhubButton
        {
            get { return _aboutGinhubButton; }
            set { this.RaiseAndSetIfChanged(ref _aboutGinhubButton, value); }
        }
        
        private string _aboutVisitWebSiteButton;
        [Reactive] public string AboutVisitWebSiteButton
        {
            get { return _aboutVisitWebSiteButton; }
            set { this.RaiseAndSetIfChanged(ref _aboutVisitWebSiteButton, value); }
        }

        #endregion

        #region WIZARD WINDOW
        
        private string _wizardHeader;
        [Reactive] public string WizardHeader
        {
            get { return _wizardHeader; }
            set { this.RaiseAndSetIfChanged(ref _wizardHeader, value); }
        }
        
        private string _wizardDescription1;
        [Reactive] public string WizardDescription1
        {
            get { return _wizardDescription1; }
            set { this.RaiseAndSetIfChanged(ref _wizardDescription1, value); }
        }
        
        private string _wizardDescription2;
        [Reactive] public string WizardDescription2
        {
            get { return _wizardDescription2; }
            set { this.RaiseAndSetIfChanged(ref _wizardDescription2, value); }
        }
        
        private string _wizardDescription3;
        [Reactive] public string WizardDescription3
        {
            get { return _wizardDescription3; }
            set { this.RaiseAndSetIfChanged(ref _wizardDescription3, value); }
        }
        
        private string _wizardDescription4;
        [Reactive] public string WizardDescription4
        {
            get { return _wizardDescription4; }
            set { this.RaiseAndSetIfChanged(ref _wizardDescription4, value); }
        }
        
        private string _wizardDescription5;
        [Reactive] public string WizardDescription5
        {
            get { return _wizardDescription5; }
            set { this.RaiseAndSetIfChanged(ref _wizardDescription5, value); }
        }
        
        private string _wizardDescription6;
        [Reactive] public string WizardDescription6
        {
            get { return _wizardDescription6; }
            set { this.RaiseAndSetIfChanged(ref _wizardDescription6, value); }
        }
        
        private string _wizardBackButtonText;
        [Reactive] public string WizardBackButtonText
        {
            get { return _wizardBackButtonText; }
            set { this.RaiseAndSetIfChanged(ref _wizardBackButtonText, value); }
        }
        
        private string _wizardNextButtonText;
        [Reactive] public string WizardNextButtonText
        {
            get { return _wizardNextButtonText; }
            set { this.RaiseAndSetIfChanged(ref _wizardNextButtonText, value); }
        }
        
        private string _wizardPredictAllButtonText;
        [Reactive] public string WizardPredictAllButtonText
        {
            get { return _wizardPredictAllButtonText; }
            set { this.RaiseAndSetIfChanged(ref _wizardPredictAllButtonText, value); }
        }
        
        private string _wizardFinishButtonText;
        [Reactive] public string WizardFinishButtonText
        {
            get { return _wizardFinishButtonText; }
            set { this.RaiseAndSetIfChanged(ref _wizardFinishButtonText, value); }
        }
        
        private string _wizardRepeatButtonText;
        [Reactive] public string WizardRepeatButtonText
        {
            get { return _wizardRepeatButtonText; }
            set { this.RaiseAndSetIfChanged(ref _wizardRepeatButtonText, value); }
        }

        #region PAGE 4
            
        private string _wizardFourthHeader;
        [Reactive] public string WizardFourthHeader
        {
            get { return _wizardFourthHeader; }
            set { this.RaiseAndSetIfChanged(ref _wizardFourthHeader, value); }
        }
        
        private string _wizardFourthDescription;
        [Reactive] public string WizardFourthDescription
        {
            get { return _wizardFourthDescription; }
            set { this.RaiseAndSetIfChanged(ref _wizardFourthDescription, value); }
        }
        
        private string _wizardFourthTotalStatus;
        [Reactive] public string WizardFourthTotalStatus
        {
            get { return _wizardFourthTotalStatus; }
            set { this.RaiseAndSetIfChanged(ref _wizardFourthTotalStatus, value); }
        }
        
        private string _wizardFourthLoadingPhotos;
        [Reactive] public string WizardFourthLoadingPhotos
        {
            get { return _wizardFourthLoadingPhotos; }
            set { this.RaiseAndSetIfChanged(ref _wizardFourthLoadingPhotos, value); }
        }
        
        private string _wizardFourthProcessingPhotos;
        [Reactive] public string WizardFourthProcessingPhotos
        {
            get { return _wizardFourthProcessingPhotos; }
            set { this.RaiseAndSetIfChanged(ref _wizardFourthProcessingPhotos, value); }
        }
        
        private string _wizardFourthSavingResults;
        [Reactive] public string WizardFourthSavingResults
        {
            get { return _wizardFourthSavingResults; }
            set { this.RaiseAndSetIfChanged(ref _wizardFourthSavingResults, value); }
        }
        
        private string _wizardFourthStopButton;
        [Reactive] public string WizardFourthStopButton
        {
            get { return _wizardFourthStopButton; }
            set { this.RaiseAndSetIfChanged(ref _wizardFourthStopButton, value); }
        }
        
        private string _wizardFourthLogsExpander;
        [Reactive] public string WizardFourthLogsExpander
        {
            get { return _wizardFourthLogsExpander; }
            set { this.RaiseAndSetIfChanged(ref _wizardFourthLogsExpander, value); }
        }


        #endregion
        
        #region PAGE 1
            
        private string _wizardFirstHeader;
        [Reactive] public string WizardFirstHeader
        {
            get { return _wizardFirstHeader; }
            set { this.RaiseAndSetIfChanged(ref _wizardFirstHeader, value); }
        }
        
        private string _wizardFirstDescription;
        [Reactive] public string WizardFirstDescription
        {
            get { return _wizardFirstDescription; }
            set { this.RaiseAndSetIfChanged(ref _wizardFirstDescription, value); }
        }
        
        private string _wizardFirstInputWatermark;
        [Reactive] public string WizardFirstInputWatermark
        {
            get { return _wizardFirstInputWatermark; }
            set { this.RaiseAndSetIfChanged(ref _wizardFirstInputWatermark, value); }
        }
        
        private string _wizardFirstOpenPhotosButton;
        [Reactive] public string WizardFirstOpenPhotosButton
        {
            get { return _wizardFirstOpenPhotosButton; }
            set { this.RaiseAndSetIfChanged(ref _wizardFirstOpenPhotosButton, value); }
        }

        #endregion

        #region PAGE 2

        private string _wizardSecondHeader;
        [Reactive] public string WizardSecondHeader
        {
            get { return _wizardSecondHeader; }
            set { this.RaiseAndSetIfChanged(ref _wizardSecondHeader, value); }
        }
        
        private string _wizardSecondDescription1;
        [Reactive] public string WizardSecondDescription1
        {
            get { return _wizardSecondDescription1; }
            set { this.RaiseAndSetIfChanged(ref _wizardSecondDescription1, value); }
        }
        
        private string _wizardSecondDescription2;
        [Reactive] public string WizardSecondDescription2
        {
            get { return _wizardSecondDescription2; }
            set { this.RaiseAndSetIfChanged(ref _wizardSecondDescription2, value); }
        }
        
        private string _wizardSecondOutputWatermark;
        [Reactive] public string WizardSecondOutputWatermark
        {
            get { return _wizardSecondOutputWatermark; }
            set { this.RaiseAndSetIfChanged(ref _wizardSecondOutputWatermark, value); }
        }
        
        private string _wizardSecondSavePhotosButton;
        [Reactive] public string WizardSecondSavePhotosButton
        {
            get { return _wizardSecondSavePhotosButton; }
            set { this.RaiseAndSetIfChanged(ref _wizardSecondSavePhotosButton, value); }
        }

        #endregion

        #region PAGE 3
        
        private string _wizardThirdHeader;
        [Reactive] public string WizardThirdHeader
        {
            get { return _wizardThirdHeader; }
            set { this.RaiseAndSetIfChanged(ref _wizardThirdHeader, value); }
        }
        
        private string _wizardThirdDescription1;
        [Reactive] public string WizardThirdDescription1
        {
            get { return _wizardThirdDescription1; }
            set { this.RaiseAndSetIfChanged(ref _wizardThirdDescription1, value); }
        }
        
        private string _wizardThirdDescription2;
        [Reactive] public string WizardThirdDescription2
        {
            get { return _wizardThirdDescription2; }
            set { this.RaiseAndSetIfChanged(ref _wizardThirdDescription2, value); }
        }
        
        private string _wizardThirdDescription3;
        [Reactive] public string WizardThirdDescription3
        {
            get { return _wizardThirdDescription3; }
            set { this.RaiseAndSetIfChanged(ref _wizardThirdDescription3, value); }
        }
        
        private string _wizardThirdDescription4;
        [Reactive] public string WizardThirdDescription4
        {
            get { return _wizardThirdDescription4; }
            set { this.RaiseAndSetIfChanged(ref _wizardThirdDescription4, value); }
        }
        
        private string _wizardThirdModelRepository;
        [Reactive] public string WizardThirdModelRepository
        {
            get { return _wizardThirdModelRepository; }
            set { this.RaiseAndSetIfChanged(ref _wizardThirdModelRepository, value); }
        }
        
        private string _wizardThirdModelType;
        [Reactive] public string WizardThirdModelType
        {
            get { return _wizardThirdModelType; }
            set { this.RaiseAndSetIfChanged(ref _wizardThirdModelType, value); }
        }
        
        private string _wizardThirdModelVersion;
        [Reactive] public string WizardThirdModelVersion
        {
            get { return _wizardThirdModelVersion; }
            set { this.RaiseAndSetIfChanged(ref _wizardThirdModelVersion, value); }
        }
        
        private string _wizardThirdModelStatus;
        [Reactive] public string WizardThirdModelStatus
        {
            get { return _wizardThirdModelStatus; }
            set { this.RaiseAndSetIfChanged(ref _wizardThirdModelStatus, value); }
        }
        
        private string _wizardThirdModelManagerButton;
        [Reactive] public string WizardThirdModelManagerButton
        {
            get { return _wizardThirdModelManagerButton; }
            set { this.RaiseAndSetIfChanged(ref _wizardThirdModelManagerButton, value); }
        }
        
        private string _wizardThirdModelStatusUpdateButton;
        [Reactive] public string WizardThirdModelStatusUpdateButton
        {
            get { return _wizardThirdModelStatusUpdateButton; }
            set { this.RaiseAndSetIfChanged(ref _wizardThirdModelStatusUpdateButton, value); }
        }

        #endregion

        #endregion

        #region METADATA WINDOW

        private string _metadataHeader;
        [Reactive] public string MetadataHeader
        {
            get { return _metadataHeader; }
            set { this.RaiseAndSetIfChanged(ref _metadataHeader, value); }
        }
        
        private string _metadataLatitude;
        [Reactive] public string MetadataLatitude
        {
            get { return _metadataLatitude; }
            set { this.RaiseAndSetIfChanged(ref _metadataLatitude, value); }
        }
        
        private string _metadataLongitude;
        [Reactive] public string MetadataLongitude
        {
            get { return _metadataLongitude; }
            set { this.RaiseAndSetIfChanged(ref _metadataLongitude, value); }
        }
        
        private string _metadataAltitude;
        [Reactive] public string MetadataAltitude
        {
            get { return _metadataAltitude; }
            set { this.RaiseAndSetIfChanged(ref _metadataAltitude, value); }
        }
        
        private string _metadataOpenWith;
        [Reactive] public string MetadataOpenWith
        {
            get { return _metadataOpenWith; }
            set { this.RaiseAndSetIfChanged(ref _metadataOpenWith, value); }
        }
        
        private string _metadataAllMetadata;
        [Reactive] public string MetadataAllMetadata
        {
            get { return _metadataAllMetadata; }
            set { this.RaiseAndSetIfChanged(ref _metadataAllMetadata, value); }
        }

        #endregion

        #region MODEL MANAGER WINDOW
        private string _modelManagerName;
        [Reactive] public string ModelManagerName
        {
            get { return _modelManagerName; }
            set { this.RaiseAndSetIfChanged(ref _modelManagerName, value); }
        }
        private string _modelManagerAuthor;
        [Reactive] public string ModelManagerAuthor
        {
            get { return _modelManagerAuthor; }
            set { this.RaiseAndSetIfChanged(ref _modelManagerAuthor, value); }
        }
        private string _modelManagerCompany;
        [Reactive] public string ModelManagerCompany
        {
            get { return _modelManagerCompany; }
            set { this.RaiseAndSetIfChanged(ref _modelManagerCompany, value); }
        }
        private string _modelManagerDescription;
        [Reactive] public string ModelManagerDescription
        {
            get { return _modelManagerDescription; }
            set { this.RaiseAndSetIfChanged(ref _modelManagerDescription, value); }
        }
        private string _modelManagerTag;
        [Reactive] public string ModelManagerTag
        {
            get { return _modelManagerTag; }
            set { this.RaiseAndSetIfChanged(ref _modelManagerTag, value); }
        }
        private string _modelManagerVersion;
        [Reactive] public string ModelManagerVersion
        {
            get { return _modelManagerVersion; }
            set { this.RaiseAndSetIfChanged(ref _modelManagerVersion, value); }
        }
        private string _modelManagerSupportedOs;
        [Reactive] public string ModelManagerSupportedOs
        {
            get { return _modelManagerSupportedOs; }
            set { this.RaiseAndSetIfChanged(ref _modelManagerSupportedOs, value); }
        }
        private string _modelManagerInferenceType;
        [Reactive] public string ModelManagerInferenceType
        {
            get { return _modelManagerInferenceType; }
            set { this.RaiseAndSetIfChanged(ref _modelManagerInferenceType, value); }
        }
        private string _modelManagerUrl;
        [Reactive] public string ModelManagerUrl
        {
            get { return _modelManagerUrl; }
            set { this.RaiseAndSetIfChanged(ref _modelManagerUrl, value); }
        }
        private string _modelManagerInstalledModels;
        [Reactive] public string ModelManagerInstalledModels
        {
            get { return _modelManagerInstalledModels; }
            set { this.RaiseAndSetIfChanged(ref _modelManagerInstalledModels, value); }
        }
        
        private string _modelManagerAvailableModels;
        [Reactive] public string ModelManagerAvailableModels
        {
            get { return _modelManagerAvailableModels; }
            set { this.RaiseAndSetIfChanged(ref _modelManagerAvailableModels, value); }
        }
        
        private string _modelManagerRefreshButton;
        [Reactive] public string ModelManagerRefreshButton
        {
            get { return _modelManagerRefreshButton; }
            set { this.RaiseAndSetIfChanged(ref _modelManagerRefreshButton, value); }
        }
        
        private string _modelManagerRemoveSelectedButton;
        [Reactive] public string ModelManagerRemoveSelectedButton
        {
            get { return _modelManagerRemoveSelectedButton; }
            set { this.RaiseAndSetIfChanged(ref _modelManagerRemoveSelectedButton, value); }
        }
        
        private string _modelManagerActivateSelectedButton;
        [Reactive] public string ModelManagerActivateSelectedButton
        {
            get { return _modelManagerActivateSelectedButton; }
            set { this.RaiseAndSetIfChanged(ref _modelManagerActivateSelectedButton, value); }
        }
        
        private string _modelManagerDownloadSelectedButton;
        [Reactive] public string ModelManagerDownloadSelectedButton
        {
            get { return _modelManagerDownloadSelectedButton; }
            set { this.RaiseAndSetIfChanged(ref _modelManagerDownloadSelectedButton, value); }
        }
        
        private string _modelManagerApplyButton;
        [Reactive] public string ModelManagerApplyButton
        {
            get { return _modelManagerApplyButton; }
            set { this.RaiseAndSetIfChanged(ref _modelManagerApplyButton, value); }
        }
        
        private string _modelManagerManagerCloseButton;
        [Reactive] public string ModelManagerCloseButton
        {
            get { return _modelManagerManagerCloseButton; }
            set { this.RaiseAndSetIfChanged(ref _modelManagerManagerCloseButton, value); }
        }
        
        private string _modelManagerManagerRepositories;
        [Reactive] public string ModelManagerRepositories
        {
            get { return _modelManagerManagerRepositories; }
            set { this.RaiseAndSetIfChanged(ref _modelManagerManagerRepositories, value); }
        }
        
        private string _modelManagerManagerRepositoryWatermark;
        [Reactive] public string ModelManagerRepositoryWatermark
        {
            get { return _modelManagerManagerRepositoryWatermark; }
            set { this.RaiseAndSetIfChanged(ref _modelManagerManagerRepositoryWatermark, value); }
        }
        
        private string _modelManagerManagerAddRepositoryButton;
        [Reactive] public string ModelManagerAddRepositoryButton
        {
            get { return _modelManagerManagerAddRepositoryButton; }
            set { this.RaiseAndSetIfChanged(ref _modelManagerManagerAddRepositoryButton, value); }
        }

        #endregion

        #region SAVE AS WINDOW

        private string _saveAsOptionsToSave;
        [Reactive] public string SaveAsOptionsToSave
        {
            get { return _saveAsOptionsToSave; }
            set { this.RaiseAndSetIfChanged(ref _saveAsOptionsToSave, value); }
        }
        
        private string _saveAsTypesToSave;
        [Reactive] public string SaveAsTypesToSave
        {
            get { return _saveAsTypesToSave; }
            set { this.RaiseAndSetIfChanged(ref _saveAsTypesToSave, value); }
        }
        
        private string _saveAsSourcePhotos;
        [Reactive] public string SaveAsSourcePhotos
        {
            get { return _saveAsSourcePhotos; }
            set { this.RaiseAndSetIfChanged(ref _saveAsSourcePhotos, value); }
        }
        
        private string _saveAsXmlAnnotations;
        [Reactive] public string SaveAsXmlAnnotations
        {
            get { return _saveAsXmlAnnotations; }
            set { this.RaiseAndSetIfChanged(ref _saveAsXmlAnnotations, value); }
        }
        
        private string _saveAsDrawBbox;
        [Reactive] public string SaveAsDrawBbox
        {
            get { return _saveAsDrawBbox; }
            set { this.RaiseAndSetIfChanged(ref _saveAsDrawBbox, value); }
        }
        
        private string _saveAsCrops;
        [Reactive] public string SaveAsCrops
        {
            get { return _saveAsCrops; }
            set { this.RaiseAndSetIfChanged(ref _saveAsCrops, value); }
        }
        
        private string _saveAsPosition;
        [Reactive] public string SaveAsPosition
        {
            get { return _saveAsCrops; }
            set { this.RaiseAndSetIfChanged(ref _saveAsCrops, value); }
        }
        
        private string _saveAsSelectPath;
        [Reactive] public string SaveAsSelectPath
        {
            get { return _saveAsSelectPath; }
            set { this.RaiseAndSetIfChanged(ref _saveAsSelectPath, value); }
        }

        #endregion

        #region SETTINGS

        private string _settingsGeneral;
        [Reactive] public string SettingsGeneral
        {
            get { return _settingsGeneral; }
            set { this.RaiseAndSetIfChanged(ref _settingsGeneral, value); }
        }
        
        private string _settingsLanguage;
        [Reactive] public string SettingsLanguage
        {
            get { return _settingsLanguage; }
            set { this.RaiseAndSetIfChanged(ref _settingsLanguage, value); }
        }
        
        private string _settingsTheme;
        [Reactive] public string SettingsTheme
        {
            get { return _settingsTheme; }
            set { this.RaiseAndSetIfChanged(ref _settingsTheme, value); }
        }
        
        private string _settingsMlModel;
        [Reactive] public string SettingsMlModel
        {
            get { return _settingsMlModel; }
            set { this.RaiseAndSetIfChanged(ref _settingsMlModel, value); }
        }
        
        private string _settingsMlModelGeneral;
        [Reactive] public string SettingsMlModelGeneral
        {
            get { return _settingsMlModelGeneral; }
            set { this.RaiseAndSetIfChanged(ref _settingsMlModelGeneral, value); }
        }
        
        private string _settingsHost;
        [Reactive] public string SettingsHost
        {
            get { return _settingsHost; }
            set { this.RaiseAndSetIfChanged(ref _settingsHost, value); }
        }
        
        private string _settingsPort;
        [Reactive] public string SettingsPort
        {
            get { return _settingsPort; }
            set { this.RaiseAndSetIfChanged(ref _settingsPort, value); }
        }
        
        private string _settingsJWT;
        [Reactive] public string SettingsJWT
        {
            get { return _settingsJWT; }
            set { this.RaiseAndSetIfChanged(ref _settingsJWT, value); }
        }
        
        private string _settingsBatchSize;
        [Reactive] public string SettingsBatchSize
        {
            get { return _settingsBatchSize; }
            set { this.RaiseAndSetIfChanged(ref _settingsBatchSize, value); }
        }

        #endregion

        #region BUG REPORT WINDOW

        private string _labelingWindowCapture;
        [Reactive] public string LabelingWindowCapture
        {
            get { return _labelingWindowCapture; }
            set { this.RaiseAndSetIfChanged(ref _labelingWindowCapture, value); }
        }
        private string _labelingWindowFalsePositive;
        [Reactive] public string LabelingWindowFalsePositive
        {
            get { return _labelingWindowFalsePositive; }
            set { this.RaiseAndSetIfChanged(ref _labelingWindowFalsePositive, value); }
        }
        private string _labelingWindowFalseNegative;
        [Reactive] public string LabelingWindowFalseNegative
        {
            get { return _labelingWindowFalseNegative; }
            set { this.RaiseAndSetIfChanged(ref _labelingWindowFalseNegative, value); }
        }
        
        #endregion

        public LocalizationContext()
        {
            this.WhenAnyValue(vm=>vm.Language).Subscribe(_=>UpdateText());
            Language = new Language();
            Language=Language.English;
        }

        private void UpdateText()
        {
            switch (Language)
            {
                case Language.English:
                {
                    //Main view model
                    //Main menu
                    //File
                    File="File";
                    OpenDirectory="Open...";
                    ImportAllFromXml="Import from XMLs...";
                    SaveAll="Save";
                    SaveAs="Save As";
                    Wizard="Wizard";
                    Settings="Settings";
                    Exit="Exit";
                    //Model
                    Model="Model";
                    LoadModel="Load model";
                    UpdateModel="Update model";
                    ModelManager="Model manager...";
                    BugReport = "Send bug report...";
                    //Image
                    Image="Image";
                    PredictAll="Predict All";
                    Increase="Increase";
                    Shrink="Shrink";
                    Reset="Reset";
                    Next="Next";
                    Previous="Previous";
                    Border="Border";
                    //Help
                    Help="Help";
                    OpenUserGuide="Open user guide";
                    About="About";
                    CheckUpdate = "Check for updates";
                    //ListView
                    AllPhotos="All photos";
                    PhotosWithObject="Photos with objects";
                    FavoritePhotos="Favorite photos";
                    //Context menu
                    ShowGeoPosition="Show geo position";
                    FavoritesStateString = "Add to \\ remove from favorites";
                    
                    //About Window
                    AboutAppName = "Lacmus desktop application.";
                    AboutVersion = "Version: ";
                    AboutGintubPage = "Github page: ";
                    AboutPoweredBy = "Powered by: ";
                    AboutLicense = "This program comes with ABSOLUTELY NO WARRANTY; This is free software, and you are welcome to redistribute it under GNU GPL license; Click `license` for details.";
                    AboutLicenseButton = "License";
                    AboutGinhubButton = "Github";
                    AboutVisitWebSiteButton = "Visit web site";
                    
                    //Wizard Window
                    WizardHeader = "Welcome to the photo recognition wizard!";
                    WizardDescription1 = "To process your photos with the help of the nero network you need to go through 3 simple steps:";
                    WizardDescription2 = "    Step 1: select photos to process";
                    WizardDescription3 = "    Step 2: choosing a place to save the results";
                    WizardDescription4 = "    Step 3: configure ml model";
                    WizardDescription5 = "At any time, you can close this window and continue using the program through the main interface. Thank you for using the Lacmus program.";
                    WizardDescription6 = "Click 'Next' to continue.";
                    WizardBackButtonText = "Back";
                    WizardNextButtonText = "Next";
                    WizardPredictAllButtonText = "Predict all";
                    WizardFinishButtonText = "Finish";
                    WizardRepeatButtonText = "Repeat";
                    //Page 1
                    WizardFirstHeader = "Step 1: Select input data";
                    WizardFirstDescription = "To begin, please select the input data for recognition by clicking the 'Open photos' button or by writing the full path to the input folder in the text box below.";
                    WizardFirstInputWatermark = "Enter input path here.";
                    WizardFirstOpenPhotosButton = "Open photos";
                    //Page 2
                    WizardSecondHeader = "Step 2: Select output data";
                    WizardSecondDescription1 = "Now select the output to save by clicking the 'Save photos' button or specifying the full path to the input folder in the text box below.";
                    WizardSecondDescription2 = "After processing is complete, the application will save photos and XML files with the description of recognized objects in the specified folder. You can view saved objects at any time by selecting a saved folder from the 'file - import from xml' menu.";
                    WizardSecondOutputWatermark = "Enter output path here.";
                    WizardSecondSavePhotosButton = "Save photos";
                    //Page 3
                    WizardThirdHeader = "Step 3: Setup ml model";
                    WizardThirdDescription1 = "Before proceeding, make sure that the selected configuration of the neural network model is correct.";
                    WizardThirdDescription2 = "If the configuration of the neural network model is not specified or you want to use a different configuration, go to the settings by selecting the 'file - settings' in the main menu of the program.";
                    WizardThirdDescription3 = "If your model is not loaded, configure and download it by clicking the 'Model manager' button. To download, you need to download from 2 to 6GB. Make sure your internet connection is reliable.";
                    WizardThirdDescription4 = "If everything is correct, click the 'Predict all' button to start the processing process. Upon completion of the process, the result of the program operation will appear in the selected save folder.";
                    WizardThirdModelRepository = "Ml model repository: ";
                    WizardThirdModelType = "Ml model type: ";
                    WizardThirdModelVersion = "Ml model version: ";
                    WizardThirdModelStatus = "Ml model status: ";
                    WizardThirdModelManagerButton = "Settings";
                    WizardThirdModelStatusUpdateButton = "Refresh";
                    //Page 4
                    WizardFourthHeader = "Processing photos";
                    WizardFourthDescription = "Photo processing in progress. Please do not close the program and wait until the process ends. To force stop the processing, click 'Stop ml model' (progress will save).";
                    WizardFourthTotalStatus = "Total status: ";
                    WizardFourthLoadingPhotos = "Loading photos: ";
                    WizardFourthProcessingPhotos = "Processing photos: ";
                    WizardFourthSavingResults = "Saving results: ";
                    WizardFourthStopButton = "Stop ml model";
                    WizardFourthLogsExpander = "Details";
                    
                    //Metadata
                    MetadataHeader = "GPS position of the image center";
                    MetadataLatitude = "Latitude: ";
                    MetadataLongitude = "Longitude: ";
                    MetadataAltitude = "Altitude: ";
                    MetadataOpenWith = "Open with:";
                    MetadataAllMetadata = "All metadata";
                    
                    //Model manager
                    ModelManagerName = "Name: ";
                    ModelManagerAuthor = "Author: ";
                    ModelManagerCompany = "Company: ";
                    ModelManagerDescription = "Description: ";
                    ModelManagerTag = "Tag: ";
                    ModelManagerVersion = "Version: ";
                    ModelManagerInferenceType = "Type: ";
                    ModelManagerSupportedOs = "Supported OS: ";
                    ModelManagerUrl = "Url: ";
                    
                    ModelManagerInstalledModels = "Installed ml models";
                    ModelManagerAvailableModels = "Available ml models";
                    ModelManagerRefreshButton = "Refresh";
                    ModelManagerRemoveSelectedButton = "Remove selected";
                    ModelManagerActivateSelectedButton = "Activate selected";
                    ModelManagerDownloadSelectedButton = "Download selected";
                    ModelManagerApplyButton = "Apply";
                    ModelManagerCloseButton = "Close";
                    ModelManagerRepositories = "Repositories";
                    ModelManagerRepositoryWatermark = "Enter repository name here.";
                    ModelManagerAddRepositoryButton = "Add";
                    
                    //Save as
                    SaveAsOptionsToSave = "Select options to save:";
                    SaveAsTypesToSave = "Type of photos to save:";
                    //AllPhotos="All photos";
                    //PhotosWithObject="Photos with objects";
                    //FavoritePhotos="Favorite photos";
                    SaveAsSourcePhotos = "Save source photos.";
                    SaveAsXmlAnnotations = "Save XML annotations.";
                    SaveAsDrawBbox = "Save photo with drawn bounded boxes.";
                    SaveAsCrops = "Save bbox crops.";
                    SaveAsPosition = "Save geo position.";
                    SaveAsSelectPath = "Browse...";
                    //WizardSecondOutputWatermark = "Enter output path here.";
                    //WizardSecondSavePhotosButton = "Save photos";
                    
                    //Settings
                    SettingsGeneral = "General";
                    SettingsLanguage = "Language:";
                    SettingsTheme = "Theme:";
                    SettingsMlModel = "ML model";
                    SettingsMlModelGeneral = "General ML model settings.";
                    SettingsHost = "Host:";
                    SettingsPort = "Port:";
                    SettingsJWT = "Use JVT for external usage";
                    SettingsBatchSize = "Threads:";
                    //WizardThirdModelRepository = "Ml model repository: ";
                    //WizardThirdModelType = "Ml model type: ";
                    //WizardThirdModelVersion = "Ml model version: ";
                    //WizardThirdModelStatus = "Ml model status: ";
                    //WizardThirdModelManagerButton = "Model manager";
                    //WizardThirdModelStatusUpdateButton = "Refresh";
                    //ModelManagerApplyButton = "Apply";
                    //ModelManagerCloseButton = "Close";
                    
                    //BugReportWindow
                    LabelingWindowCapture = "By submitting reports on neural network errors, you improve our recognition algorithm. Thank you for helping us develop!\n\nPlease select an error type:";
                    LabelingWindowFalsePositive = "No person found in the photo (False Negative).";
                    LabelingWindowFalseNegative = "An object was found in the photo but it is not a person (False Positive).";

                    OsErrorMesageGPU = "Your OS is not support this ml model type.";
                    break;
                }
                case Language.Russian:
                {
                    //Main view model
                    //Main menu
                    //File
                    File="Файл";
                    OpenDirectory="Открыть...";
                    ImportAllFromXml="Импортировать из XML...";
                    SaveAll="Сохранить";
                    SaveAs="Сохранить как...";
                    Wizard="Помощник";
                    Settings="Настройки";
                    Exit="Выход";
                    //Model
                    Model="Модель";
                    LoadModel="Загрузить";
                    UpdateModel="Обновить";
                    ModelManager="Менеджер моделей...";
                    BugReport = "Сообщить об ошибке...";
                    //Image
                    Image="Изображение";
                    PredictAll="Обработать все";
                    Increase="Увеличить";
                    Shrink="Уменьшить";
                    Reset="Сбросить";
                    Next="Следующее";
                    Previous="Предыдущее";
                    Border="Рамка";
                    //Help
                    Help="Помощь";
                    OpenUserGuide="Открыть руководство пользователя";
                    About="О программе";
                    CheckUpdate = "Проверить обновления";
                    //ListView
                    AllPhotos="Все фото";
                    PhotosWithObject="Фото с объектами";
                    FavoritePhotos="Избранные фото";
                    //Context menu
                    ShowGeoPosition="Показать геопозицию";
                    FavoritesStateString = "Добавить \\ удалить из избранных";

                    //About Window
                    AboutAppName = "Приложение Lacmus.";
                    AboutVersion = "Версия: ";
                    AboutGintubPage = "Страница Github: ";
                    AboutPoweredBy = "При поддержке: ";
                    AboutLicense = "Данное ПО поставляется АБСОЛЮТНО БЕЗ ГАРАНТИЙ; Это свободное ПО, оно распространяется под лицензией GNU GPL; Нажмите `Лицензия` для просмотра.";
                    AboutLicenseButton = "Лицензия";
                    AboutGinhubButton = "Github";
                    AboutVisitWebSiteButton = "Веб-сайт";

                    //Wizard Window
                    WizardHeader = "Добро пожаловать в мастер распознавания фото!";
                    WizardDescription1 = "Чтобы обработать фотографии с помощью нейронной сети (ml модели) Вам необходимо выполнить 3 простых шага:";
                    WizardDescription2 = "    Шаг 1: выберите фото для обработки";
                    WizardDescription3 = "    Шаг 2: выберите место для сохранения результатов";
                    WizardDescription4 = "    Шаг 3: выберите и настройте ml модель";
                    WizardDescription5 = "В любое время вы можете закрыть это окно и вернуться к основному интерфейсу программы. Спасибо что используете Lacmus!";
                    WizardDescription6 = "Нажмите 'Далее' чтобы продолжить.";
                    WizardBackButtonText = "Назад";
                    WizardNextButtonText = "Далее";
                    WizardPredictAllButtonText = "Начать обработку";
                    WizardFinishButtonText = "Завершить";
                    WizardRepeatButtonText = "Начать сначала";
                    //Page 1
                    WizardFirstHeader = "Шаг 1: выберете входные данные";
                    WizardFirstDescription = "Чтобы начать, выберите входные данные для распознавания, нажав кнопку 'Выбрать фото' или указав полный путь к входной папке в текстовом поле ниже.";
                    WizardFirstInputWatermark = "Введите путь к входной папке сюда.";
                    WizardFirstOpenPhotosButton = "Выбрать фото";
                    //Page 2
                    WizardSecondHeader = "Шаг 2: выберите выходные данные";
                    WizardSecondDescription1 = "Теперь выберите папку для сохранения результатов, нажав на кнопку 'Сохранить фотографии' или введя полный путь к выходной папке в текстовом поле ниже.";
                    WizardSecondDescription2 = "После завершения процесса обработки приложение сохранит результаты в выбранную папку. Вы сможете вновь открыть и просмотреть результаты в любой момент, выбрав меню 'Файл - Импортировать из XML'.";
                    WizardSecondOutputWatermark = "Введите путь к выходной папке сюда.";
                    WizardSecondSavePhotosButton = "Сохранить фотографии";
                    //Page 3
                    WizardThirdHeader = "Шаг 3: сконфигурируйте ml модель";
                    WizardThirdDescription1 = "Перед началом обработки убедитесь, что ml модель сконфигурирована правильно и готова к использованию.";
                    WizardThirdDescription2 = "Если ml модель не готова, или Вы хотите выбрать другую ml модель, сконфигурируйте ее, выбрав меню 'Файл - Настройки'.";
                    WizardThirdDescription3 = "Если модель не готова, Вы можете сконфигурировать и загрузить ее в менеджере моделей, нажав кнопку 'Менеджер ml моделей'. Помните: для загрузки ml модели из Интернета необходимо загрузить от 2 до 6 GB. Убедитесь, что ваше интернет соединение надежно, и что на вашем компьютере присутствует необходимый объем дискового пространства.";
                    WizardThirdDescription4 = "Если все хорошо, и модель готова - нажмите кнопку 'Начать обработку', чтобы запустить процесс. После завершения процесса распознавания результаты будут сохранены в выбранной ранее выходной папке.";
                    WizardThirdModelRepository = "Репозиторий ml модели: ";
                    WizardThirdModelType = "Тип ml модели: ";
                    WizardThirdModelVersion= "Версия ml модели: ";
                    WizardThirdModelStatus = "Готовность ml модели: ";
                    WizardThirdModelManagerButton = "Настройки";
                    WizardThirdModelStatusUpdateButton = "Обновить информацию";
                    //Page 4
                    WizardFourthHeader = "Обработка фотографий";
                    WizardFourthDescription = "Выполняется процесс обработки изображений. Пожалуйста, не закрывайте программу и дождитесь окончания процесса. Для принудительной остановки обработки нажмите кнопку 'Остановить ml модель' (весь прогресс будет сохранен).";
                    WizardFourthTotalStatus = "Статус выполнения: ";
                    WizardFourthLoadingPhotos = "Загрузка фотографий: ";
                    WizardFourthProcessingPhotos = "Обработка фотографий: ";
                    WizardFourthSavingResults = "Сохранение результатов: ";
                    WizardFourthStopButton = "Остановить ml модель";
                    WizardFourthLogsExpander = "Детали обработки";

                    //Metadata
                    MetadataHeader = "GPS координаты центра изображения";
                    MetadataLatitude = "Широта: ";
                    MetadataLongitude = "Долгота: ";
                    MetadataAltitude = "Высота: ";
                    MetadataOpenWith = "Показать на карте:";
                    MetadataAllMetadata = "Все метаданные";

                    //Model manager
                    ModelManagerName = "Имя: ";
                    ModelManagerAuthor = "Автор: ";
                    ModelManagerCompany = "Компания: ";
                    ModelManagerDescription = "Описание: ";
                    ModelManagerTag = "Тэг: ";
                    ModelManagerVersion = "Версия: ";
                    ModelManagerInferenceType = "Тип: ";
                    ModelManagerSupportedOs = "Поддерживаемые ОС: ";
                    ModelManagerUrl = "Ссылка: ";
                    
                    ModelManagerInstalledModels = "Установленные ml модели";
                    ModelManagerAvailableModels = "Доступные для загрузки ml модели";
                    ModelManagerRefreshButton = "Обновить информацию";
                    ModelManagerRemoveSelectedButton = "Удалить выбранное";
                    ModelManagerActivateSelectedButton = "Активировать выбранную";
                    ModelManagerDownloadSelectedButton = "Загрузить выбранную";
                    ModelManagerApplyButton = "Применить";
                    ModelManagerCloseButton = "Отмена";
                    ModelManagerRepositories = "Репозитории ml моделей";
                    ModelManagerRepositoryWatermark = "Ведите имя репозитория.";
                    ModelManagerAddRepositoryButton = "Добавить";

                    //Save as
                    SaveAsOptionsToSave = "Выберите опции для сохранения:";
                    SaveAsTypesToSave = "Тип сохраняемых фотографий:";
                    SaveAsSourcePhotos = "Сохранить исходные фото.";
                    SaveAsXmlAnnotations = "Сохранить XML аннотации.";
                    SaveAsDrawBbox = "Сохранить фотографии с нарисованными рамками объектов.";
                    SaveAsCrops = "Сохранить вырезанные объекты.";
                    SaveAsPosition = "Сохранить геопозицию.";
                    SaveAsSelectPath = "Выбрать папку";

                    //Settings
                    SettingsGeneral = "Общие";
                    SettingsLanguage = "Язык:";
                    SettingsTheme = "Тема оформления:";
                    SettingsMlModel = "ML модель";
                    SettingsMlModelGeneral = "Общие настройки ml модели.";
                    SettingsHost = "Хост:";
                    SettingsPort = "Порт:";
                    SettingsJWT = "Внешнее использование (включить JVT шифрование)";
                    SettingsBatchSize = "Число потоков";
                    
                    //BugReportWindow
                    LabelingWindowCapture = "Отправляя нам отчеты об ошибках в работе нейронной сети, вы обучаете и улучшаете наш алгоритм распознования! Спасибо что используете Lacmus и помогаете нам развиваться!\n\nПожалуйста выбирете тип ошибки:";
                    LabelingWindowFalsePositive = "На фото не найден человек (False Negative).";
                    LabelingWindowFalseNegative = "На фото обнаружен объект, но это не человек (False Positive).";

                    //Erroes
                    OsErrorMesageGPU = "Ваша операционная система не поддерживает этот тип ml моделей.";
                    break;
                }
            }
        }
    }
}
