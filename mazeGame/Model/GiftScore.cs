using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeGame.View
{
    class GiftScore : Dropping
    {
        public GiftScore(Cell currentCell)
        {
            this.currentCell = currentCell;
            currentCell.carries += "giftS";
        }
    }
}
