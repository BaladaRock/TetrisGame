using System.Collections.Generic;
using TetrisGame.Processors.Contracts;

namespace TetrisGame.Processors.Implementations
{
    internal class LinePiece : Piece
    {
        public LinePiece()
        {
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

        protected override void Rotate()
        {
            // To be done
        }
    }
}