﻿using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.PanAndZoom;
using Avalonia.Input;
using Avalonia.Markup.Xaml;
using Avalonia.ReactiveUI;
using ReactiveUI;
using LacmusApp.Models;
using LacmusApp.ViewModels;

namespace LacmusApp.Views
{
    public sealed class MainWindow : ReactiveWindow<MainWindowViewModel>
    {
        public MainWindow()
        {
            AvaloniaXamlLoader.Load(this);
            this.WhenActivated(disposables => { });
            Zoomer.Init(this.Find<ZoomBorder>("zoomBorder"));
            Zoomer.KeyDown += ZoomBorder_KeyDown;
        }

        private void ZoomBorder_KeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.R:
                    Zoomer.Reset();
                    break;
                case Key.Up:
                    Zoomer.MoveTo(0, 25);
                    break;
                case Key.Down:
                    Zoomer.MoveTo(0, -25);
                    break;
                case Key.Left:
                    Zoomer.MoveTo(25, 0);
                    break;
                case Key.Right:
                    Zoomer.MoveTo(-25, 0);
                    break;
            }
        }
    }
}
