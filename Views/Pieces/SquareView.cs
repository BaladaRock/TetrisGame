﻿using System.Drawing;

namespace TetrisGame.Views.Pieces
{
    public class SquareView(Point position, Color colour)
    {
        private const int BlockSize = 29;
        public Point Position { get; } = position;
        public Color Color { get; } = colour;

        public void Draw(Graphics graphics, int spacing)
        {
            var x = Position.X * (BlockSize + spacing);
            var y = Position.Y * (BlockSize + spacing);
            var rect = new Rectangle(x, y, BlockSize, BlockSize);

            using var brush = new SolidBrush(Color);
            graphics.FillRectangle(brush, rect);
            graphics.DrawRectangle(Pens.Black, rect);
        }
    }
}