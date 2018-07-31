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
        public int Height { get; set; }
        public int Width { get; set; }
        public int OffsetX { get; set; }
        public int OffsetY { get; set; }
        public List<Square> Squares { get; set; }
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
            Squares = new List<Square>();
            var minSize = Math.Min(Height - OffsetY, Width - OffsetX);
            var sqSize = minSize / 8;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    var startX = OffsetX + sqSize * j;
                    var startY = OffsetY + sqSize * i;
                    var rect = new Rect(startX, startY, sqSize, sqSize);
                    if (i % 2 == 0)
                    {
                        if (j % 2 == 0)
                        {
                            var sq = new Square(sqSize, Colors.Wheat, rect)
                            {
                                Rank = i,
                                File = j
                            };
                            Squares.Add(sq);
                        }
                        else
                        {
                            var sq = new Square(sqSize, Colors.DarkGoldenrod, rect)
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
                            var sq = new Square(sqSize, Colors.DarkGoldenrod, rect)
                            {
                                Rank = i,
                                File = j
                            };
                            Squares.Add(sq);
                            
                        }
                        else
                        {
                            var sq = new Square(sqSize, Colors.Wheat, rect)
                            {
                                Rank = i,
                                File = j
                            };
                            Squares.Add(sq);
                        }
                    }
                }
            }
        }
    }

}
