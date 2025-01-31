namespace TetrisGame.Views.ColoredSquare
{
    public class ColouredSquare
    {
        public Point Position { get; set; }
        public Color Color { get; set; }

        public ColouredSquare(Point position, Color color)
        {
            Position = position;
            Color = color;
        }

        public void Draw(Graphics graphics)
        {
            const int squareSize = 20;
            var rect = new Rectangle(Position.X * squareSize, Position.Y * squareSize, squareSize, squareSize);
            using var brush = new SolidBrush(Color);
            graphics.FillRectangle(brush, rect);
            graphics.DrawRectangle(Pens.Black, rect);
        }
    }
}