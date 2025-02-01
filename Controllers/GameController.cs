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
        private readonly PieceController _pieceController;
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
            switch (e.KeyCode)
            {
                case Keys.A: _pieceController.MovePieceLeft();
                    break;
                case Keys.D: _pieceController.MovePieceRight();
                    break;
                case Keys.S: _pieceController.MovePieceDown();
                    break;
            }
        }

        private void GameLoop()
        {
            if (_pieceController.HasPieceLanded())
            {
                Debug.WriteLine("Piece reached the bottom. Generating new piece.");
                _pieceController.GenerateNewPiece();
            }
            else
            {
                _pieceController.MovePieceDown();
            }
        }
    }
}