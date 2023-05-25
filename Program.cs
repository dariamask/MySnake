using static System.Console;

namespace MySnake
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SetWindowSize();

            while (true)
            {
                // Зачем здесь создается объект snake?  
                Snake snake = new Snake();

                GameControls.StartMenu(snake);
            }
        }
        static void SetWindowSize()
        {
            Console.SetWindowSize(DefaultSettings.MapHeight, DefaultSettings.MapWidth);
           
            Console.CursorVisible = false;
        }
    }
}