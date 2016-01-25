using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeGame
{
    class Bullet
    {
        Cell currentCell;
        string direction;
        //object pool DP Implementation is here
        private static Bullet[] instances=new Bullet[20];
        private static int currentIndex=0;
        private Bullet(Cell startCell,string firedFrom)
        {
            this.currentCell = startCell;
            this.direction = firedFrom;
        }
        public static Bullet getInstance(Cell givenCell,String firedFrom)
        {
            currentIndex = (currentIndex + 1) % 20;
            Debug.WriteLine(currentIndex);
            if (instances[currentIndex] == null)
            {
                instances[currentIndex] = new Bullet(givenCell,firedFrom);
                return instances[currentIndex];
            }
            else
            {
                instances[currentIndex].currentCell = givenCell;
                instances[currentIndex].direction = firedFrom;
                return instances[currentIndex];
            }

        }
        public static void moveAll()
        {
            foreach (Bullet b in instances)
            {
                if (b != null)
                {
                    b.move();
                }
            }
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
