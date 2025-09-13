using MazeCli.Models;
using MazeCli.Models.Enums;

namespace MazeCli.Extensions;

/// <summary>
/// Класс для метода расширений лабиринта
/// </summary>
public static class MazeExtensions
{
    /// <summary>
    /// Метод расширения для проверки коллизии стен лабиринта
    /// </summary>
    public static bool CheckCollision(this Maze maze, Coordinate first, Coordinate second)
    {
        if (second.Row < first.Row || second.Column < first.Column)
        {
            (first, second) = (second, first);
            if (first.Row == -1 || first.Column == -1)
            {
                return true;
            }
        }

        for (var row = first.Row; row < second.Row; row++)
        {
            var coord = new Coordinate(row, first.Column);
            if (maze[coord] == State.Wall)
            {
                return true;
            }
        }

        for (var col = first.Column; col < second.Column; col++)
        {
            var coords = new Coordinate(second.Row, col);
            if (maze[coords] == State.Wall)
            {
                return true;
            }
        }
        return false;
    }
    
    /// <summary>
    /// Метод расширения посещения соседних клеток
    /// </summary>
    public static void VisitFrontiers(this Maze maze, Coordinate first, Coordinate second)
    {
        maze[first] = State.Empty;
        maze[second] = State.Empty;
        if (second.Row < first.Row || second.Column < first.Column)
        {
            (first, second) = (second, first);
        }

        for (var row = first.Row; row < second.Row; row++)
        {
            var coord = new Coordinate(row, first.Column);
            maze[coord] = State.Empty;
        }

        for (var col = first.Column; col < second.Column; col++)
        {
            var coords = new Coordinate(second.Row, col);
            maze[coords] = State.Empty;
        }
    }
    
    /// <summary>
    /// Метод расширения для получения соседних клеток
    /// </summary>
    public static IEnumerable<CellToVisit> GetFrontiers(this Maze maze, Coordinate start)
    {
        var frontiers = new List<Coordinate>
        {
            new(start.Row - 2, start.Column),
            new(start.Row + 2, start.Column),
            new(start.Row, start.Column - 2),
            new(start.Row, start.Column + 2),
        };
        return frontiers
            .Where(x => x.Column > 0 && x.Column < maze.Width - 1 && x.Row > 0 && x.Row < maze.Height - 1)
            .Select(x => new CellToVisit
            {
                FromCell = start,
                ToCell = x
            }).ToList();
    }
}