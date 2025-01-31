using TetrisGame.Processors;

namespace TetrisGame.Helpers
{
    public static class ColorMapper
    {
        public static Color ToColor(Colour colour)
        {
            return colour switch
            {
                Colour.Red => Color.Red,
                Colour.Green => Color.Green,
                Colour.Blue => Color.Blue,
                Colour.Yellow => Color.Yellow,
                Colour.Empty => Color.Transparent,
                _ => throw new ArgumentOutOfRangeException(nameof(colour), colour, "Unexpected colour value.")
            };
        }
    }
}