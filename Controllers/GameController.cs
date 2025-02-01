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
            _gameView = gameView;
            _game = tetrisGame;
            _pieceView = new PieceView(4);
            _gameView.SetPieceView(_pieceView);
            
            _currentPiece = _game.GetActivePiece();
            _currentPiece.SetPosition(new Position(3, 0));
            
            _gameView.KeyDown += OnKeyDown!;
            _pieceView.SetSquares(
                _currentPiece.GetSquarePositions(),
                Helpers.ColourMapper.ToColor(_currentPiece.PieceColour)
            );

            _gameView.Activated += (sender, e) => _gameView.Focus();

            _gameTimer = gameTimer;
            _gameTimer.Tick += (sender, args) => MoveDown();
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
                default:
                    _currentPiece.MoveDown();
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
            //_pieceView.SetSquares(_currentPiece.GetSquarePositions(), Color.Cyan);
        }
    }
}