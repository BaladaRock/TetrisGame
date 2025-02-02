using TetrisGame.Processors.Contracts;

namespace TetrisGame.Processors.Implementations;

public class Square : ISquare
{
    public Square(Position position)
    {
        Position = position;
    }
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
        return Position;
    }
    
    public Position Position { get; set; }

    public Colour Colour { get; set; }
}