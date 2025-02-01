using TetrisGame.Processors;
using TetrisGame.Views.Pieces;
using TetrisGame.Processors.Implementations;
using TetrisGame.Utils;

namespace TetrisGame.Controllers
{
    public class PieceController
    {
        private readonly Game _game;
        private readonly PieceView _pieceView;
        private Piece _currentPiece;

        public PieceController(Game game, PieceView pieceView)
        {
            _game = game;
            _pieceView = pieceView;
            GenerateNewPiece();
        }

        public void GenerateNewPiece()
        {
            _currentPiece = _game.GetActivePiece();

            // Center the piece at the top
            const int middleX = (GameConstants.GridWidth - GameConstants.PieceWidth) / 2;
            _currentPiece.SetPosition(new Position(middleX, 0));
            _currentPiece.UpdateSquares();

            UpdatePieceView();
        }

        public void MovePieceDown()
        {
            _currentPiece.MoveDown();
            UpdatePieceView();
        }

        public void MovePieceLeft()
        {
            _currentPiece.MoveLeft();
            UpdatePieceView();
        }

        public void MovePieceRight()
        {
            _currentPiece.MoveRight();
            UpdatePieceView();
        }

        private void UpdatePieceView()
        {
            var positions = _currentPiece.GetSquarePositions().ToList();
            _pieceView.SetSquares(positions, Helpers.ColourMapper.ToColor(_currentPiece.Colour));
        }

        public bool HasPieceLanded()
        {
            return _currentPiece.GetSquarePositions().Any(pos => pos.Y >= GameConstants.GridHeight - 1);
        }
    }
}