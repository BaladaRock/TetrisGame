using TetrisGame.Views.Pieces;

namespace TetrisGame
{
    partial class GameView
    {
        private System.ComponentModel.IContainer components = null;
        private PieceView pieceView;
        private readonly Size gameAreaSize = new Size(280, 580); // The fixed dimensions of the game area

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.pieceView = new PieceView();
            SuspendLayout();

            // 
            // pieceView
            // 
            this.pieceView.Size = new Size(275, 40); // The size of the piece

            // 
            // GameView
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(900, 600); // The initial size of the window
            this.Controls.Add(this.pieceView);
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Name = "TetrisGame";
            this.Text = "Tetris";

            this.Resize += GameView_Resize;

            this.ResumeLayout(false);
            CenterGameView();
        }

        private void GameView_Resize(object sender, EventArgs e)
        {
            CenterGameView();
            Invalidate();
        }

        private void CenterGameView()
        {
            var gameAreaX = (this.ClientSize.Width - gameAreaSize.Width) / 2;
            var gameAreaY = (this.ClientSize.Height - gameAreaSize.Height) / 2;

            var pieceX = gameAreaX + (gameAreaSize.Width - pieceView.Width) / 2;
            var pieceY = gameAreaY + 1; // Adjust the Y position to move the piece down

            pieceView.Location = new Point(pieceX, pieceY);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            e.Graphics.FillRectangle(Brushes.AntiqueWhite, 0, 0, this.ClientSize.Width, this.ClientSize.Height);

            var gameAreaX = (this.ClientSize.Width - gameAreaSize.Width) / 2;
            var gameAreaY = (this.ClientSize.Height - gameAreaSize.Height) / 2;

            // Draw the black background for the game area
            e.Graphics.FillRectangle(Brushes.Black, gameAreaX, gameAreaY, gameAreaSize.Width, gameAreaSize.Height);
            // Draw the black border for the game area
            e.Graphics.DrawRectangle(Pens.Black, gameAreaX, gameAreaY, gameAreaSize.Width, gameAreaSize.Height);
        }
    }
}
