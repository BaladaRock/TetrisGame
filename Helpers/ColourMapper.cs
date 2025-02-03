using TetrisGame.Processors;

namespace TetrisGame.Helpers
{
    public static class ColourMapper
    {
        public static Color ToColor(Colour colour)
        {
            return colour switch
            {
                Colour.Red => Color.Red,
                Colour.Green => Color.Green,
                Colour.Blue => Color.Blue,
                Colour.Yellow => Color.Yellow,
                Colour.Turquoise => Color.Turquoise,
                Colour.Orange => Color.Orange,
                Colour.Purple => Color.Purple,
                Colour.Empty => Color.Red,
                _ => throw new ArgumentOutOfRangeException(nameof(colour), colour, "Unexpected colour value.")
            };
        }
    }
}