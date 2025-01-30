using System.Drawing;

namespace TetrisGame.Processors.Contracts;

internal interface ISquare
{
    void FillWithColour(Colour colour);

    void EmptyFromColour();

    bool IsColoured();

    Position GetPosition();

    Colour Colour { get; set; }

}