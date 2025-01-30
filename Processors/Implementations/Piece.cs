using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisGame.Processors.Contracts;

namespace TetrisGame.Processors.Implementations
{
    internal abstract class Piece : IPiece
    {
        public void MoveLeft()
        {
            throw new NotImplementedException();
        }

        public void MoveRight()
        {
            throw new NotImplementedException();
        }

        public void MoveUp()
        {
            throw new NotImplementedException();
        }

        public void MoveDown()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Square> GetSquares()
        {
            throw new NotImplementedException();
        }
    }
}
