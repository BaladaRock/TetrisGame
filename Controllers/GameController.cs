using System.Diagnostics;
using TetrisGame.Views;
using TetrisGame.Processors.Implementations;
using TetrisGame.Views.Pieces;
using Timer = System.Windows.Forms.Timer;
using TetrisGame.Processors;

namespace TetrisGame.Controllers
{
    public class GameController
    {
        private readonly Game _game;
        private readonly GameView _gameView;
        private readonly PieceView _pieceView;
        private Piece _currentPiece;
        private Timer _gameTimer;

        public GameController(GameView gameView, Game tetrisGame, Timer gameTimer)
        {
            // Set up the models
            _game = tetrisGame;
            _currentPiece = _game.GetActivePiece();
            var middleX = (10 / 2) - (_currentPiece.GetSquares().Count() / 2);
            // For a 10x20 grid --- TO DO generic
            _currentPiece.SetPosition(new Position(middleX, 0));
            _currentPiece.UpdateSquares();
            
            
            // Set up the views
            _gameView = gameView;
            _pieceView = new PieceView(4);
            _gameView.SetPieceView(_pieceView);
            _gameView.PositionPieceView(_currentPiece.GetSquarePositions().First());
            _pieceView.SetSquares(
                _currentPiece.GetSquarePositions(),
                Helpers.ColourMapper.ToColor(_currentPiece.Colour)
            );
            _gameView.KeyDown += OnKeyDown!;
            _gameView.Activated += (sender, e) => _gameView.Focus();
            _gameTimer = gameTimer;
            //_gameTimer.Tick += (sender, args) => MoveDown();
            _gameTimer.Start();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            Debug.WriteLine($"Key Pressed: {e.KeyCode}");
            
            switch (e.KeyCode)
            {
                case Keys.A:
                    _currentPiece.MoveLeft();
                    break;
                case Keys.D:
                    _currentPiece.MoveRight();
                    break;
                case Keys.S:
                    _currentPiece.MoveDown();
                    break;
                case Keys.W:
                    _currentPiece.MoveUp();
                    break;
            }
            UpdatePieceView();
        }

        private void MoveDown()
        {
            _currentPiece.MoveDown();
            UpdatePieceView();
        }

        private void UpdatePieceView()
        {
            var firstPosition = _currentPiece.GetSquarePositions().FirstOrDefault();
            _gameView.PositionPieceView(firstPosition);
        }
    }
}