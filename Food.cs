namespace MySnake;

internal class Food
{
    internal Point TastyFood { get; set; }
    internal bool WasEaten { get; set; }
    private int RandomX => Random.Shared.Next(2, 30);
    private int RandomY => Random.Shared.Next(3, 31);
    public Food()
    {
        TastyFood = new Point(PointState.Food);
        WasEaten = true;
        Spawn();
    }
    internal void Spawn(Snake snake)
    {
        if (!WasEaten) return;

        while (TastyFood == snake.Head || snake.Body.Any(segment => segment == TastyFood))
        {
            TastyFood.Y = RandomY;
            TastyFood.X = RandomX;
        }

        Console.SetCursorPosition(TastyFood.X, TastyFood.Y);
        TastyFood.Print();

        WasEaten = false;
    }
    internal void Spawn()
    {
        if (!WasEaten) return;

        TastyFood.X = RandomX;
        TastyFood.Y = RandomY;

        Console.SetCursorPosition(TastyFood.X, TastyFood.Y);
        TastyFood.Print();

        WasEaten = false;
    }
    internal void Omnomnom(Snake snake)
    {
        if (snake.Head != TastyFood)
        {
            WasEaten = false;
            return;
        }

        snake.GetLonger();
        GameControls.Score++;
        Spawn(snake);
        WasEaten = true;
    }
}