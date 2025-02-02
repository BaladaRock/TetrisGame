using System.Collections.Generic;
using System.Linq;
using TetrisGame.Processors.Contracts;

namespace TetrisGame.Processors.Implementations
{
    public class Game : IGame
    {
        private readonly Square[,] _squares;
        private readonly List<Line> _lines;
        private Piece? _activePiece;

        public Game(int size)
        {
            Size = size;
            _squares = new Square[Size, Size];
            SetSquares();
            _activePiece = new LinePiece(Size / 2, Size);

            _lines = new List<Line>(Size);
            SetLines();
        }

        public int Size { get; set; }

        public void SetSquares()
        {
            for (var i = 0; i < Size; i++)
            {
                for (var j = 0; j < Size; j++)
                {
                    _squares[i, j] = new Square(new Position(i, j));
                }
            }
        }

        public void SetLines()
        {
            for (var i = 0; i < Size; i++)
            {
                _lines.Add(new Line(i, new List<Square>()));
            }
        }

        public IEnumerable<ILine> GetLines() => _lines;

        public ILine GetLine(int index) => _lines.ElementAt(index);

        public void AddPieceToGrid(Piece? piece)
        {
            if (piece == null)
            {
                return;
            }
            
            foreach (var square in piece.GetSquares())
            {
                _lines[square!.GetPosition().Y].AddSquare(square);
            }

            ClearFullLines();
        }

        public IEnumerable<ILine> GetFullLines()
        {
            return _lines.Where(line => line.IsFull());
        }

        public void ClearFullLines()
        {
            var fullLines = GetFullLines();
            foreach (var line in fullLines)
            {
                line.ClearLine();
            }
        }

        public Piece? GetActivePiece() => _activePiece;

        public bool IsPositionOccupied(Position position)
        {
            return _lines.Any(line => line.GetSquares().Any(sq => sq.GetPosition().Equals(position)));
        }
    }
}
