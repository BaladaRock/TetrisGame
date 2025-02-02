namespace TetrisGame.Processors;

public readonly record struct Position(int XPosition, int YPosition)
{
    public int X => XPosition;

    public int Y => YPosition;
}