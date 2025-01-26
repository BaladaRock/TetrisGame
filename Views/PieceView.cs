#nullable disable

namespace TetrisGame.Views;

public class PieceView : Control
{
    private Piece currentPiece;
    private BorderStyle borderStyle;

    public PieceView()
    {
        this.DoubleBuffered = true;
        this.currentPiece = new LinePiece(new Point(5, 5));
        this.borderStyle = BorderStyle.None;
    }

    public BorderStyle BorderStyle
    {
        get => borderStyle;
        set
        {
            if (borderStyle == value)
            {
                return;
            }

            borderStyle = value;
            Invalidate();
        }
    }

    protected override void OnPaint(PaintEventArgs e)
    {
        base.OnPaint(e);
        currentPiece.Draw(e.Graphics, 10, 5);

        if (borderStyle == BorderStyle.None)
        {
            return;
        }

        using var borderPen = new Pen(Color.Black, 3);
        e.Graphics.DrawRectangle(borderPen, 0, 0, this.Width - 1, this.Height - 1);
    }

    public void UpdatePiece(Piece newPiece)
    {
        currentPiece = newPiece;
        Invalidate();
    }
}