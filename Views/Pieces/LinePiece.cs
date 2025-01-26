namespace TetrisGame.Views
{
    public class LinePiece : Piece
    {
        public LinePiece(Point startPosition)
        {
            SetSquares(startPosition);
        }

        public override void SetSquares(Point startPosition)
        {
            Squares.Clear();
            for (int i = 0; i < 4; i++)
            {
                Squares.Add(new Square(new Point(startPosition.X + i, startPosition.Y), Color.Cyan));
            }
        }

        public override void Rotate()
        {
            // Rotate logic for the line piece
        }
    }
}