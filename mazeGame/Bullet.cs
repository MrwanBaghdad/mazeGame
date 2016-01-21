using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeGame
{
    class Bullet
    {
        Cell currentCell;
        string direction;
        public Bullet(Cell startCell,string firedFrom)
        {
            this.currentCell = startCell;
            this.direction = firedFrom;
        }
        public void move()
        {
            switch (direction)
            {
                case "up":
                    moveUp();
                    break;
                case "down":
                    moveDown();
                    break;
                case "right":
                    moveRight();
                    break;
                case "left":
                    moveLeft();
                    break;

            }
        }
        private void moveUp()
        {
            if (currentCell.walls.up == false) { 
            currentCell.carries = currentCell.carries.Replace("bullet", "");
            currentCell.neighbours.up.carries += "bullet";
            currentCell = currentCell.neighbours.up;

            }
            else
            {
                currentCell.carries = currentCell.carries.Replace("bullet", "");
                
            }

        }

        private void moveDown()
        {
            if (currentCell.walls.down == false)
            {
                currentCell.carries = currentCell.carries.Replace("bullet", "");
                currentCell.neighbours.down.carries += "bullet";
                currentCell = currentCell.neighbours.down;
            }
            else
            {
                currentCell.carries = currentCell.carries.Replace("bullet", "");

            }
        }

        public void moveRight()
        {
            if (currentCell.walls.right == false) { 
            currentCell.carries = currentCell.carries.Replace("bullet", "");
            currentCell.neighbours.right.carries += "bullet";
            currentCell = currentCell.neighbours.right;
            }
            else
            {
                currentCell.carries = currentCell.carries.Replace("bullet", "");

            }
        }


        private void moveLeft()
        {
            if (currentCell.walls.left == false) { 
            currentCell.carries = currentCell.carries.Replace("bullet", "");
            currentCell.neighbours.left.carries += "bullet";
            currentCell = currentCell.neighbours.left;
            }
            else
            {
                currentCell.carries = currentCell.carries.Replace("bullet", "");

            }
        }
    }
}
