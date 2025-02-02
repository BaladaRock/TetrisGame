namespace TetrisGame.Processors.Implementations
{
    internal class TPiece : Piece
    {
        public TPiece(int gameWidth, int gameHeight, byte pieceSize)
            : base(gameWidth, gameHeight, pieceSize)
        {
            Colour = Colour.Purple;
            DefineShape();
        }

        protected sealed override void DefineShape()
        {
            Squares.Clear();

            switch (RotationState)
            {
                case 0: // Default spawn (T-shape facing up)
                    Squares.Add(new Square(new Position(Position.X, Position.Y)));      // Center
                    Squares.Add(new Square(new Position(Position.X - 1, Position.Y)));  // Left
                    Squares.Add(new Square(new Position(Position.X + 1, Position.Y)));  // Right
                    Squares.Add(new Square(new Position(Position.X, Position.Y + 1)));  // Bottom
                    break;

                case 1: // 90° (Clockwise)
                    Squares.Add(new Square(new Position(Position.X, Position.Y)));      // Center
                    Squares.Add(new Square(new Position(Position.X, Position.Y - 1)));  // Top
                    Squares.Add(new Square(new Position(Position.X, Position.Y + 1)));  // Bottom
                    Squares.Add(new Square(new Position(Position.X + 1, Position.Y)));  // Right
                    break;

                case 2: // 180° (Upside-down)
                    Squares.Add(new Square(new Position(Position.X, Position.Y)));      // Center
                    Squares.Add(new Square(new Position(Position.X - 1, Position.Y)));  // Left
                    Squares.Add(new Square(new Position(Position.X + 1, Position.Y)));  // Right
                    Squares.Add(new Square(new Position(Position.X, Position.Y - 1)));  // Top
                    break;

                case 3: // 270° (Counterclockwise)
                    Squares.Add(new Square(new Position(Position.X, Position.Y)));      // Center
                    Squares.Add(new Square(new Position(Position.X, Position.Y - 1)));  // Top
                    Squares.Add(new Square(new Position(Position.X, Position.Y + 1)));  // Bottom
                    Squares.Add(new Square(new Position(Position.X - 1, Position.Y)));  // Left
                    break;
            }
        }

        public override void Rotate()
        {
            var oldRotation = RotationState;
            RotationState = (RotationState + 1) % 4;
            DefineShape();

            if (!ValidateRotation())
            {
                RotationState = oldRotation;
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
            DefineShape(); // Ensures the squares are placed correctly
            ColourSquares();
        }
    }
}
