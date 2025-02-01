using TetrisGame.Processors;
using TetrisGame.Utils;

namespace TetrisGame.Views.Pieces
{
    public sealed class PieceView : Control
    {
        private readonly List<SquareView> _squares;

        public PieceView()
        {
            _squares = [];
            DoubleBuffered = true;
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            BackColor = Color.Transparent;
        }

        public void SetSquares(IEnumerable<Position> positions, Color color)
        {
            _squares.Clear();

            foreach (var pos in positions)
            {
                var screenX = pos.X * (GameConstants.BlockSize + GameConstants.BlockSpacing);
                var screenY = pos.Y * (GameConstants.BlockSize + GameConstants.BlockSpacing);
                _squares.Add(new SquareView(new Point(screenX, screenY), color));
            }

            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (var square in _squares)
            {
                square.Draw(e.Graphics);
            }
        }
    }
}