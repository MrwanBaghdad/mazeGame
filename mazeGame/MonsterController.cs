using Microsoft.Xna.Framework;
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
        bool canMove;
        double lastMoveWhen;
        double timePerMove;

        public MonsterController(Cell startCell)
        {
            startCell.carries += "monster";
            currentCell = startCell;
            currentCell.monsterVisited = true;
            monsterPath=new Stack<Cell>();
            monsterPath.Push(startCell);
            canMove = true;
            lastMoveWhen = 0;
            timePerMove = 0.2;
        }

        public void moveMonster(CharacterController character,GameTime gameTime)
        {
            canMove = gameTime.TotalGameTime.TotalSeconds - lastMoveWhen > timePerMove;

            if (currentCell != character.currentCell && canMove)
            {
                lastMoveWhen = gameTime.TotalGameTime.TotalSeconds;
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
                    if (monsterPath.Count > 0)
                    {
                        moveMonsterToCell(monsterPath.Peek());
                    }
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
