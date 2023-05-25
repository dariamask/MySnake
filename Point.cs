using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake
{
    internal class Point
    {
        internal int X { get; set; }
        internal int Y { get; set; }
        internal char Symbol { get; set; }
        internal ConsoleColor Color { get; set; }
        public Point() { }
        public Point(int x, int y) 
        {
            X = x;
            Y = y;
        }

        // ?
        public override bool Equals(object o) =>
            o.ToString() == this.ToString();
        internal void Print()
        {
            Console.SetCursorPosition(X, Y);
            Console.ForegroundColor = Color;
            Console.Write(Symbol);
        }
        internal void Delete()
        {
            Console.SetCursorPosition(X, Y);
            Console.Write(" ");
        }   
    }
}
