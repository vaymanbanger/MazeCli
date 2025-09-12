using MazeCli.Extensions;
using MazeCli.Models;

namespace MazeCli.Services;

/// <summary>
/// Класс для нахождения пути до финиша
/// </summary>
public class PathFinder
{
    /// <summary>
    /// Нахождение пути до финиша
    /// </summary>
    public static List<Coordinate> FindPath(Maze maze, Coordinate start)
    {
        var finish = maze.FinishPosition;
        var frontiers = maze.GetFrontiers(start);
        var neighbours = GetCoordinate(frontiers);
        var path = new List<Coordinate>
        {
            new(start.Row - 2, start.Column),
            new(start.Row + 2, start.Column),
            new(start.Row, start.Column - 2),
            new(start.Row, start.Column + 2),
        };
        foreach (var neighbour in neighbours)
        {
            if (!maze.CheckCollision(start, neighbour))
            {
                
            }
        }
        return path;
    }

    private static IEnumerable<Coordinate> GetCoordinate(IEnumerable<CellToVisit> frontiers)
    => frontiers.Select(frontier => frontier.FromCell);
}