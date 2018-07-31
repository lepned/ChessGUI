using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;

namespace ChessGUI.Models
{
    public class Chessboard
    {
        public double Height { get; set; }
        public double Width { get; set; }
        public double OffsetX { get; set; }
        public double OffsetY { get; set; }
        public List<Square> Squares { get; set; }
        public bool Updating { get; set; }
        public double SqSize { get; set; }
        public Chessboard(int width, int height)
        {
            Height = height;
            Width = width;
            OffsetX = 50;
            OffsetY = 50;
            CreateSquares();
        }

        private void CreateSquares()
        {
            Updating = true;
            Squares = new List<Square>();
            var minSize = Math.Min(Height - OffsetY, Width - OffsetX);
            SqSize = minSize / 8;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var startX = OffsetX/2 + SqSize * j;
                    var startY = OffsetY/2 + SqSize * i;
                    var rect = new Rect(startX, startY, SqSize, SqSize);
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                        {
                            var sq = new Square(SqSize, Colors.Wheat, rect)
                            {
                                Rank = i,
                                File = j
                            };
                            Squares.Add(sq);
                        }
                        else
                        {
                            var sq = new Square(SqSize, Colors.DarkGoldenrod, rect)
                            {
                                Rank = i,
                                File = j
                            };
                            Squares.Add(sq);
                        }
                    }
                    else
                    {
                        if (j % 2 == 0)
                        {
                            var sq = new Square(SqSize, Colors.DarkGoldenrod, rect)
                            {
                                Rank = i,
                                File = j
                            };
                            Squares.Add(sq);

                        }
                        else
                        {
                            var sq = new Square(SqSize, Colors.Wheat, rect)
                            {
                                Rank = i,
                                File = j
                            };
                            Squares.Add(sq);
                        }
                    }
                }
            }
            Updating = false;
        }

        internal void ScaleTo(double width, double height)
        {
            var scaleWidth = Width / width;
            var scaleHeight = height / height;
            if (!Updating)
            {
                Width = width;
                Height = height;
                OffsetX = OffsetX * scaleWidth;
                OffsetY = OffsetY * scaleHeight;
                CreateSquares();
            }
        }
        
    }

}
