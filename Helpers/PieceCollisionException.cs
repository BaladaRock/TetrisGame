namespace TetrisGame.Helpers;

public class PieceCollisionException : Exception
{
    public PieceCollisionException() : base("A newly generated piece has collided with another piece. Game Over!") { }

    public PieceCollisionException(string message) : base(message) { }

    public PieceCollisionException(string message, Exception innerException)
        : base(message, innerException) { }
}
