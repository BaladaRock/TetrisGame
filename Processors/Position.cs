namespace TetrisGame.Processors;

public readonly struct Position(byte x, byte y)
{
    public byte X => x;

    public byte Y => y;
}