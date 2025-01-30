using TetrisGame.Processors.Contracts;

namespace TetrisGame.Processors.Implementations;

public class Square(Position position) : ISquare
{
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
        return Colour == Colour.Empty;
    }

    public Position GetPosition()
    {
        var coordinates = position.GetCoordinates();
        return new Position(coordinates.x, coordinates.y);
    }

    public Colour Colour { get; set; }
}