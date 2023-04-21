namespace MySnake;

internal class PlayingField
{
    internal Point Frame { get; set; }
    internal int Height { get; set; }
    internal int Width { get; set; }

    public PlayingField(int height, int width)
    {
        Height = height;
        Width = width;
        Frame = new Point(PointState.FieldBorder);
    }
    internal void Print()
    {
        DrawBorders(Height, DefaultSettings.MapStartHeight);
        DrawBorders(Height, Height);
        DrawBorders(Width, DefaultSettings.MapStartWidth, mirrored: true);
        DrawBorders(Width, Width, mirrored: true);
    }

    private void DrawBorders(int fieldSize, int oppositeSide, bool mirrored = false)
    {
        for (int i = 1; i <= fieldSize; i++)
        {
            Frame.X = i;
            Frame.Y = oppositeSide;

            if (mirrored)
                (Frame.X, Frame.Y) = (Frame.Y, Frame.X);

            Frame.Print();
        }
    }
}