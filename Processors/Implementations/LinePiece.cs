using System.Collections.Generic;
using TetrisGame.Processors.Contracts;

namespace TetrisGame.Processors.Implementations
{
    internal class LinePiece : Piece
    {
        private Colour _colour;

        public LinePiece()
        {
            _colour = Colour.Blue;
            DefineShape();
        }

        protected sealed override void DefineShape()
        {
            Squares.Clear();
            for (var i = 0; i < 4; i++)
            {
                Squares.Add(new Square(new Position((byte)(Position.X + i), Position.Y)));
            }
        }

        public override Colour PieceColour
        {
            get => _colour;
            set
            {
                foreach (var square in Squares)
                {
                    square.FillWithColour(value);
                }
            }
        }

        protected override void Rotate()
        {
            // To be done
        }
    }
}