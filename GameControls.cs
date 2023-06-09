﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySnake
{
    internal class GameControls
    {
        internal static int Score { get; set; }
        internal static bool GameOver { get; set; }
        internal Directions Direction { get; set; }
        internal static string[] Menu { get; set; }
        internal static int Index { get; set; }


        internal static void IsGameOver(Snake snake)
        {
            if (snake.Head.X == 1 || snake.Head.X == 30 ||
                snake.Head.Y == 2 || snake.Head.Y == 31)
            {
                GameOver = true;

            }
            if (snake.Body.Any(b => b.X == snake.Head.X && b.Y == snake.Head.Y))
            {
                GameOver = true;
            }
        }

        internal static void FinalScoreDisplay()
        {
            Index = 0;
            string[] yourScore = { "Игра окончена.", $"Твой счёт {Score}." };
            Console.ForegroundColor = ConsoleColor.White;

            for (int i = 0; i < yourScore.Length; i++)
            {
                Console.SetCursorPosition(10, 12 + i);
                Console.WriteLine(yourScore[i]);
            }
            Thread.Sleep(2000);
            
        }
        internal static void StartMenu(Snake snake)
        {
            Console.Clear();
            GameControls.GameOver = false;
            GameControls.Score = 0;

            Menu = new string[] { "Начать игру", "Выйти из игры" };

            DisplayMenu();

            while (GameOver == false)
            {
                ChooseMainMenuItem(snake);
                LightUpMenuItem(snake);
            }
        }
        internal static void DisplayMenu()
        {
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < Menu.Length; i++)
            {
                Console.SetCursorPosition(8, 12 + i);
                Console.WriteLine($"{Menu[i]}");
            }
        }
        internal static void ClearMenu()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            for (int i = 0; i < Menu.Length; i++)
            {
                Console.SetCursorPosition(8, 12 + i);
                Console.WriteLine($"  {Menu[i]}");
                Console.WriteLine();
            }
        }
        internal static void LightUpMenuItem(Snake snake)
        {
            if (GameOver == false)
            {
                for (int i = 0; i < Menu.Length; i++)
                {
                    Console.SetCursorPosition(8, 12 + i);
                    if (i == Index)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine($"> {Menu[i]}");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.WriteLine($"  {Menu[i]}");
                    }
                }
            }
        }
        internal static void ChooseMainMenuItem(Snake snake)
        {
            if (Console.KeyAvailable && GameOver == false)
            {
                switch (Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        Index--;
                        break;
                    case ConsoleKey.DownArrow:
                        Index++;
                        break;
                    case ConsoleKey.Enter:
                        switch (Index)
                        {
                            case 0:
                                ClearMenu();
                                StartTheGame();
                                Console.Clear();
                                FinalScoreDisplay();
                                break;
                            case 1:
                                ClearMenu();
                                Environment.Exit(0);
                                break;
                        }
                        break;
                }
            }

            if (Index > Menu.Length - 1)
            {
                Index = 0;
            }
            if (Index < 0)
            {
                Index = Menu.Length - 1;
            }
        }

        internal static void ScoreDisplay()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.SetCursorPosition(0, 0);           
            Console.WriteLine($" Текущий счёт: {Score}");
        }

        internal static void StartTheGame()
        {
            PlayingField playgroundField = new PlayingField(30, 30);
            playgroundField.Print();

            Snake snake = new Snake();
            snake.SnakeBuilder();
            Food food = new Food();

            while (GameControls.GameOver == false)
            {
                GameControls.ScoreDisplay();

                Thread.Sleep(50);
                snake.ReadInput();
                food.Omnomnom(snake);
                food.Spawn(snake);
                snake.Clear();
                snake.Move(snake.Direction);
                snake.Head.Print();
                GameControls.IsGameOver(snake);

                if (GameControls.GameOver == true)
                {
                    break;
                }
            }
        }
    }
}
