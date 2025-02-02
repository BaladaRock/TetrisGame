﻿using System.Diagnostics;
using TetrisGame.Processors.Contracts;

namespace TetrisGame.Processors.Implementations;

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
        Position = new Position((byte)(Position.X - 1), Position.Y);
        UpdateSquares();
    }

    public void MoveRight()
    {
        Position = new Position((byte)(Position.X + 1), Position.Y);
        UpdateSquares();
    }

    public void MoveDown()
    {
        Position = new Position(Position.X, (byte)(Position.Y + 1));
        UpdateSquares();
    }

    public virtual void Rotate()
    {
        Debug.WriteLine("Rotation attempted on SquarePiece - No effect.");
    }

    public IEnumerable<Position> GetSquarePositions()
    {
        return Squares.Select(sq => sq.GetPosition());
    }

    public IEnumerable<Square> GetSquares()
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

    public virtual void UpdateSquares()
    {
        for (byte i = 0; i < Squares.Count; i++)
        {
            Squares[i].Position = new Position(Position.X + i, Position.Y);
        }

        ColourSquares();
    }

    public void SetPosition(Position position)
    {
        Position = position;
        UpdateSquares();
    }
}