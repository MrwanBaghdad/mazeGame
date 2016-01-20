using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeGame
{
    class GiftController
    {
        ArrayList cellsWithGifts;
        
        public GiftController (Maze maze)
        {
            cellsWithGifts = new ArrayList();
            PutGifts(maze);
            
        }

        private void PutGifts (Maze m)
        {
            Cell randomCell = getRandomCell(m);
            cellsWithGifts.Add(randomCell);
            randomCell.carries += "Gift";

            for (int i = 0; i < 10; i++)
            {
                randomCell = getCellFarFromCellsWithGifts(m);
                cellsWithGifts.Add(randomCell);
                randomCell.carries += "Gift";

            }
            
        }

        private static Cell getRandomCell(Maze m)
        {
            Random random = new Random();
            int row = random.Next(0, m.mazeSize);
            int col = random.Next(0, m.mazeSize);
            
            return m.cells[row, col];
        }
        private Cell getCellFarFromCellsWithGifts(Maze m)
        {
            Cell randomCell;
            do{
                randomCell = getRandomCell(m);
            }while(!isFarFromCellsWithGifts(randomCell,m));
            return randomCell;
        }
        private bool isFarFromCellsWithGifts(Cell givenCell,Maze m)
        {
            int howFar =(int) 0.5 * m.mazeSize;
            for (int i = 0; i < cellsWithGifts.Count; i++)
            {
                if (givenCell.distanceFrom((Cell)cellsWithGifts[i]) < howFar)
                {
                    return false;
                }
            }
            return true;
        }
        public void UpdateGifts (Maze m)
        {
            foreach (Cell item in m.cells)
            {
                if (item.carries.Contains("Gift") && item.carries.Contains("character"))
                {
                    item.carries = item.carries.Replace("Gift","");
                    GameController.updateScore(10);
                }
            }
        }
    }
}
