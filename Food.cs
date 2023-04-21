using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake
{
    internal class Food
    {
        internal Point TastyFood { get; set; }
        internal bool WasEaten { get; set; }
        public Food ()
        {
            TastyFood = new Point ();  
            TastyFood.Symbol = 'O';
            TastyFood.Color = ConsoleColor.Yellow;
            WasEaten = true;
            Spawn();
        }
        internal void Spawn(Snake snake)
        {
            if (WasEaten == true)
            {            
                Random randomX = new Random();
                while (true)
                {
                    TastyFood.X = randomX.Next(2, 30);
                    if (TastyFood.X != snake.Head.X &&
                        snake.Body.Any(b => b.X != TastyFood.X))
                    {
                        break;
                    }
                        
                }
                Random randomY = new Random();
                while (true)
                {
                    TastyFood.Y = randomY.Next(3, 31);
                    
                    if (TastyFood.Y != snake.Head.Y &&
                        snake.Body.Any(b => b.Y != TastyFood.Y))
                    {
                        break;
                    }
                }              
                Console.SetCursorPosition(TastyFood.X, TastyFood.Y);
                TastyFood.Print();
                WasEaten=false;
            }
        }
        internal void Spawn()
        {
            if (WasEaten == true)
            {
                Random randomX = new Random();
                TastyFood.X = randomX.Next(2, 30);           
                Random randomY = new Random();
                TastyFood.Y = randomY.Next(3, 31);

                Console.SetCursorPosition(TastyFood.X, TastyFood.Y);
                TastyFood.Print();
                WasEaten = false;
            }
        }
        internal void Omnomnom(Snake snake)
        {
            if (snake.Head.X == TastyFood.X && snake.Head.Y == TastyFood.Y)
            {
                snake.GetLonger();
                GameControls.Score++;
                Spawn(snake);
                WasEaten = true;
            }
            else
            {
                WasEaten = false;
            }
        }
    }
}
