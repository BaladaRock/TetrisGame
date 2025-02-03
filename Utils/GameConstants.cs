namespace TetrisGame.Utils
{
    public static class GameConstants
    {
        // Block settings
        public const byte BlockSize = 29; // Size of each square
        public const byte BlockSpacing = 1; // Space between squares

        // Grid settings
        public const byte GridWidth = 10;  // Number of columns
        public const byte GridHeight = 20; // Number of rows
        public const byte GridSize = 30;

        // Piece settings
        public const byte PieceWidth = 4;  // Default width of a piece
        public const byte GridMiddlePoint = 4;

        // GameView settings
        public const short WindowWidth = 900;
        public const short WindowHeight = 600;
    }
}