using System;
using System.Linq;
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
            ChessBoard = new Chessboard(500, 500);
        }
        public CanvasAnimatedControl CanvasControl { get; set; }
        public Chessboard ChessBoard { get; set; }


        internal void Draw(ICanvasAnimatedControl sender, CanvasAnimatedDrawEventArgs args)
        {
            if (CanvasControl == null)
                CanvasControl = sender as CanvasAnimatedControl;
            var ds = args.DrawingSession;
            if (!ChessBoard.Updating)
            {
                foreach (var item in ChessBoard.Squares)
                {
                    ds.FillRectangle(item.Rect, item.Color);
                    ds.DrawRectangle(item.Rect, Colors.Aquamarine);
                    //ds.DrawText(item.ToString(), new Vector2((float)item.Rect.X + item.Size/4, (float)item.Rect.Y + item.Size/4), Colors.Black);
                }
            }
        }


        internal void MouseMoved(Point pos)
        {
            var sq = ChessBoard.Squares.FirstOrDefault(e =>
                             e.Rect.X <= pos.X &&
                             (e.Rect.X + ChessBoard.SqSize) >= pos.X &&
                             e.Rect.Y <= pos.Y &&
                             (e.Rect.Y + ChessBoard.SqSize) >= pos.Y
                         );
            if (sq != null)
            {

            }

        }



        internal void Scale(Size newSize)
        {
            var width = newSize.Width;
            var heigth = newSize.Height;
            ChessBoard.ScaleTo(width, heigth);
        }
    }
}
