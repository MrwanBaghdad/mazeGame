using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeGame
{
    class MonsterController 
    {
        //to be added afterwards 
        Texture2D image;
        Cell currentCell;
        string lastDirection;
        public MonsterController(Cell startCell)
        {
            startCell.carries += "monster";
            currentCell = startCell;
        }

        public void moveMonster()
        {
            Random generator = new Random();
            ArrayList cellsICanMoveTo = currentCell.getNeighboursICanMoveTo();
            Cell moveTo = (Cell)cellsICanMoveTo[generator.Next(0, cellsICanMoveTo.Count)];
            //todo make the monster search for a path to the player then move according to it
            currentCell.carries = currentCell.carries.Replace("monster", "");
            currentCell = moveTo;
            currentCell.carries += "monster";
        }
    }
}
