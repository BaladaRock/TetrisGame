namespace TetrisGame.Processors.Contracts
{
    public interface ILine
    {
        int GetPosition();

        IEnumerable<ISquare> GetSquares();
        void AddSquare(ISquare square);
        void RefreshSquare(int position);

        void ClearLine();
        bool IsFull();

    }
}
