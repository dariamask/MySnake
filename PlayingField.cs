using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake
{
    internal class PlayingField
    {
        internal Point Frame { get; set; }
        internal int Height { get; set; }
        internal int Width { get; set; }
        internal int RowsFromTop { get; }
        internal int ColsFromRight { get; }

        public PlayingField (int height, int width)
        {
            Height = height;
            Width = width;
            Frame = new Point ();
            Frame.Color = ConsoleColor.White;
            RowsFromTop = 2;
            ColsFromRight = 1;
        }
        internal void Print()
        {
            for (int i = 0; i < Height; i++)
            {
                Frame.X = i + ColsFromRight;
                Frame.Y = RowsFromTop;
                Frame.Symbol = '█';
                Frame.Print();
                Frame.X = i + ColsFromRight;
                Frame.Y = Height - 1 + RowsFromTop;
                Frame.Print();
            }
            for (int i = 1; i < Width; i++)
            {
                Frame.X = ColsFromRight;
                Frame.Y = i + RowsFromTop;
                Frame.Symbol = '█';
                Frame.Print();
                Frame.X = Width - 1 + ColsFromRight;
                Frame.Y = i + RowsFromTop;
                Frame.Print();
            }
        }
    }
}
