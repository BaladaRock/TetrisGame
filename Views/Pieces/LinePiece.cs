namespace TetrisGame.Views.Pieces
{
    using ColoredSquare;
    public class LinePiece : Piece
    {
        public LinePiece(Point startPosition)
        {
            SetSquares(startPosition);
        }

        public sealed override void SetSquares(Point startPosition)
        {
            Squares.Clear();
            for (var i = 0; i < 4; i++)
            {
                Squares.Add(new ColoredSquare(new Point(startPosition.X + i, startPosition.Y), Color.Cyan));
            }
        }

        public override void Rotate()
        {
            var origin = Squares[0].Position;
            foreach (var square in Squares)
            {
                var x = square.Position.X - origin.X;
                var y = square.Position.Y - origin.Y;
                square.Position = new Point(origin.X - y, origin.Y + x);
            }
        }
    }
}