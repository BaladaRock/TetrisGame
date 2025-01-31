namespace TetrisGame.Views.Pieces;

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

        InitializeSquares();
    }

    private void InitializeSquares()
    {
        _squares.Clear();
        for (var i = 0; i < 4; i++)
        {
            var pos = new Point(i, 0);
            _squares.Add(new SquareView(pos, _defaultColor));
        }

        Invalidate();
    }

    public void SetSquares(IEnumerable<Point> positions, Color color)
    {
        _squares.Clear();
        foreach (var pos in positions) _squares.Add(new SquareView(pos, color));

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