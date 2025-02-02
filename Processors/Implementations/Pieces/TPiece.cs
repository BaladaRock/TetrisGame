using TetrisGame.Processors.Base;

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
            
            // If rotation is invalid, try wall kicks
            if (!ValidateRotation()) 
            {
                // Try shifting left
                Position = new Position(Position.X - 1, Position.Y);
                DefineShape();
                if (ValidateRotation())
                {
                    UpdateSquares();
                    return;
                }
                // Try shifting right
                Position = new Position(Position.X + 2, Position.Y);
                DefineShape();
                if (ValidateRotation())
                {
                    UpdateSquares();
                    return;
                }
                // Undo rotation if all fails
                Position = new Position(Position.X - 1, Position.Y);
                RotationState = oldRotation;
                DefineShape();
            }

            UpdateSquares();
        }

        public override void UpdateSquares()
        {
            DefineShape();
            ColourSquares();
        }
    }
}
