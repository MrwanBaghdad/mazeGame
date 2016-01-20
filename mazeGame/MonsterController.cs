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
        Stack<Cell> monsterPath;
        public MonsterController(Cell startCell)
        {
            startCell.carries += "monster";
            currentCell = startCell;
            currentCell.monsterVisited = true;
            monsterPath=new Stack<Cell>();
            monsterPath.Push(startCell);
        }

        public void moveMonster(CharacterController character)
        {
            if (currentCell != character.currentCell)
            {
                if (currentCell.hasMonsterUnvisitedNeighbours())
                {
                    Cell destination = currentCell.chooseNearestMonsterUnvisitedNeighbourTo(character.currentCell);
                    moveMonsterToCell(destination);
                    currentCell.monsterVisited = true;
                    monsterPath.Push(currentCell);
                }
                else
                {

                    monsterPath.Pop();
                    moveMonsterToCell(monsterPath.Peek());
                }
            }
        }
          
            
        
        
        private void moveMonsterToCell(Cell destination)
        {
            currentCell.carries = currentCell.carries.Replace("monster", "");
            currentCell = destination;
            currentCell.carries += "monster";
        }
    }
}
