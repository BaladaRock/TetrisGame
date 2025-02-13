﻿using TetrisGame.Processors.Base;

namespace TetrisGame.Processors.Implementations;

internal class SquarePiece : Piece
{
    public SquarePiece(int gameWidth, int gameHeight, byte pieceSize)
        : base(gameWidth, gameHeight, pieceSize)
    {
        Colour = Colour.Yellow;
        DefineShape();
    } 

    protected sealed override void DefineShape()
    {
        Squares.Clear();

        Squares.Add(new Square(new Position(Position.X, Position.Y)));
        Squares.Add(new Square(new Position(Position.X + 1, Position.Y)));
        Squares.Add(new Square(new Position(Position.X, Position.Y + 1)));
        Squares.Add(new Square(new Position(Position.X + 1, Position.Y + 1)));
    }
}