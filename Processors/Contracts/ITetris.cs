namespace TetrisGame.Processors.Contracts;

internal interface ITetris
{
    int Size { get; set; }
    
    void SetSquares();

    void SetLines();

    IEnumerable<ILine> GetLines();

    ILine GetLine(int index);


}