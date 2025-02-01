using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using TetrisGame.Processors;

namespace TetrisGame.Views.Pieces
{
    public sealed class PieceView : Control
    {
        private readonly List<SquareView> _squares;
        private const int BlockSize = 30;
        private const int BlockSpacing = 2;
        private readonly Color _defaultColor = Color.Cyan;

        public PieceView(byte numberOfSquares)
        {
            _squares = new List<SquareView>(numberOfSquares);
            DoubleBuffered = true;
            Size = new Size(4 * (BlockSize + BlockSpacing), BlockSize);
            BackColor = Color.Black;
        }

        public void SetSquares(IEnumerable<Position> positions, Color color)
        {
            _squares.Clear();
            foreach (var pos in positions)
            {
                _squares.Add(new SquareView(new Point(pos.X, pos.Y), color));
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (var square in _squares)
            {
                square.Draw(e.Graphics, BlockSpacing);
            }
        }
    }
}