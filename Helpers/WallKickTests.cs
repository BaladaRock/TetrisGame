using TetrisGame.Processors.Base;
using TetrisGame.Processors.Implementations;

namespace TetrisGame.Helpers;

internal static class WallKickTests
{
    internal static List<(int, int)> GetWallKickTests(Piece piece, int currentRotation, int newRotation)
    {
        // Line Piece has its own special wall kicks
        if (piece is LinePiece)
        {
            Dictionary<(int, int), List<(int, int)>> wallKickTable = new()
            {
                { (0, 1), [(0, 0), (-2, 0), (1, 0), (-2, -1), (1, 2)] }, // 0 -> 180
                { (1, 0), [(0, 0), (-1, 0), (2, 0), (-1, 2), (2, -1)] }, // 180 -> 0
            };

            return wallKickTable.TryGetValue((currentRotation, newRotation), out var kicks)
                ? kicks
                : []; // Return empty list if not found
        }

        // Default Wall Kicks for Other Pieces
        Dictionary<(int, int), List<(int, int)>> generalWallKickTable = new()
        {
            { (0, 1), [(0, 0), (-1, 0), (1, 0), (0, -1), (0, 1)] }, // 0 -> 90
            { (1, 2), [(0, 0), (1, 0), (-1, 0), (0, -1), (0, 1)] }, // 90 -> 180
            { (2, 3), [(0, 0), (1, 0), (-1, 0), (0, -1), (0, 1)] }, // 180 -> 270
            { (3, 0), [(0, 0), (-1, 0), (1, 0), (0, -1), (0, 1)] } // 270 -> 0
        };

        return generalWallKickTable.TryGetValue((currentRotation, newRotation), out var generalKicks)
            ? generalKicks
            : [];
    }
}