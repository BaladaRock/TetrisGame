namespace TetrisGame.Processors.Contracts;

internal interface ITetris
{
    byte Size { get; set; }
    
    void SetSquares();

    void SetLines();

    IEnumerable<ILine> GetLines();

    ILine GetLine(byte index);


}