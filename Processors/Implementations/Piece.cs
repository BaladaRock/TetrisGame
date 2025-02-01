using System;
using System.Collections.Generic;
using System.Linq;
using TetrisGame.Processors.Contracts;

namespace TetrisGame.Processors.Implementations
{
    public abstract class Piece : IPiece
    {
        private readonly int _gameHeight;
        private readonly int _gameWidth;
        protected List<Square> Squares { get; set; }
        protected Position Position { get; set; }

        protected Piece(int gameWidth, int gameHeight)
        {
            _gameWidth = gameWidth;
            _gameHeight = gameHeight;
            Squares = [];
            Position = new Position(0, 0);
            SetSquares();
        }

        protected internal Colour Colour;

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
            if (!CanMove(0, -1))
            {
                return;
            }

            Position = new Position(Position.X, (byte)(Position.Y - 1));
            UpdateSquares();
        }

        public void MoveDown()
        {
            if (!CanMove(0, 1))
            {
                return;
            }
            
            Position = new Position(Position.X, (byte)(Position.Y + 1));
            UpdateSquares();
        }

        public IEnumerable<Position> GetSquarePositions()
        {
            return Squares.Select(sq => sq.GetPosition());
        }

        public IEnumerable<Square> GetSquares()
        {
            return Squares;
        }

        public virtual void ColourSquares()
        {
            foreach (var square in Squares)
            {
                square.FillWithColour(Colour);
            }
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
            return Squares.All(sq =>
                    sq.GetPosition().X + deltaX >= 0 &&
                    sq.GetPosition().X + deltaX < _gameWidth &&
                    sq.GetPosition().Y + deltaY >= 0 &&  
                    sq.GetPosition().Y + deltaY < _gameHeight
            );
        }

        public void UpdateSquares()
        {
            for (byte i = 0; i < Squares.Count; i++)
            {
                var pos = Squares[i].GetPosition();
                Squares[i].Position = (new Position(Position.X + i, Position.Y));
            }
            ColourSquares();
        }


        public void SetPosition(Position position)
        {
            Position = position;
        }
    }
}
