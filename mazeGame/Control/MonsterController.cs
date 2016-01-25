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
        
        Cell currentCell;
        Stack<Cell> monsterPath;
        bool canMove;
        double lastMoveWhen;
        double timePerMove;
        Cell lastCharPlace;
        //fields for animation
        public static int currentImageName = 1;
        private static bool canChangeImage;
        private static double lastChangeWhen = 0;

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

        public void moveMonster(CharacterController character,GameTime gameTime,Maze m)
        {

            //control monster animation
            canChangeImage = gameTime.TotalGameTime.TotalSeconds - lastChangeWhen > 0.05;
            if (canChangeImage)
            {
                currentImageName = (currentImageName + 1) % 9;
                if (currentImageName == 0) { currentImageName++; }
                lastChangeWhen = gameTime.TotalGameTime.TotalSeconds;
            }
            if (monsterVisitedAll(m))
            {
                restartMonsterVisits(m);
            }
            canMove = gameTime.TotalGameTime.TotalSeconds - lastMoveWhen > timePerMove && GameController.gameHasStarted;
            if (currentCell.carries.Contains("bullet"))
            {
                moveMonsterToCell(m.cells[m.mazeSize - 1, 0]);
                GameController.updateScore(50);
            }
            else if (currentCell != character.currentCell && canMove)
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

                    
                    if (monsterPath.Count > 1)
                    {
                        monsterPath.Pop();
                        moveMonsterToCell(monsterPath.Peek());
                    }
                }
            }
        }
        private bool monsterVisitedAll(Maze m)
        {
            foreach (Cell x in m.cells)
            {
                if (x.monsterVisited == false)
                {
                    return false;
                }
            }
            return true;
        }

        private void restartMonsterVisits(Maze m)
        {
            foreach (Cell x in m.cells)
            {
                x.monsterVisited = false;
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
