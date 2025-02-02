using TetrisGame.Processors;
using TetrisGame.Utils;

namespace TetrisGame.Views.Pieces
{
    public sealed class PieceView : Control
    {
        private readonly List<SquareView> _squares = [];
        private readonly List<SquareView> _landedSquares = []; // Store landed squares

        public PieceView()
        {
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

        public void AddLandedSquares(IEnumerable<Position> positions, Color color)
        {
            foreach (var pos in positions)
            {
                var screenX = pos.X * (GameConstants.BlockSize + GameConstants.BlockSpacing);
                var screenY = pos.Y * (GameConstants.BlockSize + GameConstants.BlockSpacing);
                _landedSquares.Add(new SquareView(new Point(screenX, screenY), color));
            }
            Invalidate(); // Redraw only when landed squares change
        }


        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (var square in _landedSquares) // Draw landed pieces first
            {
                square.Draw(e.Graphics);
            }

            foreach (var square in _squares) // Draw moving piece on top
            {
                square.Draw(e.Graphics);
            }
        }
    }
}