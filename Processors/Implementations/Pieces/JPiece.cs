using TetrisGame.Processors.Base;

namespace TetrisGame.Processors.Implementations;

internal class JPiece : Piece
{
    public JPiece(int gameWidth, int gameHeight, byte pieceSize)
        : base(gameWidth, gameHeight, pieceSize)
    {
        Colour = Colour.Red;
        DefineShape();
    }

    protected sealed override void DefineShape()
    {
        Squares.Clear();

        switch (RotationState)
        {
            case 0: // Horizontal (default)
            case 2: // Z-piece has only two unique shapes (mirrored)
                Squares.Add(new Square(new Position(Position.X, Position.Y)));
                Squares.Add(new Square(new Position(Position.X + 1, Position.Y)));
                Squares.Add(new Square(new Position(Position.X, Position.Y + 1)));
                Squares.Add(new Square(new Position(Position.X - 1, Position.Y + 1)));
                break;

            case 1: // Vertical
            case 3:
                Squares.Add(new Square(new Position(Position.X, Position.Y)));
                Squares.Add(new Square(new Position(Position.X, Position.Y - 1)));
                Squares.Add(new Square(new Position(Position.X - 1, Position.Y)));
                Squares.Add(new Square(new Position(Position.X - 1, Position.Y + 1)));
                break;
        }
    }
}