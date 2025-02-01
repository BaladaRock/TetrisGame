using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TetrisGame.Processors.Contracts;

namespace TetrisGame.Processors.Implementations
{
    public class Game : ITetris
    {
        private readonly Square[,] _squares;
        private readonly List<Line> _lines;
        private Piece _activePiece;

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
            for (byte i = 0; i < Size; ++i)
            {
                for (byte j = 0; j < Size; ++j)
                {
                    _squares[i, j] = new Square(new Position(i, j));
                }
            }
        }

        public void SetLines()
        {
            for (var i = 0; i < Size; ++i)
            {
                var lineSquares = new List<Square>();
                for (var j = 0; j < Size; ++j)
                {
                    lineSquares.Add(_squares[i, j]);
                }
                var line = new Line(i, lineSquares);
                _lines.Add(line);
            }
        }

        public IEnumerable<ILine> GetLines()
        {
            return _lines;
        }

        public ILine GetLine(int index)
        {
            return _lines.ElementAt(index);
        }

        public Piece GetActivePiece()
        {
            return _activePiece;
        }
    }
}
