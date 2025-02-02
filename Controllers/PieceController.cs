using System.Linq;
using TetrisGame.Views.Pieces;
using TetrisGame.Utils;
using TetrisGame.Processors;
using System.Diagnostics;
using TetrisGame.Helpers;
using TetrisGame.Processors.Implementations.Game;
using TetrisGame.Processors.Base;

namespace TetrisGame.Controllers
{
    public class PieceController
    {
        private readonly Game _game;
        private readonly PieceView _pieceView;
        private Piece? _currentPiece;
        private bool _canMove;

        public PieceController(Game game, PieceView pieceView)
        {
            _canMove = true;
            _game = game;
            _pieceView = pieceView;
            GenerateNewPiece();
        }

        public void GenerateNewPiece()
        {
            StorePiece();
            _currentPiece = (Piece?)_game.ActivePiece;

            // Center the piece at the top
            const int middleX = (GameConstants.GridWidth - GameConstants.PieceWidth) / 2;
            
            _currentPiece?.SetPosition(new Position(middleX, 0));
            _currentPiece?.UpdateSquares();

            UpdatePieceView();
        }

        public void MovePieceDown()
        {
            if (_currentPiece == null || !_canMove)
            {
                return;
            }

            if (!_game.CanMove(_currentPiece, 0, 1))
            {
                _canMove = false; // Lock movement until a new piece is generated
                StorePiece();
                _game.ResetActivePiece();
                GenerateNewPiece();
                _canMove = true; // Unlock movement for the next piece
                return;
            }

            _currentPiece.MoveDown();
            UpdatePieceView();
        }

        public void MovePieceLeft()
        {
            if (_currentPiece == null || !_game.CanMove(_currentPiece, -1, 0))
            {
                return;
            }
            _currentPiece?.MoveLeft();
            UpdatePieceView();
        }

        public void MovePieceRight()
        {
            if (_currentPiece == null || !_game.CanMove(_currentPiece, 1, 0))
            {
                return;
            }
            _currentPiece?.MoveRight();
            UpdatePieceView();
        }

        internal bool CanMove(int deltaX, int deltaY)
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

        public void RotatePiece()
        {
            if (_currentPiece == null)
            {
                return;
            }

            var oldRotation = _currentPiece.RotationState;
            _currentPiece.Rotate(); // Try rotating first
            var newRotation = _currentPiece.RotationState;
            
            // If the rotated piece is valid, apply it
            if (_game.CanMove(_currentPiece, 0, 0))
            {
                UpdatePieceView();
                return;
            }

            // Use correct wall kick tests
            var wallKickTests = WallKickTests.GetWallKickTests(_currentPiece, oldRotation, newRotation);
            foreach (var (shiftX, shiftY) in wallKickTests)
            {
                if (!_currentPiece.GetSquarePositions()
                        .All(pos => _game.CanMove(_currentPiece, shiftX, shiftY)))
                {
                    continue;
                }
                _currentPiece.SetPosition(new Position(
                    _currentPiece.GetSquarePositions().First().X + shiftX, 
                    _currentPiece.GetSquarePositions().First().Y + shiftY
                ));
                UpdatePieceView();
                return;
            }

            // If all shifts fail, revert rotation
            Debug.WriteLine("Rotation failed: Out of bounds or collision.");
            _currentPiece.Rotate(); // Undo the rotation
        }
       
        
    }
}
