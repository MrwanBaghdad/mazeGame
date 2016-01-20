using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace mazeGame
{
    class BulletController
    {
        
        public  bool hasBeenFired;
        public Cell current;
        int steps;
        int maxsteps = 5;
        

        public BulletController() //constructor
        {
            hasBeenFired = true;
            steps = 0;
            
        }

        public void FireBullet(Cell cellbullet, KeyboardState keyState, GameTime gameTime, string direction)
        {
            current = cellbullet;
            
            if (keyState.IsKeyDown(Keys.Z))
            {
                hasBeenFired = true;

                while (steps < maxsteps && direction == "flagright" && current.walls.right == false)
                    {
                      
                        this.fireRight();
                        steps++;
                    }

                while (steps < maxsteps && direction == "flagleft" && current.walls.left == false)
                {
                    this.fireLeft();
                    steps++;
                }

                while (steps < maxsteps && direction == "flagup" && current.walls.up == false)
                {
                    this.fireUp();
                    steps++;
                }

                while (steps < maxsteps && direction == "flagdown" && current.walls.down == false)
                {
                    this.fireDown();
                    steps++;
                }

                steps = 0;
                }
            }
        


        private void fireUp()
        {
            current.carries = current.carries.Replace("bullet", "");
            current.neighbours.up.carries += "bullet";
            current = current.neighbours.up;
            //needs delay first
            //if (steps == 4 || current.walls.up == true)
            //{
            //    current.neighbours.right.carries = current.carries.Replace("bullet", "");
            //}
        }

        private void fireDown()
        {
           current.carries = current.carries.Replace("bullet", "");
           current.neighbours.down.carries += "bullet";
           current = current.neighbours.down;
            //needs delay first 
           //if (steps == 4 || current.walls.down == true)
           //{
           //    current.neighbours.right.carries = current.carries.Replace("bullet", "");
           //}
        }

        public void fireRight()
        {
            current.carries = current.carries.Replace("bullet", "");
            current.neighbours.right.carries += "bullet";
            current = current.neighbours.right;
           //needs delay first
            //if (steps == 4 || current.walls.right == true)
            //{
            //    current.neighbours.right.carries = current.carries.Replace("bullet", "");
            //}
         }
        

        private void fireLeft()
        {
            current.carries = current.carries.Replace("bullet", "");
            current.neighbours.left.carries += "bullet";
            current = current.neighbours.left;
            //needs delay first
            //if (steps == 4 || current.walls.left == true)
            //{
            //    current.neighbours.right.carries = current.carries.Replace("bullet", "");
            //}
         }
        }
    }

