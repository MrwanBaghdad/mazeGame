using mazeGame.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeGame.View
{
    class DroppingsFactory
    {
        static ArrayList cellswithDroppings=new ArrayList();
        static int whoseTurn = 0;
        public static Dropping putDropping(Maze m)
        {
            if (cellswithDroppings.Count == 0)
            {
                cellswithDroppings.Add(m.cells[0, 0]);
                cellswithDroppings.Add(m.cells[m.mazeSize - 1, 0]);
            }
            Random generator = new Random();
            whoseTurn = generator.Next(0,3);
            Dropping dropping;
            switch (whoseTurn){
            case 0:
                dropping = new GiftScore(getCellFarFromCellDroppings(m));
                cellswithDroppings.Add(dropping.currentCell);
                return dropping;
            case 1:
                dropping = new Bomb(getCellFarFromCellDroppings(m));
                cellswithDroppings.Add(dropping.currentCell);
                return dropping;
            case 2:
                dropping = new GiftAmmo(getCellFarFromCellDroppings(m));
                cellswithDroppings.Add(dropping.currentCell);
                return dropping;
            default:
                return null;
            }
            
            
        }
        private static Cell getRandomCell(Maze m)
        {
            Random random = new Random();
            int row = random.Next(0, m.mazeSize);
            int col = random.Next(0, m.mazeSize);

            return m.cells[row, col];
        }
        private static Cell getCellFarFromCellDroppings(Maze m)
        {
            Cell randomCell;
            do
            {
                randomCell = getRandomCell(m);
            } while (!isFarFromCellDroppings(randomCell, m));
            return randomCell;
        }
        private static bool isFarFromCellDroppings(Cell givenCell, Maze m)
        {
            int howFar = (int)(m.mazeSize*0.25);
            for (int i = 0; i < cellswithDroppings.Count; i++)
            {
                if (givenCell.distanceFrom((Cell)cellswithDroppings[i]) < howFar)
                {
                    return false;
                }
            }
            return true;
        }
        
    }
}
