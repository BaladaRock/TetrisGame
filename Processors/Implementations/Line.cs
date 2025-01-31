using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisGame.Processors.Contracts;

namespace TetrisGame.Processors.Implementations
{
    internal class Line(byte position, IEnumerable<Square> squares) : ILine
    {
        public byte GetPosition()
        {
            return position;
        }

        public IEnumerable<Square> GetSquares()
        {
            return squares;
        }

        public void EmptyLine()
        {
            squares.ToList().ForEach(square => square.EmptyFromColour());
        }

        public void RefreshSquare(byte positionToRefresh)
        {
            squares.FirstOrDefault(square => square.GetPosition().X == positionToRefresh)
                ?.EmptyFromColour();
        }
    }
}
