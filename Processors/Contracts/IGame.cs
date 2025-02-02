using TetrisGame.Processors.Implementations;

namespace TetrisGame.Processors.Contracts
{
    internal interface IGame
    {
        int Size { get; set; }

        void SetSquares();
        void SetLines();

        IEnumerable<ILine> GetLines();
        ILine GetLine(int index);

        void AddPieceToGrid(Piece? piece);

        IEnumerable<ILine> GetFullLines();
        void ClearFullLines();

        Piece? ActivePiece { get; set; }
    }
}