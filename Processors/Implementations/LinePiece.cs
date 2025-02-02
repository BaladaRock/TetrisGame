using System.Collections.Generic;
using TetrisGame.Processors.Contracts;

namespace TetrisGame.Processors.Implementations
{
    internal class LinePiece : Piece
    {
        private bool _isHorizontal = true;

        public LinePiece(int gameWidth, int gameHeight, byte pieceSize) 
            : base(gameWidth, gameHeight, pieceSize)
        {
            Colour = Colour.Blue;
            DefineShape();
        }

        protected sealed override void DefineShape()
        {
            Squares.Clear();
            for (var i = 0; i < PieceSize; i++)
            {
                Squares.Add(new Square(new Position(Position.X + i, Position.Y)));
            }
        }

        protected internal override void Rotate()
        {
            Squares.Clear();
            if (_isHorizontal) // If currently horizontal, switch to vertical
            {
                for (var i = 0; i < PieceSize; i++)
                {
                    Squares.Add(new Square(new Position(Position.X, Position.Y + i)));
                }
            }
            else // Otherwise, switch to horizontal
            {
                for (var i = 0; i < PieceSize; i++)
                {
                    Squares.Add(new Square(new Position(Position.X + i, Position.Y)));
                }
            }

            _isHorizontal = !_isHorizontal;
        }

    }
}