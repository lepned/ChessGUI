using System;
using System.Numerics;
using ChessGUI.Helpers;
using ChessGUI.Models;
using Microsoft.Graphics.Canvas.UI.Xaml;
using Windows.Foundation;
using Windows.UI;
using Windows.UI.Xaml.Media;

namespace ChessGUI.ViewModels
{
    public class BoardViewModel : Observable
    {
        public BoardViewModel()
        {
            ChessBoard = new Chessboard(500,500);
        }
        public CanvasAnimatedControl CanvasControl { get; set; }
        public Chessboard ChessBoard { get; set; }


        internal void Draw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            if (CanvasControl == null)
                CanvasControl = sender as CanvasAnimatedControl;
            var ds = args.DrawingSession;
            //ds.FillRectangle(new Rect(new Point(0,0),new Point(500,500)), Colors.Aquamarine);
            //ds.DrawCircle(new Vector2(250), 200, Colors.Black);
            foreach (var item in ChessBoard.Squares)
            {
                ds.FillRectangle(item.Rect, item.Color);
                ds.DrawRectangle(item.Rect, Colors.Aquamarine);
                var txt = $"{item.File},{item.Rank}";
                //ds.DrawText(txt, new Vector2((float)item.Rect.X + item.Size/4, (float)item.Rect.Y + item.Size/4), Colors.Black);
            }
        }
    }
}
