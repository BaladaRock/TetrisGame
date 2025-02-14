using System.Diagnostics;
using TetrisGame.Processors.Contracts;
using TetrisGame.Utils;

namespace TetrisGame.Processors.Implementations.Game
{
    public class Game : IGame
    {
        private readonly Square[,] _squares;
        private readonly List<Line> _lines;
        private List<string> _pieceSequence = [];
        private int _currentPieceIndex;
        private IPiece? _activePiece;


        public Game(int size)
        {
            Size = size;
            _squares = new Square[Size, Size];
            SetSquares();
            _lines = new List<Line>(Size);
            SetLines();

            // Read the pieces from a .txt file
            LoadPieceSequence("pieces.txt");

            ResetActivePiece();
        }

        public void LoadPieceSequence(string filePath)
        {

            if (File.Exists(filePath))
            {
                _pieceSequence = File.ReadAllLines(filePath).ToList();
            }
            else
            {
                Debug.WriteLine("Piece file not found! Generating new sequence.");
                GeneratePieceFile(filePath);
            }
        }

        private static void GeneratePieceFile(string filePath)
        {
            string[] pieceTypes = ["I", "O", "T", "S", "Z", "L", "J"];
            var random = new Random();
            var pieces = Enumerable.Range(0, 1000)
                .Select(_ => pieceTypes[random.Next(pieceTypes.Length)])
                .ToList();

            File.WriteAllLines(filePath, pieces);
            Debug.WriteLine($"Generated 1000 pieces in {filePath}");
        }

        public int Size { get; set; }

        public bool CanMove(IPiece piece, int deltaX, int deltaY)
        {
            return piece.GetSquarePositions().All(pos =>
                pos.X + deltaX >= 0 &&                                                     // Left boundary check
                pos.X + deltaX < GameConstants.GridWidth &&                                // Right boundary check
               /* pos.Y + deltaY >= 0 &&  */                                                   // Top boundary check
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
                var lineIndex = square.Position.Y;
                if (lineIndex < 0)
                {
                    Debug.WriteLine("Game Over! A new piece collided at spawn.");
                    return;
                }

                _lines[square.Position.Y].AddSquare(square);
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

        public IPiece? ActivePiece
        {
            get => _activePiece;
            set
            {
                _activePiece = value;
                _activePiece?.ColourSquares();
            }
        }

        public bool IsPositionOccupied(Position position)
        {
            return _lines.Any(line => line.GetSquares()
                .Any(sq => sq.Position.Equals(position)));
            //var yCoordinate = position.Y;
            //return yCoordinate >= 0 && _squares[position.X, yCoordinate].IsColoured();
        }

        // Generate the next piece randomly
        public void ResetActivePiece()
        {
            // Using random pieces read from file
            if (_pieceSequence.Count == 0 || _currentPieceIndex >= _pieceSequence.Count)
            {
                LoadPieceSequence("pieces.txt");
                _currentPieceIndex = 0;
            }

            var pieceType = _pieceSequence[_currentPieceIndex];
            _currentPieceIndex++;

            ActivePiece = pieceType switch
            {
                "I" => new LinePiece(GameConstants.GridWidth, GameConstants.GridHeight, GameConstants.PieceWidth),
                "O" => new SquarePiece(GameConstants.GridWidth, GameConstants.GridHeight, GameConstants.PieceWidth / 2),
                "T" => new TPiece(GameConstants.GridWidth, GameConstants.GridHeight, GameConstants.PieceWidth),
                "S" => new SPiece(GameConstants.GridWidth, GameConstants.GridHeight, GameConstants.PieceWidth),
                "Z" => new ZPiece(GameConstants.GridWidth, GameConstants.GridHeight, GameConstants.PieceWidth),
                "L" => new LPiece(GameConstants.GridWidth, GameConstants.GridHeight, GameConstants.PieceWidth),
                "J" => new JPiece(GameConstants.GridWidth, GameConstants.GridHeight, GameConstants.PieceWidth),
                _ => new LinePiece(GameConstants.GridWidth, GameConstants.GridHeight, GameConstants.PieceWidth), // Default fallback
            };

            // Using a random piece generator

            //var randomPiece = new Random().Next(7);
            //ActivePiece = randomPiece switch
            //{
            //    0 => new LinePiece(GameConstants.GridWidth, GameConstants.GridHeight, GameConstants.PieceWidth),
            //    1 => new SquarePiece(GameConstants.GridWidth, GameConstants.GridHeight, GameConstants.PieceWidth / 2),
            //    2 => new TPiece(GameConstants.GridWidth, GameConstants.GridHeight, GameConstants.PieceWidth),
            //    3 => new SPiece(GameConstants.GridWidth, GameConstants.GridHeight, GameConstants.PieceWidth),
            //    4 => new ZPiece(GameConstants.GridWidth, GameConstants.GridHeight, GameConstants.PieceWidth),
            //    5 => new LPiece(GameConstants.GridWidth, GameConstants.GridHeight, GameConstants.PieceWidth),
            //    6 => new JPiece(GameConstants.GridWidth, GameConstants.GridHeight, GameConstants.PieceWidth),
            //    _ => new LinePiece(GameConstants.GridWidth, GameConstants.GridHeight, GameConstants.PieceWidth),
            //};
        }
    }
}
