using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisGame.Processors.Implementations;

namespace TetrisGame.Processors.Contracts
{
    public interface ILine
    {
        int GetPosition();
        
        IEnumerable<Square> GetSquares();

        void EmptyLine();

        void RefreshSquare(byte position);
    }
}
