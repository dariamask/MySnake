namespace MySnake;

internal class Snake
{
    internal Point Head { get; set; }
    public Queue<Point> Body { get; set; } = new();
    public Directions Direction { get; set; }

    public Snake()
    {
        Head = new Point(DefaultSettings.SnakeX, DefaultSettings.SnakeY, PointState.SnakeHead);
    }
    internal void SnakeBuilder()
    {
        Head.Print();

        var currenrCursorPosition = Console.GetCursorPosition();

        for (int i = DefaultSettings.BodySize; i > 0; i--)
        {
            var startX = currenrCursorPosition.Item1 - i - 1;
            var startY = currenrCursorPosition.Item2;

            Point bodyPoint = new Point(startX, startY, PointState.SnakeBody);
            Body.Enqueue(bodyPoint);
            bodyPoint.Print();
        }
    }

    internal void Clear()
    {
        Point newBodyPoint = new Point(Head.X, Head.Y, PointState.SnakeBody);
        Body.Enqueue(newBodyPoint);
        Point lastPoint = Body.Dequeue();
        lastPoint.Delete();

        newBodyPoint.Print();
    }

    internal void Move(Directions direction) => _ = direction switch
    {
        Directions.Right => Head.X++,
        Directions.Left => Head.X--,
        Directions.Up => Head.Y--,
        Directions.Down => Head.Y++,
    };

    internal void GetLonger()
    {
        Point dotForGrowingUp = new Point(PointState.SnakeBody);
        Body.Enqueue(dotForGrowingUp);
        dotForGrowingUp.Print();

    }

    internal void ReadInput()
    {
        if (!Console.KeyAvailable)
            return;

        Direction = Console.ReadKey(true).Key switch
        {
            ConsoleKey.RightArrow when Direction is not Directions.Left => Directions.Right,
            ConsoleKey.LeftArrow when Direction is not Directions.Right => Directions.Left,
            ConsoleKey.UpArrow when Direction is not Directions.Down => Directions.Up,
            ConsoleKey.DownArrow when Direction is not Directions.Up => Directions.Down,
            _ => Direction,
        };
    }
}