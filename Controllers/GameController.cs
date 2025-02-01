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
            // Set up the model
            _game = tetrisGame;
            _currentPiece = _game.GetActivePiece();

            // Center the piece at the top of the grid
            var gridWidth = _game.Size / 2;
            var middleX = (gridWidth - 4) / 2;
            _currentPiece.SetPosition(new Position(middleX, 0));
            _currentPiece.UpdateSquares();

            // Set up the views
            _gameView = gameView;
            _pieceView = new PieceView();
            _gameView.SetPieceView(_pieceView);

            UpdatePieceView();

            _gameView.KeyDown += OnKeyDown!;
            _gameView.Activated += (sender, e) => _gameView.Focus();
            _gameTimer = gameTimer;
            _gameTimer.Tick += (sender, args) => MoveDown();
            _gameTimer.Start();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.A: _currentPiece.MoveLeft();
                    break;
                case Keys.D: _currentPiece.MoveRight();
                    break;
                case Keys.S: MoveDown();
                    break;
                case Keys.W: _currentPiece.MoveUp();
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
            var positions = _currentPiece.GetSquarePositions().ToList();
            _pieceView.SetSquares(positions, Helpers.ColourMapper.ToColor(_currentPiece.Colour));
        }
    }
}
