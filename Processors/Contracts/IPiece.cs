using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisGame.Processors.Implementations;

namespace TetrisGame.Processors.Contracts
{
    public interface IPiece
    {
        void MoveLeft();
        void MoveRight();
        void MoveDown();
        void MoveUp();
        
        IEnumerable<Position> GetSquarePositions();

        IEnumerable<Square> GetSquares();

        void ColourSquares();

        void SetSquares();

        void SetPosition(Position newPosition);

    }
}
