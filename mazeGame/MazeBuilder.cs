using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;

namespace mazeGame
{
    static class  MazeBuilder
    {
        
        public static Maze createMaze(Cell init,Maze m)
        {
            Maze maze = m;

            Cell current = init;

            Stack<Cell> unvisitedCellStack = new Stack<Cell>();
            
            while (maze.hasUnvisitedCells())
            {
                
                
                unvisitedCellStack.Push(current);

                if (current.hasUnvisitedNeighbours())
                {
                    
                    current = current.getRandomNeighbourAndCarvePath();
                    current.visited = true;
                }
                else
                {
                    current.visited = true;
                    unvisitedCellStack.Pop();
                    current = unvisitedCellStack.Pop();
                    current.visited = true;
                    
                }
                
                //mark end cell 
                maze.endCell = maze.cells[maze.mazeSize - 1, maze.mazeSize - 1];
                maze.endCell.carries += "end";

            }

            

            return maze;
        }


        public static Maze createMazeDFS(Cell init, Maze m)
        {

            foreach (Cell c in m.cells)
            {
                if (c.visited == false)
                {
                    visitAllReachableCells(c);
                }
            }

            return null;
        }
        public static void visitAllReachableCells(Cell startCell)
        {
            ArrayList neighbours = startCell.getAllNeighbours();
            foreach (Cell c in neighbours)
            {
                if (c.visited == false)
                {
                    c.visited = true;
                    startCell.carvePath(startCell.relationWith(c));
                    visitAllReachableCells(c);
                }
            }
        }


    }
}
