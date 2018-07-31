using System;

using ChessGUI.ViewModels;
using Microsoft.Graphics.Canvas.UI;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace ChessGUI.Views
{
    public sealed partial class BoardPage : Page
    {
        public BoardViewModel ViewModel { get; } = new BoardViewModel();

        public BoardPage()
        {
            InitializeComponent();
        }

        private void CanvasAnimatedControl_Draw(Microsoft.Graphics.Canvas.UI.Xaml.ICanvasAnimatedControl sender, Microsoft.Graphics.Canvas.UI.Xaml.CanvasAnimatedDrawEventArgs args)
        {
            ViewModel.Draw(sender, args);
        }

        private void CanvasAnimatedControl_CreateResources(CanvasAnimatedControl sender, CanvasCreateResourcesEventArgs args)
        {

        }

        private void CanvasAnimatedControl_SizeChanged(object sender, Windows.UI.Xaml.SizeChangedEventArgs e)
        {
            ViewModel.Scale(e.NewSize);
        }

        private void CanvasAnimatedControl_PointerMoved(object sender, PointerRoutedEventArgs e)
        {
            var pos = e.GetCurrentPoint(sender as CanvasAnimatedControl).Position;
            ViewModel.MouseMoved(pos);
        }
    }
}
