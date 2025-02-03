using TetrisGame.Processors.Contracts;
using TetrisGame.Utils;

namespace TetrisGame.Processors.Implementations.Game
{
    public class Game : IGame
    {
        private readonly Square[,] _squares;
        private readonly List<Line> _lines;

        public Game(int size)
        {
            Size = size;
            _squares = new Square[Size, Size];
            SetSquares();
            ResetActivePiece();
            _lines = new List<Line>(Size);
            SetLines();
        }

        public int Size { get; set; }

        public bool CanMove(IPiece piece, int deltaX, int deltaY)
        {
            return piece.GetSquarePositions().All(pos =>
                pos.X + deltaX >= 0 &&                                                     // Left boundary check
                pos.X + deltaX < GameConstants.GridWidth &&                                // Right boundary check
                pos.Y + deltaY >= 0 &&                                                     // Top boundary check
                pos.Y + deltaY < GameConstants.GridHeight &&                               // Left boundary check
                !IsPositionOccupied(new Position(pos.X + deltaX, pos.Y + deltaY)) // Piece collision check
            );
        }

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

        public void AddPieceToGrid(IPiece? piece)
        {
            if (piece == null)
            {
                return;
            }

            foreach (var square in piece.GetSquares())
            {
                _lines[square!.Position.Y].AddSquare(square);
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

        public IPiece? ActivePiece { get; set; }

        public bool IsPositionOccupied(Position position)
        {
            return _lines.Any(line => line.GetSquares()
                .Any(sq => sq.Position.Equals(position)));
        }

        // Generate the next piece randomly
        public void ResetActivePiece()
        {
            var randomPiece = new Random().Next(7);

            ActivePiece = randomPiece switch
            {
                //0 => new LinePiece(GameConstants.GridWidth, GameConstants.GridHeight, GameConstants.PieceWidth),
                //1 => new SquarePiece(GameConstants.GridWidth, GameConstants.GridHeight, GameConstants.PieceWidth / 2),
                //2 => new TPiece(GameConstants.GridWidth, GameConstants.GridHeight, GameConstants.PieceWidth),
                //3 => new SPiece(GameConstants.GridWidth, GameConstants.GridHeight, GameConstants.PieceWidth),
                //4 => new ZPiece(GameConstants.GridWidth, GameConstants.GridHeight, GameConstants.PieceWidth),
                //5 => new LPiece(GameConstants.GridWidth, GameConstants.GridHeight, GameConstants.PieceWidth),
                //6 => new JPiece(GameConstants.GridWidth, GameConstants.GridHeight, GameConstants.PieceWidth),
                _ => new LinePiece(GameConstants.GridWidth, GameConstants.GridHeight, GameConstants.PieceWidth)
            };
        }
    }
}
