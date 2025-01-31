namespace TetrisGame.Views.Pieces
{
    using ColoredSquare;
    public abstract class Piece
    {
        public List<ColouredSquare> Squares { get; set; }
        public Color Color { get; set; }

        protected Piece()
        {
            Squares = [];
            Color = Color.Red;  // Default color
        }

        public abstract void SetSquares(Point startPosition);

        public virtual void Draw(Graphics g)
        {
            const int blockSize = 30;
            const int blockSpacing = 0;

            foreach (var square in Squares)
            {
                var x = square.Position.X * (blockSize + blockSpacing);
                var y = square.Position.Y * (blockSize + blockSpacing);

                g.FillRectangle(new SolidBrush(square.Color), x, y, blockSize, blockSize);
                g.DrawRectangle(Pens.Black, x, y, blockSize, blockSize);
            }
        }

        public abstract void Rotate();
    }
}