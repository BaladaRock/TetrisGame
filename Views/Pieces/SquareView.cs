namespace TetrisGame.Views.Pieces;

public sealed class SquareView(Point position, Color color)
{
    private const int BlockSize = 30;

    public void Fill(Graphics graphics)
    {
        using var brush = new SolidBrush(color);
        graphics.FillRectangle(brush, position.X * BlockSize, position.Y * BlockSize, BlockSize, BlockSize);
        graphics.DrawRectangle(Pens.Black, position.X * BlockSize, position.Y * BlockSize, BlockSize, BlockSize);
    }
}