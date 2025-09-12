namespace MazeCli.Models;

/// <summary>
/// Клетки для посещения
/// </summary>
public struct CellToVisit
{
    public Coordinate FromCell { get; set; }

    public Coordinate ToCell { get; set; }
}