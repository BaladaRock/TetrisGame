namespace TetrisGame.Processors;

public readonly struct Position(byte x, byte y)
{
    public (byte x, byte y) GetCoordinates()
    {
        return (x: x, y: y);
    }
}