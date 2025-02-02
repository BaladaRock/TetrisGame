namespace TetrisGame.Processors.Implementations.Pieces
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
                case 0: // Default spawn
                    Squares.Add(new Square(new Position(Position.X, Position.Y)));
                    Squares.Add(new Square(new Position(Position.X - 1, Position.Y)));
                    Squares.Add(new Square(new Position(Position.X + 1, Position.Y)));
                    Squares.Add(new Square(new Position(Position.X, Position.Y + 1)));
                    break;

                case 1: // 90° (Clockwise)
                    Squares.Add(new Square(new Position(Position.X, Position.Y)));
                    Squares.Add(new Square(new Position(Position.X, Position.Y - 1)));
                    Squares.Add(new Square(new Position(Position.X, Position.Y + 1)));
                    Squares.Add(new Square(new Position(Position.X + 1, Position.Y)));
                    break;

                case 2: // 180° (Upside-down)
                    Squares.Add(new Square(new Position(Position.X, Position.Y)));
                    Squares.Add(new Square(new Position(Position.X - 1, Position.Y)));
                    Squares.Add(new Square(new Position(Position.X + 1, Position.Y)));
                    Squares.Add(new Square(new Position(Position.X, Position.Y - 1)));
                    break;

                case 3: // 270° (Counterclockwise)
                    Squares.Add(new Square(new Position(Position.X, Position.Y)));
                    Squares.Add(new Square(new Position(Position.X, Position.Y - 1)));
                    Squares.Add(new Square(new Position(Position.X, Position.Y + 1)));
                    Squares.Add(new Square(new Position(Position.X - 1, Position.Y)));
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
                sq.GetPosition().X >= 0 && sq.GetPosition().X < 10 &&
                sq.GetPosition().Y >= 0 && sq.GetPosition().Y < 20);
        }
    }
}
