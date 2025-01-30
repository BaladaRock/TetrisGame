using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame.Processors
{
    internal interface IPiece
    {
        void MoveLeft();
        void MoveRight();
        void MoveUp();
        void MoveDown();
        IEnumerable<Square> GetSquares();
    }
}
