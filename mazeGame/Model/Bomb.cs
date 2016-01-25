using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeGame.View
{
    class Bomb : Dropping
    {
        public Bomb(Cell currentCell)
        {
            this.currentCell = currentCell;
            currentCell.carries += "bomb";
        }
    }
}
