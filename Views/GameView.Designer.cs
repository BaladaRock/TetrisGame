using TetrisGame.Views;

namespace TetrisGame
{
    partial class GameView
    {
        private System.ComponentModel.IContainer components = null;
        private PieceView pieceView;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.pieceView = new PieceView();
            SuspendLayout();

            // 
            // pieceView
            // 
            this.pieceView.Location = new Point(10, 10);
            this.pieceView.Size = new Size(280, 580);
            this.pieceView.BackColor = Color.White;
            this.pieceView.BorderStyle = BorderStyle.Fixed3D;
            // 
            // GameView
            // 
            this.AutoScaleDimensions = new SizeF(7F, 15F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new Size(300, 600);
            this.Controls.Add(this.pieceView);
            this.BackColor = Color.Gray;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.Name = "TetrisGame";
            this.Text = "Tetris";
            this.ResumeLayout(false);
        }

        #endregion
    }
}