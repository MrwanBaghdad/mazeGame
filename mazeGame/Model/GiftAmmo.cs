using mazeGame.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeGame.Model
{
    class GiftAmmo : Dropping
    {
        public GiftAmmo(Cell currentCell)
        {
            this.currentCell = currentCell;
            currentCell.carries += "giftA";
        }
    }
}
