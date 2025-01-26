namespace TetrisGame.Views
{
    using System.Collections.Generic;

    public abstract class Piece
    {
        public List<Square> Squares { get; set; }

        protected Piece()
        {
            Squares = new List<Square>();
        }

        public abstract void SetSquares(Point startPosition);

        public void Draw(Graphics g, int blockSize, int blockSpacing)
        {
            foreach (var square in Squares)
            {
                square.Draw(g, blockSize, blockSpacing);
            }
        }

        public abstract void Rotate();
    }
}