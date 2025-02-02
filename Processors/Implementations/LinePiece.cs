using System.Collections.Generic;
using TetrisGame.Processors.Contracts;

namespace TetrisGame.Processors.Implementations
{
    internal class LinePiece : Piece
    {
        private bool _isHorizontal = true; // Track rotation state

        public LinePiece(int gameWidth, int gameHeight, byte pieceSize)
            : base(gameWidth, gameHeight, pieceSize)
        {
            Colour = Colour.Blue;
            DefineShape();
        }

        protected sealed override void DefineShape()
        {
            Squares.Clear();

            if (_isHorizontal)
            {
                for (var i = 0; i < PieceSize; i++)
                {
                    Squares.Add(new Square(new Position(Position.X + i, Position.Y)));
                }
            }
            else
            {
                for (var i = 0; i < PieceSize; i++)
                {
                    Squares.Add(new Square(new Position(Position.X, Position.Y + i)));
                }
            }
        }

        public override void Rotate()
        {
            _isHorizontal = !_isHorizontal;
            DefineShape();
            UpdateSquares();
        }

        public override void UpdateSquares()
        {
            if (_isHorizontal)
            {
                for (int i = 0; i < Squares.Count; i++)
                {
                    Squares[i].Position = new Position(Position.X + i, Position.Y);
                }
            }
            else
            {
                for (int i = 0; i < Squares.Count; i++)
                {
                    Squares[i].Position = new Position(Position.X, Position.Y + i);
                }
            }

            ColourSquares();
        }
    }

}