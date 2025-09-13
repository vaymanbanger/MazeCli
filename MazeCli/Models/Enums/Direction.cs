namespace MazeCli.Models.Enums;

/// <summary>
/// Перечисления для указания направления по битовой маске
/// </summary>
[Flags]
public enum Direction
{
    North = 1,
    South = 1 << 1,
    East = 1 << 2,
    West = 1 << 3
}