namespace TetrisGame.Views
{
    using System.Collections.Generic;
    using System.Drawing;

    public class Piece
    {
        public List<Point> Blocks { get; set; }
        public Color Color { get; set; }

        public Piece(Point startPosition)
        {
            Blocks = [];
            Color = Color.Red;

            Blocks.Add(startPosition);
            Blocks.Add(new Point(startPosition.X + 1, startPosition.Y));
            Blocks.Add(new Point(startPosition.X + 2, startPosition.Y));
            Blocks.Add(new Point(startPosition.X + 2, startPosition.Y - 1));
        }

        public void Draw(Graphics g)
        {
            const int blockSize = 30; // Set the size of a square
            const int blockSpacing = 5; // Set the space between the squares

            foreach (var block in Blocks)
            {
                var x = block.X * (blockSize + blockSpacing);
                var y = block.Y * (blockSize + blockSpacing);

                g.FillRectangle(new SolidBrush(Color), x, y, blockSize, blockSize);
                g.DrawRectangle(Pens.Black, x, y, blockSize, blockSize); // Draw a border for each graphical square
            }
        }

        public void Rotate()
        {
            var origin = Blocks[0];
            for (var i = 1; i < Blocks.Count; i++)
            {
                var x = Blocks[i].X - origin.X;
                var y = Blocks[i].Y - origin.Y;
                Blocks[i] = new Point(origin.X - y, origin.Y + x);
            }
        }
    }
}