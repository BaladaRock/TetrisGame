using TetrisGame.Processors.Contracts;
using TetrisGame.Utils;

namespace TetrisGame.Processors.Implementations
{
    internal class Line : ILine
    {
        private int _position;
        private readonly List<Square> _squares;

        public Line(int position, IEnumerable<Square> squares)
        {
            _position = position;
            _squares = squares.ToList();
        }

        public int GetPosition() => _position;
        IEnumerable<ISquare> ILine.GetSquares()
        {
            return GetSquares();
        }

        public void AddSquare(ISquare square)
        {
            if (!_squares.Contains(square))
            {
                _squares.Add((Square)square);
            }
        }

        public IEnumerable<Square> GetSquares() => _squares;

        public void RefreshSquare(int position)
        {
            throw new NotImplementedException();
        }

        public bool IsFull()
        {
            return _squares.Count == GameConstants.GridWidth;
        }

        public void ClearLine()
        {
            _squares.Clear();
        }
    }
}