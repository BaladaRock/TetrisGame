using TetrisGame.Views.Pieces;

namespace TetrisGame
{
    partial class GameView
    {
        private System.ComponentModel.IContainer components = null;
        private PieceView pieceView;
        private readonly Size gameAreaSize = new Size(280, 580); // Fixed game area size
        private const int blockSize = 30; // Size of a single block

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
            AdjustPieceView();
            Invalidate();
        }

        private void AdjustPieceView()
        {
            // Calculate the width of PieceView to match the width of the game area
            int pieceViewWidth = gameAreaSize.Width;

            // Set PieceView height based on a row of blocks
            int pieceViewHeight = blockSize;

            // Update size of PieceView
            pieceView.Size = new Size(pieceViewWidth, pieceViewHeight);

            // Calculate PieceView position inside the game area
            var gameAreaX = (this.ClientSize.Width - gameAreaSize.Width) / 2;
            var gameAreaY = (this.ClientSize.Height - gameAreaSize.Height) / 2;

            int pieceX = gameAreaX;
            int pieceY = gameAreaY;

            // Update PieceView location
            pieceView.Location = new Point(pieceX, pieceY);
        }

        private void CenterGameView()
        {
            // Adjust the position of the game area to be centered
            var gameAreaX = (this.ClientSize.Width - gameAreaSize.Width) / 2;
            var gameAreaY = (this.ClientSize.Height - gameAreaSize.Height) / 2;

            pieceView.Location = new Point(gameAreaX, gameAreaY); // Place PieceView relative to game area
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Fill background with a neutral color
            e.Graphics.FillRectangle(Brushes.AntiqueWhite, 0, 0, this.ClientSize.Width, this.ClientSize.Height);

            var gameAreaX = (this.ClientSize.Width - gameAreaSize.Width) / 2;
            var gameAreaY = (this.ClientSize.Height - gameAreaSize.Height) / 2;

            // Draw the black background for the game area
            e.Graphics.FillRectangle(Brushes.Black, gameAreaX, gameAreaY, gameAreaSize.Width, gameAreaSize.Height);

            // Draw the border for the game area
            e.Graphics.DrawRectangle(Pens.Black, gameAreaX, gameAreaY, gameAreaSize.Width, gameAreaSize.Height);
        }
    }
}
