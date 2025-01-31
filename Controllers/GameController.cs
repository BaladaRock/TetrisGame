using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using TetrisGame.Views;
using TetrisGame.Processors.Implementations;
using Timer = System.Windows.Forms.Timer;

namespace TetrisGame.Controllers
{
    public class GameController
    {
        private readonly Processors.Implementations.TetrisGame _game;
        private readonly GameView _gameView;
        private LinePiece _currentPiece;
        private Timer? _gameTimer;

        public GameController(GameView gameView)
        {
            _game = new Processors.Implementations.TetrisGame(20);
            _gameView = gameView;
            _currentPiece = new LinePiece();
            _gameView.KeyDown += OnKeyDown;
            _gameView.RenderGame(_game.GetLines());
            StartGameLoop();
        }

        private void StartGameLoop()
        {
            _gameTimer = new Timer { Interval = 500 };
            _gameTimer.Tick += (sender, args) => MoveDown();

            _gameTimer.Start();
        }

        private void OnKeyDown(object? sender, KeyEventArgs e)
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
                default:
                    _currentPiece.SetSquares();
                    break;
            }
            _gameView.RenderGame(_game.GetLines());
        }

        private void MoveDown()
        {
            _currentPiece.MoveDown();
            _gameView.RenderGame(_game.GetLines());
        }
    }
}