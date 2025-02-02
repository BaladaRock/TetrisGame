namespace TetrisGame.Processors.Contracts
{
    internal interface IGame
    {
        int Size { get; set; }

        bool CanMove(IPiece piece, int deltaX, int deltaY);

        void SetSquares();
        void SetLines();

        IEnumerable<ILine> GetLines();
        ILine GetLine(int index);

        void AddPieceToGrid(IPiece? piece);

        IEnumerable<ILine> GetFullLines();
        void ClearFullLines();

        IPiece? ActivePiece { get; set; }
    }
}