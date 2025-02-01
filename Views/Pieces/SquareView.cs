using TetrisGame.Utils;

namespace TetrisGame.Views.Pieces
{
    public class SquareView(Point position, Color color)
    {
        private const int SquareSize = GameConstants.BlockSize - 1; // Adjust to leave space for black lines

        public Point Position { get; } = position;
        public Color Color { get; } = color;

        public void Draw(Graphics graphics)
        {
            var rect = new Rectangle(Position.X, Position.Y, SquareSize, SquareSize);

            using var brush = new SolidBrush(Color);
            graphics.FillRectangle(brush, rect);
            graphics.DrawRectangle(Pens.Black, rect); // Ensures the border is visible
        }
    }
}