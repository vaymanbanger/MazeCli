namespace MazeCli.Models;

/// <summary>
/// Координаты x,y в лабиринте
/// </summary>
public struct Coordinate(int row, int column)
{
    public int Row { get; set; } = row;

    public int Column { get; set; } = column;
    
}