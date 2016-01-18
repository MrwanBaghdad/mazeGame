using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace mazeGame
{
    class Maze
    {
        public Cell[,] cells;
        public int mazeSize;
        public int cellSize=22;
        public Maze()
        {
            mazeSize = 30;
            cells = new Cell[mazeSize, mazeSize];
            initializeAllCells();
            initializeNeighbouringCells();
        }
        private void initializeAllCells(){

            for (int i = 0; i < mazeSize; i++)
            {
                for (int j = 0; j < mazeSize; j++)
                {
                    cells[i,j] = new Cell();
                    cells[i,j].position=new Vector2(i,j);
                }
            }
        }
        private void initializeNeighbouringCells()
        {
            foreach (Cell currentCell in this.cells)
            {
                //cell position
                int x = (int)currentCell.position.X;
                int y = (int)currentCell.position.Y;

                // get right cell
                if (x + 1 < mazeSize)
                {
                    currentCell.neighbours.right = cells[x + 1, y];

                }

                // get left cell
                if (x - 1 >= 0)
                {
                    currentCell.neighbours.left = cells[x - 1, y];

                }

                // get up cell
                if (y - 1 >= 0)
                {
                    currentCell.neighbours.up = cells[x, y - 1];

                }

                // get down cell
                if (y + 1 < mazeSize)
                {
                    currentCell.neighbours.down = cells[x, y + 1];

                }
            }
        }
        public bool hasUnvisitedCells()
        {
            foreach(Cell c in this.cells){
                if (!c.visited)
                {
                    return true;
                }
            }
            return false;
        }
        public void drawMaze(SpriteBatch sb,Microsoft.Xna.Framework.Game game)
        {
            for (int i = 0; i < mazeSize; i++)
            {
                for (int j = 0; j < mazeSize; j++)
                {
                    sb.Draw(game.Content.Load<Texture2D>("walls/"+this.cells[i, j].getImageName())
                            , new Rectangle(cellSize * i, cellSize * j, cellSize, cellSize)
                            ,Color.Yellow);
                    if (this.cells[i, j].carries.Equals("character"))
                    { 
                    sb.Draw(game.Content.Load<Texture2D>("character")
                            , new Rectangle(cellSize * i + 5, cellSize * j + 5, 15, 15)
                            , Color.Yellow);
                        }
                    
                }
            }
        }
       
        
    }
}
