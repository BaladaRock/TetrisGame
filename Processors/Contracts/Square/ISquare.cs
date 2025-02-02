namespace TetrisGame.Processors.Contracts;

public interface ISquare
{
    void FillWithColour(Colour colour);

    void EmptyFromColour();

    bool IsColoured();

    Position Position { get; set; }

    Colour Colour { get; set; }

}