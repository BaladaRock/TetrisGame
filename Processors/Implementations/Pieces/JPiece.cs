﻿using TetrisGame.Processors.Base;

namespace TetrisGame.Processors.Implementations;

internal class JPiece : Piece
{
    public JPiece(int gameWidth, int gameHeight, byte pieceSize)
        : base(gameWidth, gameHeight, pieceSize)
    {
        Colour = Colour.Orange;
        DefineShape();
    }

    protected sealed override void DefineShape()
    {
        Squares.Clear();

        switch (RotationState)
        {
            case 0: // Default spawn (J-shape facing horizontally)
                Squares.Add(new Square(new Position(Position.X, Position.Y + 1)));
                Squares.Add(new Square(new Position(Position.X - 1, Position.Y + 1)));
                Squares.Add(new Square(new Position(Position.X + 1, Position.Y)));
                Squares.Add(new Square(new Position(Position.X + 1, Position.Y + 1)));
                break;

            case 1: // 90 (Clockwise)
                Squares.Add(new Square(new Position(Position.X, Position.Y + 1)));
                Squares.Add(new Square(new Position(Position.X, Position.Y)));
                Squares.Add(new Square(new Position(Position.X + 1, Position.Y + 2)));
                Squares.Add(new Square(new Position(Position.X, Position.Y + 2)));
                break;

            case 2: // 180 (Upside-down)
                Squares.Add(new Square(new Position(Position.X, Position.Y + 1)));
                Squares.Add(new Square(new Position(Position.X - 1, Position.Y + 2)));
                Squares.Add(new Square(new Position(Position.X - 1, Position.Y + 1)));
                Squares.Add(new Square(new Position(Position.X + 1, Position.Y + 1)));
                break;

            case 3: // 270 (Counterclockwise)
                Squares.Add(new Square(new Position(Position.X, Position.Y + 1)));
                Squares.Add(new Square(new Position(Position.X, Position.Y + 2)));
                Squares.Add(new Square(new Position(Position.X - 1, Position.Y)));
                Squares.Add(new Square(new Position(Position.X, Position.Y)));
                break;
        }
    }
}