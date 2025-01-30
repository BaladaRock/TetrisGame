using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TetrisGame.Processors
{
    internal class TetrisGame(byte size) : ITetris
    {
        byte ITetris.Size { get; set; } = size;
        
        public Square[,] Board { get; set; }
       
    }
}
