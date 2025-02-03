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
            Colour = Colour.Turquoise;
            DefineShape();
        }

        protected sealed override void DefineShape()
        {
            Squares.Clear();

            switch (RotationState)
            {
                case 0: // Default horizontal spawn (aligned with the grid)
                    Squares.Add(new Square(new Position(Position.X - 1, Position.Y + 1)));
                    Squares.Add(new Square(new Position(Position.X, Position.Y + 1)));    
                    Squares.Add(new Square(new Position(Position.X + 1, Position.Y + 1)));
                    Squares.Add(new Square(new Position(Position.X + 2, Position.Y + 1)));
                    break;

                case 1: // Vertical facing right, adjusted so it stays on the same row
                    Squares.Add(new Square(new Position(Position.X, Position.Y - 1)));
                    Squares.Add(new Square(new Position(Position.X, Position.Y)));
                    Squares.Add(new Square(new Position(Position.X, Position.Y + 1)));
                    Squares.Add(new Square(new Position(Position.X, Position.Y + 2)));
                    break;

                case 2: // Upside-down horizontal (mirrored)
                    Squares.Add(new Square(new Position(Position.X - 1, Position.Y)));
                    Squares.Add(new Square(new Position(Position.X, Position.Y)));    
                    Squares.Add(new Square(new Position(Position.X + 1, Position.Y)));
                    Squares.Add(new Square(new Position(Position.X + 2, Position.Y)));
                    break;

                case 3: // Vertical facing left, adjusted so it stays on the same row
                    Squares.Add(new Square(new Position(Position.X, Position.Y - 1)));
                    Squares.Add(new Square(new Position(Position.X, Position.Y)));
                    Squares.Add(new Square(new Position(Position.X, Position.Y + 1)));
                    Squares.Add(new Square(new Position(Position.X, Position.Y + 2)));
                    break;
            }
        }

        public override void Rotate()
        {
            var oldRotation = RotationState;
            RotationState = (RotationState + 1) % 4; // Rotate clockwise
            DefineShape();

            if (!ValidateRotation())
            {
                // Apply the wallkick tests
                var wallKicks = WallKickTests.GetWallKickTests(this, oldRotation, RotationState);
                foreach (var (shiftX, shiftY) in wallKicks)
                {
                    var newX = Position.X + shiftX;
                    var newY = Position.Y + shiftY;

                    if (newX < 0 || newX >= GameConstants.GridWidth ||
                        newY < 0 || newY >= GameConstants.GridHeight)
                    {
                        continue;
                    }

                    Position = new Position(newX, newY);
                    DefineShape();
                    if (ValidateRotation()) return;
                }

                RotationState = oldRotation;
                DefineShape();
            }

            UpdateSquares();
        }
    }
}
