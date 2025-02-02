using TetrisGame.Utils;
using TetrisGame.Views.Pieces;

namespace TetrisGame.Views;

public sealed partial class GameView : Form
{
    private readonly Size _gameAreaSize = new(GameConstants.GridWidth * GameConstants.GridSize,
        GameConstants.GridHeight * GameConstants.GridSize);

    private PieceView? _pieceView;

    public GameView()
    {
        ClientSize = new Size(900, 600);
        FormBorderStyle = FormBorderStyle.FixedSingle;
        Text = @"Tetris";
        DoubleBuffered = true;
        BackColor = Color.AntiqueWhite;

        Paint += OnPaint!;
        Resize += OnResize!;
        KeyPreview = true;
    }

    public void SetPieceView(PieceView pieceView)
    {
        _pieceView = pieceView;
        _pieceView.Size = new Size(300, 600); // Ensure visibility
        _pieceView.Location = GetGameAreaOrigin();
        Controls.Add(_pieceView);
        _pieceView.BringToFront();
    }

    // Need to override this to enable the arrow key controls
    protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
    {
        OnKeyDown(new KeyEventArgs(keyData));
        return base.ProcessCmdKey(ref msg, keyData);
    }

    private void OnPaint(object sender, PaintEventArgs e)
    {
        RenderGameArea(e.Graphics);
    }

    private void OnResize(object sender, EventArgs e)
    {
        _pieceView!.Location = GetGameAreaOrigin();
        Invalidate();
    }

    private void RenderGameArea(Graphics graphics)
    {
        var origin = GetGameAreaOrigin();
        graphics.FillRectangle(
            Brushes.Black,
            origin.X,
            origin.Y,
            _gameAreaSize.Width,
            _gameAreaSize.Height
        );
    }

    private Point GetGameAreaOrigin()
    {
        return new Point(
            (ClientSize.Width - _gameAreaSize.Width) / 2,
            (ClientSize.Height - _gameAreaSize.Height) / 2
        );
    }
}