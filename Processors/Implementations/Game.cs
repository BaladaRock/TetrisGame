﻿using System.Collections.Generic;
using System.Linq;
using TetrisGame.Processors.Contracts;
using TetrisGame.Utils;

namespace TetrisGame.Processors.Implementations
{
    public class Game : IGame
    {
        private readonly Square[,] _squares;
        private readonly List<Line> _lines;

        public Game(int size)
        {
            Size = size;
            _squares = new Square[Size, Size];
            SetSquares();
            ActivePiece = new LinePiece(GameConstants.GridWidth, GameConstants.GridHeight, GameConstants.PieceWidth);

            _lines = new List<Line>(Size);
            SetLines();
        }

        public int Size { get; set; }

        public bool CanMove(IPiece piece, int deltaX, int deltaY)
        {
            return piece.GetSquarePositions().All(pos =>
                pos.X + deltaX >= 0 &&
                pos.X + deltaX < GameConstants.GridWidth &&
                pos.Y + deltaY >= 0 &&
                pos.Y + deltaY < GameConstants.GridHeight &&
                !IsPositionOccupied(new Position(pos.X + deltaX, pos.Y + deltaY))
            );
        }

        public void SetSquares()
        {
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    _squares[i, j] = new Square(new Position(i, j));
                }
            }
        }

        public void SetLines()
        {
            for (var i = 0; i < Size; i++)
            {
                _lines.Add(new Line(i, new List<Square>()));
            }
        }

        public IEnumerable<ILine> GetLines() => _lines;

        public ILine GetLine(int index) => _lines.ElementAt(index);

        public void AddPieceToGrid(Piece? piece)
        {
            if (piece == null)
            {
                return;
            }
            
            foreach (var square in piece.GetSquares())
            {
                _lines[square!.GetPosition().Y].AddSquare(square);
            }

            ClearFullLines();
        }

        public IEnumerable<ILine> GetFullLines()
        {
            return _lines.Where(line => line.IsFull());
        }

        public void ClearFullLines()
        {
            var fullLines = GetFullLines();
            foreach (var line in fullLines)
            {
                line.ClearLine();
            }
        }

        public Piece? ActivePiece { get; set; }

        public bool IsPositionOccupied(Position position)
        {
            return _lines.Any(line => line.GetSquares()
                .Any(sq => sq.GetPosition().Equals(position)));
        }

        public void ResetActivePiece()
        {
            ActivePiece = new LinePiece(GameConstants.GridWidth, GameConstants.GridHeight, GameConstants.PieceWidth);
        }
    }
}
