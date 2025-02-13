﻿using TetrisGame.Processors.Contracts;

namespace TetrisGame.Processors.Implementations
{
    public class Square(Position position) : ISquare
    {
        public Position Position { get; set; } = position;
        public Colour Colour { get; set; } = Colour.Empty;

        public void FillWithColour(Colour colour)
        {
            Colour = colour;
        }

        public void EmptyFromColour()
        {
            Colour = Colour.Empty;
        }

        public bool IsColoured()
        {
            return Colour != Colour.Empty;
        }
    }
}