using System.Diagnostics;
using TetrisGame.Processors.Contracts;
using TetrisGame.Processors.Implementations;

namespace TetrisGame.Processors.Base;

public abstract class Piece : IPiece
{
    private readonly int _gameHeight;
    private readonly int _gameWidth;
    protected List<Square> Squares { get; set; }
    protected Position Position { get; set; }

    protected Piece(int gameWidth, int gameHeight, byte pieceSize)
    {
        _gameWidth = gameWidth;
        _gameHeight = gameHeight;
        PieceSize = pieceSize;
        Squares = new List<Square>(PieceSize);
        Position = new Position(0, 0);
        SetSquares();
    }

    internal byte PieceSize { get; set; }
    public int RotationState { get; protected set; } = 0;

    protected internal Colour Colour;

    public void MoveLeft()
    {
        Position = new Position(Position.X - 1, Position.Y);
        UpdateSquares();
    }

    public void MoveRight()
    {
        Position = new Position(Position.X + 1, Position.Y);
        UpdateSquares();
    }

    public void MoveDown()
    {
        Position = new Position(Position.X, Position.Y + 1);
        UpdateSquares();
    }

    public virtual void Rotate()
    {
        RotationState = (RotationState + 1) % PieceSize; // Rotate to the next state
        DefineShape();
        UpdateSquares();
    }

    public IEnumerable<Position> GetSquarePositions()
    {
        return Squares.Select(sq => sq.Position);
    }

    public IEnumerable<ISquare> GetSquares()
    {
        return Squares;
    }

    public virtual void ColourSquares()
    {
        foreach (var square in Squares)
        {
            square.FillWithColour(Colour);
        }
    }

    public void SetSquares()
    {
        Squares.Clear();
        DefineShape();
    }

    protected abstract void DefineShape();

    protected virtual bool ValidateRotation()
    {
        return Squares.TrueForAll(sq =>
            sq.Position.X is >= 0 and < 10 &&
            sq.Position.Y is >= 0 and < 20);
    }

    public virtual void UpdateSquares()
    {
        DefineShape();
        ColourSquares();
    }

    public void SetPosition(Position position)
    {
        Position = position;
        UpdateSquares();
    }
}