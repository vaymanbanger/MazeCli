using MazeCli.Extensions;
using MazeCli.Models;
using MazeCli.Models.Enums;

namespace MazeCli.Services;

/// <summary>
/// Класс для генерации лабиринта
/// </summary>
public static class MazeGenerator
{
    /// <summary>
    /// Генерация лабиринта с начальной точки
    /// </summary>
    public static Maze GenerateMaze(int width, int height)
    {
        var maze = new Maze(width, height);
        var start = new Coordinate(1, 1);
        maze[start] = State.Empty;
        var cellsToVisit = maze.GetFrontiers(start).ToList();
        while (cellsToVisit.Count > 0)
        {
            var random = Random.Shared.Next(cellsToVisit.Count);
            var frontierToVisit = cellsToVisit[random];
            if (maze[frontierToVisit.ToCell] == State.Wall)
            {
                maze.VisitFrontiers(frontierToVisit.FromCell, frontierToVisit.ToCell);
                var frontiers = maze.GetFrontiers(frontierToVisit.ToCell);
                cellsToVisit.AddRange(frontiers);
            }

            cellsToVisit.RemoveAt(random);
        }
        GenerateFinish(maze);

        return maze;
    }
    
    /// <summary>
    /// Метод для генерации финиша
    /// </summary>
    private static void GenerateFinish(Maze maze)
    {
        var vertical = (maze.Height - 2) / 2;
        var random = Random.Shared.Next(vertical);
        var row = random * 2 + 1;
        var coord =  new Coordinate(row, maze.Width - 1);
        maze[coord] = State.Empty;
        maze.FinishPosition = coord;
    }
}