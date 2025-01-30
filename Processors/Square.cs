namespace TetrisGame.Processors;

internal class Square(Position position)
{
    private Colour _colour = Colour.Empty;


    public void FillWithColour(Colour colour)
    {
        _colour = colour;
    }

    public bool IsColoured()
    {
        return _colour == Colour.Empty;
    }

    public Position GetCoordinates()
    {
        var coordinates = position.GetCoordinates();
        return new Position(coordinates.x, coordinates.y);
    }
}