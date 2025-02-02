using TetrisGame.Processors.Base;

namespace TetrisGame.Processors.Implementations;

internal class SPiece : Piece
{
    public SPiece(int gameWidth, int gameHeight, byte pieceSize)
        : base(gameWidth, gameHeight, pieceSize)
    {
        Colour = Colour.Brown;
        DefineShape();
    }

    protected sealed override void DefineShape()
    {
        Squares.Clear();

        switch (RotationState)
        {
            case 0: // Horizontal (default)
            case 2: // S-piece has only two unique shapes (mirrored)
                Squares.Add(new Square(new Position(Position.X, Position.Y)));
                Squares.Add(new Square(new Position(Position.X + 1, Position.Y)));
                Squares.Add(new Square(new Position(Position.X - 1, Position.Y + 1)));
                Squares.Add(new Square(new Position(Position.X, Position.Y + 1)));
                break;

            case 1: // Vertical
            case 3:
                Squares.Add(new Square(new Position(Position.X, Position.Y)));
                Squares.Add(new Square(new Position(Position.X, Position.Y - 1)));
                Squares.Add(new Square(new Position(Position.X + 1, Position.Y)));
                Squares.Add(new Square(new Position(Position.X + 1, Position.Y + 1)));
                break;
        }
    }

    public override void Rotate()
    {
        var oldRotation = RotationState;
        RotationState = (RotationState + 1) % 2; // S-piece only has 2 unique rotations
        DefineShape();

        // If rotation is invalid, try wall kicks
        if (!ValidateRotation())
        {
            // Try shifting left
            Position = new Position(Position.X - 1, Position.Y);
            DefineShape();
            if (ValidateRotation()) return;
            // Try shifting right
            Position = new Position(Position.X + 2, Position.Y);
            DefineShape();
            if (ValidateRotation()) return;
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