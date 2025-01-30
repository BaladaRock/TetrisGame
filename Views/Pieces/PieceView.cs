namespace TetrisGame.Views.Pieces
{
    public sealed class PieceView : Control
    {
        private Piece _currentPiece;

        public PieceView()
        {
            DoubleBuffered = true;
            BackColor = Color.Black;
            _currentPiece = new LinePiece(new Point(3, 0)); // Create the piece
            Size = new Size(70, 10);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            _currentPiece.Draw(e.Graphics); // Draw the piece
        }

        public void UpdatePiece(Piece newPiece)
        {
            _currentPiece = newPiece;
            Invalidate();
        }
    }
}