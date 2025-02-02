using System;
using System.Collections.Generic;
using System.Linq;
namespace TetrisGame.Processors.Contracts
{
    public interface IPiece
    {
        void MoveLeft();
        void MoveRight();
        void MoveDown();
        void Rotate();

        IEnumerable<Position> GetSquarePositions();

        IEnumerable<ISquare> GetSquares();

        void ColourSquares();

        void SetSquares();

        void SetPosition(Position newPosition);

    }
}
