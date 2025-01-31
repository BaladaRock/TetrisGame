using System;
using System.Collections.Generic;
using System.Linq;
using TetrisGame.Processors.Contracts;

namespace TetrisGame.Processors.Implementations
{
    internal abstract class Piece : IPiece
    {
        protected List<Square> Squares { get; set; }
        protected Position Position { get; set; }

        protected Piece()
        {
            Squares = [];
            Position = new Position(0, 0);
            SetSquares();
        }

        public void MoveLeft()
        {
            if (!CanMove(-1, 0))
            {
                return;
            }
            
            Position = new Position((byte)(Position.X - 1), Position.Y);
            UpdateSquares();
        }

        public void MoveRight()
        {
            if (!CanMove(1, 0))
            {
                return;
            }
            
            Position = new Position((byte)(Position.X + 1), Position.Y);
            UpdateSquares();
        }

        public void MoveUp()
        {
            throw new NotImplementedException();
        }

        public void MoveDown()
        {
            if (!CanMove(0, 1))
            {
                return;
            }
            
            Position = new Position(Position.X, Position.Y);
            UpdateSquares();
        }

        public IEnumerable<Position> GetSquarePositions()
        {
            return Squares.Select(sq => sq.GetPosition());
        }

        public void SetSquares()
        {
            Squares.Clear();
            DefineShape();
        }

        protected abstract void DefineShape();
        protected abstract void Rotate();

        private bool CanMove(int deltaX, int deltaY)
        {
            return Squares.All(sq => sq.GetPosition().X + deltaX >= 0 &&
                                      sq.GetPosition().X + deltaX < 10 &&
                                      sq.GetPosition().Y + deltaY < 20);
        }

        private void UpdateSquares()
        {
            for (byte i = 0; i < Squares.Count; i++)
            {
                var pos = Squares[i].GetPosition();
                Squares[i] = new Square(new Position((byte)(pos.X + Position.X), (byte)(pos.Y + Position.Y)));
            }
        }
    }
}
