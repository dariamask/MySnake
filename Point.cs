namespace MySnake;

internal class Point
{
    internal int X { get; set; }
    internal int Y { get; set; }
    internal char Symbol { get; set; }
    internal ConsoleColor Color { get; set; }
    public Point(PointState state) => SetAppearance(state);
    public Point(int x, int y, PointState state)
    {
        SetAppearance(state);
        X = x;
        Y = y;
    }
    public override bool Equals(object o) =>
        o.ToString() == ToString();

    public static bool operator ==(Point left, Point right) => left.X == right.X && left.Y == right.Y;
    public static bool operator !=(Point left, Point right) => left.X != right.X || left.Y != right.Y;

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

    private void SetAppearance(PointState state)
    {
        Action action = state switch
        {
            PointState.SnakeHead => SetSnakeHeadAppearance,
            PointState.SnakeBody => SetSnakeBodyAppearance,
            PointState.Food => SetFoodAppearance,
            PointState.FieldBorder => SetFieldBorderAppearance,
            _ => throw new ArgumentException(nameof(PointState))
        };

        action.Invoke();
    }

    private void SetSnakeHeadAppearance()
    {
        Symbol = '▓';
        Color = ConsoleColor.Green;
    }
    private void SetSnakeBodyAppearance()
    {
        Symbol = '░';
        Color = ConsoleColor.White;
    }
    private void SetFoodAppearance()
    {
        Symbol = 'O';
        Color = ConsoleColor.Yellow;
    }
    private void SetFieldBorderAppearance()
    {
        Symbol = '█';
        Color = ConsoleColor.White;
    }
}