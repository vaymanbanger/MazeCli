using MazeCli.Extensions;
using MazeCli.Models;
using MazeCli.Models.Enums;
using MazeCli.Services;

namespace MazeCli;

class Program
{
    private static void Main(string[] args)
    {
        var maze = MazeGenerator.GenerateMaze(57, 29);
        MovementUser(maze);
        Console.ReadKey();
    }

    /// <summary>
    /// Вывод лабиринта
    /// </summary>
    private static void Display(Maze maze, Coordinate playerPos)
    {
        for (var row = 0; row < maze.Height; row++)
        {
            for (var col = 0; col < maze.Width; col++)
            {
                var coord = new Coordinate(row, col);
                var state = maze[coord];
                var ch = state switch
                {
                    State.Wall => '▒',
                    State.Empty => ' ',
                    _ => 'n'
                };
                if (row == playerPos.Row && col == playerPos.Column)
                {
                    Console.Write('†');
                    continue;
                }
                Console.Write(ch);
            }
            Console.WriteLine();
        }
    }

    /// <summary>
    /// Передвижение игрока
    /// </summary>
    private static void MovementUser(Maze maze)
    {
        var playerPos = new Coordinate(1, 1);
        Display(maze,playerPos);
        while (playerPos.Row != 0 || playerPos.Column != 0)
        {
            var newPos = playerPos;
            switch (Console.ReadKey(true).Key)
            {
                case ConsoleKey.W:
                    newPos.Row -= 2;
                    break;
                case ConsoleKey.A:
                    newPos.Column -= 2;
                    break;
                case ConsoleKey.S:
                    newPos.Row += 2;
                    break;
                case ConsoleKey.D:
                    newPos.Column += 2;
                    break;
                case ConsoleKey.Q:
                    Environment.Exit(0);
                    break;
            }
            if (!maze.CheckCollision(playerPos, newPos))
            {
                playerPos = newPos;
                Display(maze,playerPos);
            }
        }
    }
}