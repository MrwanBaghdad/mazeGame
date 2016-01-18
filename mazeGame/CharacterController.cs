using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mazeGame
{
    class CharacterController
    {
        Texture2D charImage;
        Cell currentCell;
        bool canMove;
        double lastMoveWhen = 0;
        public CharacterController(Cell startCell)
        {
            currentCell = startCell;
            startCell.carries = "character";
            canMove = true;
            
        }
        
        public void moveCharacter( KeyboardState keyState,GameTime gameTime)
        {
            canMove = gameTime.TotalGameTime.TotalSeconds - lastMoveWhen > 0.1;
            if (keyState.IsKeyDown(Keys.Up) && canMove)
            {
                this.moveUp();
                lastMoveWhen = gameTime.TotalGameTime.TotalSeconds;
            }
            else if (keyState.IsKeyDown(Keys.Down) && canMove)
            {
                this.moveDown();
                lastMoveWhen = gameTime.TotalGameTime.TotalSeconds;

            }
            else if (keyState.IsKeyDown(Keys.Right) && canMove)
            {
                this.moveRight();
                lastMoveWhen = gameTime.TotalGameTime.TotalSeconds;
            }
            else if (keyState.IsKeyDown(Keys.Left) && canMove)
            {
                this.moveLeft();
                lastMoveWhen = gameTime.TotalGameTime.TotalSeconds;
            }
            
        }
        private void moveUp(){
            if (currentCell.walls.up == false)
            {
                currentCell.carries = "";
                currentCell.neighbours.up.carries = "character";
                currentCell = currentCell.neighbours.up;
                
            }
        }
        private void moveDown()
        {
            if (currentCell.walls.down == false)
            {
                currentCell.carries = "";
                currentCell.neighbours.down.carries = "character";
                currentCell = currentCell.neighbours.down;
                

            }
        }
        private void moveRight( )
        {
            if (currentCell.walls.right == false)
            {
                currentCell.carries = "";
                currentCell.neighbours.right.carries = "character";
                currentCell = currentCell.neighbours.right;
                

            }
        }
        private void moveLeft( )
        {
            if (currentCell.walls.left == false)
            {
                currentCell.carries = "";
                currentCell.neighbours.left.carries = "character";
                currentCell = currentCell.neighbours.left;
                

            }
        }
    }
}
