using System;
using System.Collections.Generic;
using System.Linq;
using TetrisGame.Processors.Implementations;
using TetrisGame.Processors.Implementations.Pieces;

namespace TetrisGame.Helpers
{
    internal static class WallKickTests
    {
        internal static List<(int, int)> GetWallKickTests(Piece piece, int currentRotation, int newRotation)
        {
            if (piece is LinePiece)
            {
                Dictionary<(int, int), List<(int, int)>> wallKickTable = new()
                {
                    { (0, 1), [(0, 0), (-2, 0), (1, 0), (-2, -1), (1, 2)] },  // 0° → 90°
                    { (1, 2), [(0, 0), (-1, 0), (2, 0), (-1, 2), (2, -1)] },  // 90° → 180°
                    { (2, 3), [(0, 0), (2, 0), (-1, 0), (2, 1), (-1, -2)] },  // 180° → 270°
                    { (3, 0), [(0, 0), (1, 0), (-2, 0), (1, -2), (-2, 1)] }   // 270° → 0°
                };

                return wallKickTable.TryGetValue((currentRotation, newRotation), out var kicks)
                    ? kicks
                    : [];
            }

            // Default Wall Kicks for Other Pieces (T, L, J, S, Z)
            return [(0, 0), (1, 0), (-1, 0), (0, 1), (0, -1)];
        }
    }
}
