using MazeCli.Models.Enums;

namespace MazeCli.Models;

/// <summary>
/// Лабиринт
/// </summary>
public class Maze(int width, int height)
{
    private readonly State[,] cells = new State[height, width];

    public int Width { get; set; } = width;
    public int Height { get; set; } = height;
    
    public Coordinate FinishPosition { get; set; } = new Coordinate(0, 0);

    public State this[Coordinate coord]
    {
        get => cells[coord.Row, coord.Column];
        set => cells[coord.Row, coord.Column] = value;
    }
}