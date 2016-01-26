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

        public Cell currentCell;
        ArrayList monsterPath;
        bool canMove;
        double lastMoveWhen;
        double timePerMove;
        Cell lastCharCell;

        //fields for animation
        public static int currentImageName = 1;
        private static bool canChangeImage;
        private static double lastChangeWhen = 0;

        public MonsterController(Cell startCell)
        {
            startCell.carries += "monster";
            currentCell = startCell;
            canMove = true;
            lastMoveWhen = 0;
            timePerMove = 0.5;

        }

        public void moveMonster(CharacterController character, GameTime gameTime, Maze m)
        {

            //control monster animation
            canChangeImage = gameTime.TotalGameTime.TotalSeconds - lastChangeWhen > 0.05;
            if (canChangeImage)
            {
                currentImageName = (currentImageName + 1) % 9;
                if (currentImageName == 0) { currentImageName++; }
                lastChangeWhen = gameTime.TotalGameTime.TotalSeconds;
            }


            canMove = gameTime.TotalGameTime.TotalSeconds - lastMoveWhen > timePerMove-0.05*GameController.level && GameController.gameHasStarted;
            //handle when Monster is Killed
            if (currentCell.carries.Contains("bullet"))
            {
                moveMonsterToCell(getRandomCorner(m));
                restartMonsterVisits(m);
                monsterPath = null;
                GameController.updateScore(50);
            }
            //if no monsterPath has been calculated
            if (monsterPath == null && canMove)
            {
                monsterPath = choosePathTo(character, m);
            }

            //handle Monster Movements
            //first if the character hasn't moved stay on your path
            if (lastCharCell == character.currentCell && canMove)
            {

                lastMoveWhen = gameTime.TotalGameTime.TotalSeconds;
                if (currentCell.hasReachableMonsterUnvisitedNeighbours())
                {
                    if (monsterPath.Count > 0)
                    {
                        moveMonsterToCell((Cell)monsterPath[0]);
                        monsterPath.RemoveAt(0);
                    }
                }

            }
            //secondly if the character moved restart path calculation
            else if (lastCharCell != character.currentCell && canMove)
            {
                monsterPath = choosePathTo(character, m);
            }

            //handle when character is killed 
            if (currentCell == character.currentCell)
            {
                CharacterController.isDead = true;
                CharacterController.currentImageName = 1;
                GameController.gameHasStarted=false;
                GameController.level = 1;
                moveMonsterToCell(m.cells[m.mazeSize-1, 0]);
            }
            lastCharCell = character.currentCell;
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
        private ArrayList choosePathTo(CharacterController character, Maze m)
        {
            Cell current = this.currentCell;
            current.monsterVisited = true;
            Stack<Cell> chosenPath = new Stack<Cell>();

            while (current != character.currentCell)
            {
                chosenPath.Push(current);
                if (current.hasReachableMonsterUnvisitedNeighbours())
                {
                    current = current.getReachableMonsterUnvisitedNeighbour();
                    current.monsterVisited = true;
                }
                else
                {
                    chosenPath.Pop();
                    current = chosenPath.Pop();
                }
            }

            chosenPath.Push(character.currentCell);
            restartMonsterVisits(m);
            Cell[] savePath = chosenPath.ToArray<Cell>();
            Array.Reverse(savePath);
            ArrayList result = cellArraytoArrayList(savePath);
            result.RemoveAt(0);
            return result;

        }
        private ArrayList cellArraytoArrayList(Cell[] array)
        {
            ArrayList result = new ArrayList();
            foreach (Cell c in array)
            {
                result.Add(c);
            }
            return result;
        }
        private static Cell getRandomCorner(Maze m)
        {
            Random generator = new Random();
            int rndNum = generator.Next(0, 2);
            switch (rndNum)
            {
                case 0:
                    return m.cells[m.mazeSize - 1, 0];
                case 1:
                    return m.cells[0, m.mazeSize - 1];
                default:
                    return m.cells[0, 0];
            }
        }
    }
}
