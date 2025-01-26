namespace TetrisGame.Views
{
    public class Square
    {
        public Point Position { get; set; }
        public Color Color { get; set; }

        public Square(Point position, Color color)
        {
            Position = position;
            Color = color;
        }

        public void Draw(Graphics g, int blockSize, int blockSpacing)
        {
            int x = Position.X * (blockSize + blockSpacing);
            int y = Position.Y * (blockSize + blockSpacing);
            g.FillRectangle(new SolidBrush(Color), x, y, blockSize, blockSize);
            g.DrawRectangle(Pens.Black, x, y, blockSize, blockSize);
        }
    }
}