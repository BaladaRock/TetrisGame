using TetrisGame.Processors;

namespace TetrisGame.Views.Pieces
{
    public sealed class PieceView : Control
    {
        private readonly List<SquareView> _squares;
        private const int BlockSize = 30;

        public PieceView()
        {
            _squares = [];
            this.Size = new Size(BlockSize * 10, BlockSize * 20);
            this.BackColor = Color.Red;
            this.DoubleBuffered = true;
        }

        public void SetSquares(IEnumerable<Position> positions, Color color)
        {
            _squares.Clear();
            foreach (var pos in positions)
            {
                var square = new SquareView(new Point(pos.X, pos.Y), color);
                _squares.Add(square);
            }
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            foreach (var square in _squares)
            {
                square.Fill(e.Graphics);
            }
        }
    }

}