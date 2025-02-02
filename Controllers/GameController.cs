using System.Diagnostics;
using TetrisGame.Views;
using TetrisGame.Views.Pieces;
using Timer = System.Windows.Forms.Timer;
using TetrisGame.Processors.Implementations;

namespace TetrisGame.Controllers
{
    public class GameController
    {
        private readonly Game _game;
        private readonly GameView _gameView;
        private readonly PieceView _pieceView;
        private PieceController _pieceController;
        private Timer _gameTimer;

        public GameController(GameView gameView, Game tetrisGame, Timer gameTimer)
        {
            _game = tetrisGame;
            _gameView = gameView;
            _pieceView = new PieceView();
            _gameView.SetPieceView(_pieceView);

            _pieceController = new PieceController(_game, _pieceView);

            _gameView.KeyDown += OnKeyDown!;
            _gameView.Activated += (sender, e) => _gameView.Focus();

            _gameTimer = gameTimer;
            _gameTimer.Tick += (sender, args) => GameLoop();
            _gameTimer.Start();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            if (_game.ActivePiece == null)
            {
                return;
            }

            switch (e.KeyCode)
            {
                case Keys.A:
                case Keys.Left:
                    _pieceController.MovePieceLeft();
                    break;
                case Keys.D:
                case Keys.Right:    
                    _pieceController.MovePieceRight();
                    break;
                case Keys.S:
                case Keys.Down:
                    _pieceController.MovePieceDown();
                    break;
                case Keys.W:
                case Keys.Up:
                    _pieceController.RotatePiece();
                    break;
            }
        }

        private void GameLoop()
        {
            if (_pieceController.HasPieceLanded())
            {
                Debug.WriteLine("Piece reached the bottom. Generating new piece.");
                _game.ResetActivePiece();
                _pieceController.StorePiece();
                _pieceController.GenerateNewPiece();
                if (!_pieceController.CanMove(0, 0)) // If new piece collides immediately
                {
                    Debug.WriteLine("Game Over! A new piece collided at spawn.");
                }
            }
            else
            {
                _pieceController.MovePieceDown();
            }
        }
    }
}