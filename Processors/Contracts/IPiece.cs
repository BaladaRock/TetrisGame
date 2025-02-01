using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisGame.Processors.Implementations;

namespace TetrisGame.Processors.Contracts
{
    internal interface IPiece
    {
        void MoveLeft();
        
        void MoveRight();
        
        void MoveUp();
        
        void MoveDown();
        
        IEnumerable<Position> GetSquarePositions();

        IEnumerable<Square> GetSquares();

        void ColourSquares();

        void SetSquares();

        void SetPosition(Position newPosition);
        
    }
}
