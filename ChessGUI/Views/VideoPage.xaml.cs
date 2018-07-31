using System;

using ChessGUI.ViewModels;

using Windows.UI.Xaml.Controls;

namespace ChessGUI.Views
{
    public sealed partial class VideoPage : Page
    {
        public VideoViewModel ViewModel { get; } = new VideoViewModel();

        public VideoPage()
        {
            InitializeComponent();
            ViewModel.Initialize(webView);
        }
    }
}
