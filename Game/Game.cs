namespace Game;

public class Game
{
    private const int MapHeight = 20;
    private const int MapWidth = 80;
    private const string LevelFile = "/home/zst/spbu/lesson/game/game/level.dat";

    private readonly char[,] map = new char[MapHeight, MapWidth];
    private (int, int) playerPosition;

    public Game()
    {
        this.LoadMap();
        Console.Clear();
        this.PrintMap();
    }

    private void LoadMap()
    {
        if (!File.Exists(LevelFile))
        {
            throw new FileNotFoundException("Can't load game level");
        }

        var level = File.ReadLines(LevelFile);

        int row = 0;
        foreach (var line in level)
        {
            if (line.Length != MapWidth)
            {
                throw new Exception("Invalid map");
            }

            for (int i = 0; i < MapWidth; i++)
            {
                this.map[row, i] = line[i];
                if (line[i] == '@')
                {
                    this.playerPosition = (row, i);
                }
            }

            row++;
        }
    }

    private void PrintMap()
    {
        for (int i = 0; i < MapHeight; i++)
        {
            for (int j = 0; j < MapWidth; j++)
            {
                Console.Write(this.map[i, j]);
            }

            Console.WriteLine();
        }
    }

    public void playerMoveLeft()
    {
        var (x, y) = this.playerPosition;

        if (y == 0 || this.map[x, y - 1] != ' ')
        {
            return;
        }

        Console.SetCursorPosition(y, x);
        Console.Write(' ');
        Console.SetCursorPosition(y - 1, x);
        Console.Write('@');
        this.playerPosition = (x, y - 1);
        Console.SetCursorPosition(MapWidth, MapHeight);
    }

    public void playerMoveRight()
    {
        var (x, y) = this.playerPosition;

        if (y == MapWidth || this.map[x, y + 1] != ' ')
        {
            return;
        }

        Console.SetCursorPosition(y, x);
        Console.Write(' ');
        Console.SetCursorPosition(y + 1, x);
        Console.Write('@');
        this.playerPosition = (x, y + 1);
        Console.SetCursorPosition(MapWidth, MapHeight);
    }

    public void playerMoveUp()
    {
        var (x, y) = this.playerPosition;

        if (x == 0 || this.map[x - 1, y] != ' ')
        {
            return;
        }

        Console.SetCursorPosition(y, x);
        Console.Write(' ');
        Console.SetCursorPosition(y, x - 1);
        Console.Write('@');

        this.playerPosition = (x - 1, y);
        Console.SetCursorPosition(MapWidth, MapHeight);
    }

    public void playerMoveDown()
    {
        var (x, y) = this.playerPosition;

        if (x == MapHeight || this.map[x + 1, y] != ' ')
        {
            return;
        }

        Console.SetCursorPosition(y, x);
        Console.Write(' ');
        Console.SetCursorPosition(y, x + 1);
        Console.Write('@');
        this.playerPosition = (x + 1, y);
        Console.SetCursorPosition(MapWidth, MapHeight);
    }

}
