using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeGame.View
{
    class Gift : Dropping
    {
        public Gift(Cell currentCell)
        {
            this.currentCell = currentCell;
            currentCell.carries += "gift";
        }
    }
}
