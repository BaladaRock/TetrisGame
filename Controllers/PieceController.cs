using System.Linq;
using TetrisGame.Views.Pieces;
using TetrisGame.Processors.Implementations;
using TetrisGame.Utils;
using TetrisGame.Processors;

namespace TetrisGame.Controllers
{
    public class PieceController
    {
        private readonly Game _game;
        private readonly PieceView _pieceView;
        private Piece? _currentPiece;

        public PieceController(Game game, PieceView pieceView)
        {
            _game = game;
            _pieceView = pieceView;
            GenerateNewPiece();
        }

        public void GenerateNewPiece()
        {
            StorePiece();
            _currentPiece = _game.GetActivePiece();

            // Center the piece at the top
            const int middleX = (GameConstants.GridWidth - GameConstants.PieceWidth) / 2;
            
            _currentPiece?.SetPosition(new Position(middleX, 0));
            _currentPiece?.UpdateSquares();

            UpdatePieceView();
        }

        public void MovePieceDown()
        {
            if (_currentPiece == null)
            {
                return;
            }
            if (!CanMove(0, 1))
            {
                _game.AddPieceToGrid(_currentPiece);
                UpdatePieceView();
                GenerateNewPiece();
                return;
            }

            _currentPiece?.MoveDown();
            UpdatePieceView();
        }

        public void MovePieceLeft()
        {
            if (!CanMove(-1, 0))
            {
                return;
            }
            _currentPiece?.MoveLeft();
            UpdatePieceView();
        }

        public void MovePieceRight()
        {
            if (!CanMove(1, 0))
            {
                return;
            }
            _currentPiece?.MoveRight();
            UpdatePieceView();
        }

        private bool CanMove(int deltaX, int deltaY)
        {
            return _currentPiece!.GetSquarePositions().All(pos =>
                pos.Y + deltaY < GameConstants.GridHeight &&
                !_game.IsPositionOccupied(new Position(pos.X + deltaX, pos.Y + deltaY))
            );
        }

        private void UpdatePieceView()
        {
            var currentPositions = _currentPiece?.GetSquarePositions().ToList() ?? [];

            _pieceView.SetSquares(currentPositions, Helpers.ColourMapper.ToColor(_currentPiece!.Colour)); // Only update the moving piece
        }

        public bool HasPieceLanded()
        {
            return _currentPiece!.GetSquarePositions().Any(pos =>
                pos.Y >= GameConstants.GridHeight - 1 ||
                _game.IsPositionOccupied(new Position(pos.X, pos.Y + 1))
            );
        }

        public void StorePiece()
        {
            if (_currentPiece == null)
            {
                return;
            }

            _game.AddPieceToGrid(_currentPiece);

            var positions = _currentPiece.GetSquarePositions().ToList();
            _pieceView.AddLandedSquares(positions, Helpers.ColourMapper.ToColor(_currentPiece.Colour));
        }


    }
}
