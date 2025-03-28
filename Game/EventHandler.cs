namespace Game;

public delegate void ArrowHandler();

public class EventLoop
{
    public void Run(ArrowHandler left, ArrowHandler right, ArrowHandler up, ArrowHandler down)
    {
        while (true)
        {
            var key = Console.ReadKey(true);
            switch (key.Key)
            {
                case ConsoleKey.LeftArrow:
                    left();
                    break;
                case ConsoleKey.RightArrow:
                    right();
                    break;
                case ConsoleKey.UpArrow:
                    up();
                    break;
                case ConsoleKey.DownArrow:
                    down();
                    break;
            }
        }
    }
}
