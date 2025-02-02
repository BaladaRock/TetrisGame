namespace TetrisGame.Processors.Implementations
{
    internal class LinePiece : Piece
    {
        public LinePiece(int gameWidth, int gameHeight, byte pieceSize)
            : base(gameWidth, gameHeight, pieceSize)
        {
            Colour = Colour.Blue;
            DefineShape();
        }

        protected sealed override void DefineShape()
        {
            Squares.Clear();

            if (RotationState is 0 or 2) // Horizontal
            {
                for (var i = 0; i < PieceSize; i++)
                {
                    Squares.Add(new Square(new Position(Position.X + i - 2, Position.Y)));
                }
            }
            else // Vertical
            {
                for (var i = 0; i < PieceSize; i++)
                {
                    Squares.Add(new Square(new Position(Position.X, Position.Y + i - 2)));
                }
            }
        }

        public override void Rotate()
        {
            var oldRotation = RotationState;
            RotationState = (RotationState + 1) % 4; // Rotate to the next state
            DefineShape();

            if (!ValidateRotation())
            {
                RotationState = oldRotation; // Undo rotation if invalid
                DefineShape();
            }

            UpdateSquares();
        }

        private bool ValidateRotation()
        {
            return Squares.TrueForAll(sq =>
                sq.Position.X is >= 0 and < 10 &&
                sq.Position.Y is >= 0 and < 20);
        }

        public override void UpdateSquares()
        {
            if (RotationState is 0 or 2) // Horizontal
            {
                for (var i = 0; i < Squares.Count; i++)
                {
                    Squares[i].Position = new Position(Position.X + i - 2, Position.Y);
                }
            }
            else  // Vertical
            {
                for (var i = 0; i < Squares.Count; i++)
                {
                    Squares[i].Position = new Position(Position.X, Position.Y + i - 2);
                }
            }

            ColourSquares();
        }
    }
}
