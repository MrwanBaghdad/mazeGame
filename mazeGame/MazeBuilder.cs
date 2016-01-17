﻿using Microsoft.Xna.Framework;
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
            //current.visited = true;
            Stack<Cell> unvisitedCellStack = new Stack<Cell>();
            
            while (maze.hasUnvisitedCells())
            {
                
                //put the current cell in the stack
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
                

                

            }

            

            return maze;
        }


        


    }
}