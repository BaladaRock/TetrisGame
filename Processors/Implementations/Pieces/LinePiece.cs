using TetrisGame.Helpers;
using TetrisGame.Processors.Base;
using TetrisGame.Utils;

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
            RotationState = (RotationState + 1) % PieceSize; // Rotate to the next state
            DefineShape();

            // Get correct wall kick tests for LinePiece
            var wallKicks = WallKickTests.GetWallKickTests(this, oldRotation, RotationState);

            foreach (var (shiftX, shiftY) in wallKicks)
            {
                var newX = Position.X + shiftX;
                var newY = Position.Y + shiftY;

                // Ensure new position is inside grid boundaries
                if (newX < 0 || newX >= GameConstants.GridWidth ||
                    newY < 0 || newY >= GameConstants.GridHeight)
                {
                    continue;
                }
                
                Position = new Position(newX, newY);
                DefineShape();
                if (ValidateRotation()) return; // Apply shift if valid
            }
            // Undo rotation if all fails
            Position = new Position(Position.X, Position.Y); // Reset position
            RotationState = oldRotation;
            DefineShape();

            UpdateSquares();
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
