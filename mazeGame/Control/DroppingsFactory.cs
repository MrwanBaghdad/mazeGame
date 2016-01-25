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
        static bool giftTurn = false;
        public static Dropping putDropping(Maze m)
        {
            giftTurn = !giftTurn;
            Dropping dropping;
            Debug.WriteLine(cellswithDroppings.Count);
            if (giftTurn)
            {

                dropping = new Gift(getCellFarFromCellDroppings(m));
                cellswithDroppings.Add(dropping.currentCell);
                return dropping;
            }
            else
            {
                
                dropping = new Bomb(getCellFarFromCellDroppings(m));
                cellswithDroppings.Add(dropping.currentCell);
                return dropping;
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
            int howFar = 5;
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
