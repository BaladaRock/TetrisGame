using System.Drawing;
using TetrisGame.Processors.Contracts;
using TetrisGame.Views.Pieces;

namespace TetrisGame.Views
{
    public sealed partial class GameView : Form
    {
        private const int GridWidth = 10;
        private const int GridHeight = 20;
        private const int BlockSize = 30;
        private const int PaddingSize = 40; // Padding to separate the game area from the window edges
        private readonly Size _gameAreaSize = new(GridWidth * BlockSize, GridHeight * BlockSize);
        private const byte PieceSize = 4;
        private PieceView _pieceView;

        public GameView()
        {
            this.ClientSize = new Size(900, 600);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Text = @"Tetris";
            this.DoubleBuffered = true;
            this.BackColor = Color.AntiqueWhite;

            this.Paint += OnPaint!;
            this.Resize += OnResize!;
            this.KeyPreview = true;

            _pieceView = new PieceView();
            Controls.Add(_pieceView);
            PositionPieceView();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            RenderGameArea(e.Graphics);
        }

        private void OnResize(object sender, EventArgs e)
        {
            Invalidate();
            PositionPieceView();
        }

        protected override void OnActivated(EventArgs e)
        {
            base.OnActivated(e);
            this.Focus();
        }

        private void RenderGameArea(Graphics graphics)
        {
            var gameAreaX = (ClientSize.Width - _gameAreaSize.Width) / 2;
            var gameAreaY = (ClientSize.Height - _gameAreaSize.Height - PaddingSize) / 2;

            graphics.FillRectangle(
                Brushes.Black,
                gameAreaX,
                gameAreaY + PaddingSize,
                _gameAreaSize.Width,
                _gameAreaSize.Height - PaddingSize);
            graphics.DrawRectangle(
                Pens.White,
                gameAreaX,
                gameAreaY + PaddingSize,
                _gameAreaSize.Width - 1,
                _gameAreaSize.Height - PaddingSize - 1);

            PositionPieceView();
            //_pieceView = new PieceView();
            //_pieceView.Location = new Point(gameAreaX, gameAreaY);
        }

        private void PositionPieceView()
        {
            var gameAreaX = (ClientSize.Width - _gameAreaSize.Width) / 2;
            var gameAreaY = (ClientSize.Height - _gameAreaSize.Height) / 2;

            _pieceView.Location = new Point(gameAreaX, gameAreaY);
            _pieceView.Size = new Size(_gameAreaSize.Width, BlockSize * 2);
        }

    }
}