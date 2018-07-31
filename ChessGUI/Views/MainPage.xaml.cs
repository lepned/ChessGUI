using System;

using ChessGUI.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ChessGUI.Views
{
    public sealed partial class MainPage : Page
    {
        public MainViewModel ViewModel { get; } = new MainViewModel();

        public MainPage()
        {
            InitializeComponent();
        }
    }
}
