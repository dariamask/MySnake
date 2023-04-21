using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake
{
    internal class Snake
    {
        internal Point Head { get; set; }
        public Queue<Point> Body { get; set; }
        public Directions Direction { get; set; }

        public Snake()
        {
            Head = new Point(DefaultSettings.SnakeX, DefaultSettings.SnakeY);
            Head.Symbol = '▓';
            Head.Color = ConsoleColor.Green;
            Body = new Queue<Point>();
        }
        internal void SnakeBuilder()
        {
            Head.Print();
 
            var currenrCursorPosition = Console.GetCursorPosition();
            for (int i = DefaultSettings.BodySize; i > 0; i--)
            {
                Point bodyPoint = new Point(currenrCursorPosition.Item1 - i - 1, currenrCursorPosition.Item2);
                bodyPoint.Symbol = '░';
                bodyPoint.Color = ConsoleColor.White;
                Body.Enqueue(bodyPoint);
                bodyPoint.Print();
            }
        }

        internal void Clear()
        {
            Point newBodyPoint = new Point();
            newBodyPoint.X = Head.X;
            newBodyPoint.Y = Head.Y;
            newBodyPoint.Symbol = '░';
            newBodyPoint.Color = ConsoleColor.White;

            Body.Enqueue(newBodyPoint);
            Point lastPoint = Body.Dequeue();
            lastPoint.Delete();

            newBodyPoint.Print();
        }

        internal void Move(Directions direction)
        {
            if (direction == Directions.Right)
            {
                Head.X++;
            }
            else if (direction == Directions.Left)
            {
                Head.X--;
            }
            else if (direction == Directions.Up)
            {
                Head.Y--;
            }
            else if (direction == Directions.Down)
            {
                Head.Y++;
            }
        }

        internal void GetLonger()
        {
            Point dotForGrowingUp = new Point();
            dotForGrowingUp.Symbol = '░';
            dotForGrowingUp.Color = ConsoleColor.White;
            Body.Enqueue(dotForGrowingUp);
            dotForGrowingUp.Print();

        }

        internal void ReadInput()
        {
            if (Console.KeyAvailable)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.RightArrow:
                        if (Direction != Directions.Left)
                        {
                            Direction = Directions.Right;
                        }
                        break;           
                        
                    case ConsoleKey.LeftArrow:
                        if (Direction != Directions.Right)
                        {
                            Direction = Directions.Left;                           
                        }            
                        break;

                    case ConsoleKey.UpArrow:
                        if (Direction != Directions.Down)
                        {
                            Direction = Directions.Up;
                        }                       
                        break;

                    case ConsoleKey.DownArrow:
                        if (Direction != Directions.Up)
                        {
                            Direction = Directions.Down;
                        }                        
                        break;

                    default:
                        Direction = this.Direction;
                        break;
                }
            }
        }
    }
}
