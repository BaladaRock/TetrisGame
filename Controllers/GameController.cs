using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TetrisGame.Views;
using TetrisGame.Processors.Implementations;
using TetrisGame.Views.Pieces;
using Timer = System.Windows.Forms.Timer;

namespace TetrisGame.Controllers
{
    public class GameController
    {
        private readonly Processors.Implementations.TetrisGame _game;
        private readonly GameView _gameView;
        private readonly PieceView _pieceView;
        private LinePiece _currentPiece;
        private readonly Timer _gameTimer;

        public GameController(GameView gameView, PieceView pieceView)
        {
            _game = new Processors.Implementations.TetrisGame(20);
            _gameView = gameView;
            _pieceView = pieceView;
            _currentPiece = new LinePiece();
            _gameView.KeyDown += OnKeyDown!;
            //_pieceView.SetSquares(_currentPiece.GetSquarePositions(), Color.Cyan);
            _gameTimer = new Timer { Interval = 500 };
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
            //_pieceView.SetSquares(_currentPiece.GetSquarePositions(), Color.Cyan);
        }

        private void MoveDown()
        {
            _currentPiece.MoveDown();
            //_pieceView.SetSquares(_currentPiece.GetSquarePositions(), Color.Cyan);
        }
    }
}