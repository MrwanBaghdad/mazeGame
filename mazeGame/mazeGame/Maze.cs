using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace mazeGame
{
    class Maze
    {
        public Cell[,] cells;
        public Maze()
        {
            cells = new Cell[30, 30];
        }
    }
}
