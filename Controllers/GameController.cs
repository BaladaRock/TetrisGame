using TetrisGame.Views;
using TetrisGame.Processors.Implementations;
using TetrisGame.Views.Pieces;
using Timer = System.Windows.Forms.Timer;

namespace TetrisGame.Controllers
{
    public class GameController
    {
        private readonly Game _game;
        private readonly GameView _gameView;
        private readonly PieceView _pieceView;
        private LinePiece _currentPiece;
        private Timer _gameTimer;

        public GameController(GameView gameView, Game tetrisGame, Timer gameTimer)
        {
            _gameView = gameView;
            _game = tetrisGame;
            _pieceView = new PieceView(4);
            _gameView.SetPieceView(_pieceView);
            
            _currentPiece = new LinePiece();
            _gameView.KeyDown += OnKeyDown!;
            _pieceView.SetSquares(_currentPiece.GetSquarePositions(), Color.Cyan);
            
            _gameTimer = gameTimer;
            _gameTimer.Tick += (sender, args) => MoveDown();
            _gameTimer.Start();
        }

        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.Left:
                    _currentPiece.MoveLeft();
                    break;
                case Keys.Right:
                    _currentPiece.MoveRight();
                    break;
                case Keys.Down:
                    MoveDown();
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