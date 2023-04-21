using static MySnake.DefaultSettings;

namespace MySnake;

internal class GameControls
{
    internal static int Score { get; set; }
    internal static bool GameOver { get; set; }
    internal Directions Direction { get; set; }
    internal static string[] Menu { get; set; }
    internal static int Index { get; set; }


    internal static void IsGameOver(Snake snake)
    {
        if (snake.Head.X == MapStartWidth)
            GameOver = true;

        if (snake.Head.X == MapWidth - 3)
            GameOver = true;

        if (snake.Head.Y == MapStartHeight)
            GameOver = true;

        if (snake.Head.Y == MapHeight - 2)
            GameOver = true;

        if (snake.Body.Any(b => b == snake.Head))
            GameOver = true;
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

        Console.ReadKey();

    }
    internal static void StartMenu(Snake snake)
    {
        Console.Clear();
        GameControls.GameOver = false;
        GameControls.Score = 0;

        Menu = new string[] { "Начать игру", "Выйти из игры" };

        DisplayMenu();

        while (!GameOver)
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
        if (GameOver) return;

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
    internal static void ChooseMainMenuItem(Snake snake)
    {
        if (!Console.KeyAvailable || GameOver)
        {
            if (Index > Menu.Length - 1) 
                Index = 0;

            if (Index < 0) 
                Index = Menu.Length - 1;

            return;
        }

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

        while (!GameControls.GameOver)
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
        }
    }
}