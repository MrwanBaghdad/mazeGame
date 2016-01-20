using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace mazeGame
{

    class CellNeighbours
    {
        public Cell up = null;
        public Cell down = null;
        public Cell left = null;
        public Cell right = null;

    }
    class CellWalls
    {
        public bool up = true, down = true, right = true, left = true;
    }
    class Cell
    {
        public Vector2 position;
        public CellWalls walls = new CellWalls();
        public string carries="";
        public CellNeighbours neighbours = new CellNeighbours();
        //this string holds the last relation with the most recent selected neighbour in order to evade it in the next selection
        private static string lastSelectedNeighbourRelation = "";
        //boolean that holds whether we're going to take an different neighbour direction or random
        private static bool getDifferentNeighbourDirection = false;
        public bool visited = false;
        public bool monsterVisited = false;
        public Cell getRandomNeighbourAndCarvePath()
        {
            Random generator = new Random();
            double x = generator.NextDouble() ;
            x -= (int)x;
            Debug.WriteLine(x);
            getDifferentNeighbourDirection = x >= 0.6; 
            ArrayList realNeighbours = this.getUnvisitedNeighboursList();
            if (getDifferentNeighbourDirection)
            {
                for (int i = 0; i < realNeighbours.Count; i++)
                {
                    if (!lastSelectedNeighbourRelation.Equals(this.relationWith((Cell)realNeighbours[i])))
                    {
                        lastSelectedNeighbourRelation = this.relationWith((Cell)realNeighbours[i]);
                        carvePath(lastSelectedNeighbourRelation);
                        return ((Cell)realNeighbours[i]);
                    }
                }
                lastSelectedNeighbourRelation = this.relationWith((Cell)realNeighbours[0]);
                carvePath(lastSelectedNeighbourRelation);
                return ((Cell)realNeighbours[0]);
            }
            else
            {
                lastSelectedNeighbourRelation = this.relationWith((Cell)realNeighbours[0]);
                carvePath(lastSelectedNeighbourRelation);
                return ((Cell)realNeighbours[0]);
            }

            

        }
        public void carvePath(String direction)
        {

            switch (direction)
            {
                case "up":
                    this.walls.up = false;
                    this.neighbours.up.walls.down = false;
                    
                    break;
                case "down":
                    this.walls.down = false;
                    this.neighbours.down.walls.up = false;
                    
                    break;
                case "right":
                    this.walls.right = false;
                    this.neighbours.right.walls.left = false;
                    
                    break;
                case "left":
                    this.walls.left = false;
                    this.neighbours.left.walls.right = false;
                    
                    break;
            
            }
            
        }
        public bool hasUnvisitedNeighbours()
        {
            //array list that has all neighbours that aren't null
            ArrayList realNeighbours = this.getUnvisitedNeighboursList();
            
            return realNeighbours.Count>0;
        }
        public ArrayList getUnvisitedNeighboursList()
        {
            ArrayList result = new ArrayList();

            if (neighbours.up != null && neighbours.up.visited==false)
            {
                result.Add(neighbours.up );
            }
            if (neighbours.down != null && neighbours.down.visited == false)
            {
                result.Add(neighbours.down);
            }
            if (neighbours.left != null && neighbours.left.visited == false)
            {
                result.Add(neighbours.left);
            }
            if (neighbours.right != null && neighbours.right.visited==false)
            {
                result.Add(neighbours.right);
            }
            result = shuffle(result);
            
            return result;
        }
        public string relationWith(Cell x)
        {
            if (x == neighbours.up)
            {
                return "up";
            }
            else if (x == neighbours.down)
            {
                return "down";
            }
            else if (x == neighbours.left)
            {
                return "left";
            }
            else if (x == neighbours.right)
            {
                return "right";
            }
            return "none";
        }
        public string getImageName()
        {
            string imageName = "";

            /*suppose the string "0011" represents an Cell image that has two walls on the down and left 
             * directions this is because the string represents the four directions starting from up and going 
             * in the clock-wise direction, where 1 represents the existence of a wall.
             */
            imageName = this.walls.up ? imageName + "1" : imageName + "0";
            imageName = this.walls.right ? imageName + "1" : imageName + "0";
            imageName = this.walls.down ? imageName + "1" : imageName + "0";
            imageName = this.walls.left ? imageName + "1" : imageName + "0";

            if (imageName.Equals("0000")) { imageName = "1111"; }
            return imageName;
        }
        public ArrayList shuffle(ArrayList list)
        {
            
            ArrayList shuffled = new ArrayList();
            var rand = new Random();

           
            while (list.Count != 0)
            {
                
                var i = rand.Next(10);
                i=i%list.Count;

                
                shuffled.Add(list[i]);

               
                list.RemoveAt(i);
            }

            
            return shuffled;
        }
        public ArrayList getNeighboursICanMoveTo()
        {
            ArrayList result = new ArrayList();

            if (walls.up == false)
            {
                result.Add(neighbours.up);
            }
            if (walls.down == false)
            {
                result.Add(neighbours.down);
            }
            if (walls.left == false)
            {
                result.Add(neighbours.left);
            }
            if (walls.right == false)
            {
                result.Add(neighbours.right);
            }
            result = shuffle(result);
            return result;
        }
        public Cell chooseNearestMonsterUnvisitedNeighbourTo(Cell destination)
        {
            ArrayList reachableNeighbours = this.getMonsterUnvisitedNeighbours();
            Cell bestCell = (Cell)reachableNeighbours[0];
            foreach (Cell c in reachableNeighbours)
            {
                if (distanceFrom(bestCell) > distanceFrom(c) )
                {
                    bestCell = c;
                }
            }
            return bestCell;
        }
        private float distanceFrom(Cell destination)
        {
            return Math.Abs(destination.position.X - this.position.X) + Math.Abs(destination.position.Y - this.position.Y);
        }
        public ArrayList getMonsterUnvisitedNeighbours()
        {
            ArrayList neighbours = this.getNeighboursICanMoveTo();
            ArrayList result = new ArrayList();
            foreach (Cell c in neighbours)
            {
                if (!c.monsterVisited)
                {
                    result.Add(c);
                }
            }
            return result;
        }
        public bool hasMonsterUnvisitedNeighbours(){
            return getMonsterUnvisitedNeighbours().Count > 0;
        }
        public ArrayList getAllNeighbours()
        {
            ArrayList result = new ArrayList();

            if (neighbours.up != null)
            {
                result.Add(neighbours.up);
            }
            if (neighbours.down != null)
            {
                result.Add(neighbours.down);
            }
            if (neighbours.left != null)
            {
                result.Add(neighbours.left);
            }
            if (neighbours.right != null)
            {
                result.Add(neighbours.right);
            }
            result = shuffle(result);
            
            return result;


        }
    }


}
