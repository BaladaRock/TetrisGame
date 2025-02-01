using System.Drawing;
using TetrisGame.Controllers;
using TetrisGame.Processors;
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
        private const byte PieceSize = 4;
        private readonly Size _gameAreaSize = new(GridWidth * BlockSize, GridHeight * BlockSize);
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
            
            //this.Focus();
        }

        public void SetPieceView(PieceView pieceView)
        {
            _pieceView = pieceView;
            Controls.Add(_pieceView);
            PositionPieceView(new Position(3, 0));
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            RenderGameArea(e.Graphics);
        }

        private void OnResize(object sender, EventArgs e)
        {
            PositionPieceView(new Position(3, 0));
            Invalidate();
        }

        //protected override void OnActivated(EventArgs e)
        //{
        //    base.OnActivated(e);
        //    this.Focus();
        //}

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

            //_pieceView.RenderSquares(graphics);
            //_pieceView = new PieceView();
            //_pieceView.Location = new Point(gameAreaX, gameAreaY);
        }

        public void PositionPieceView(Position position)
        {
            _pieceView.Location = new Point(
                (ClientSize.Width - (GridWidth * BlockSize)) / 2 + position.X * BlockSize,
                (ClientSize.Height - (GridHeight * BlockSize)) / 2 + position.Y * BlockSize + GridHeight
            );
        }

    }
}