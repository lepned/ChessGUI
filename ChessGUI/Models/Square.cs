using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.UI;

namespace ChessGUI.Models
{
    public class Square
    {
        public Square(int size, Color color, Rect rect)
        {
            Size = size;
            Color = color;
            Rect = rect;
        }
        public int Size { get; set; }
        public Color Color { get; set; }
        public Rect Rect { get; set; }
        public int Rank { get; set; }
        public int File { get; set; }
    }
}
