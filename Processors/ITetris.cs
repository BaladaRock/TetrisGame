namespace TetrisGame.Processors;

internal interface ITetris
{
    byte Size { get; set; }
    Square[,] Board { get; set; }

}