using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeGame
{
    class BombController
    {
        public static int currentImageName = 1;
        private static bool canChangeImage;
        private static double lastChangeWhen = 0;
        public static void updateBombs(Maze m,GameTime gameTime)
        {
            canChangeImage = gameTime.TotalGameTime.TotalSeconds - lastChangeWhen > 0.05;
            if (canChangeImage)
            {
                currentImageName = (currentImageName + 1) % 5;
                if (currentImageName == 0) { currentImageName++; }
                lastChangeWhen = gameTime.TotalGameTime.TotalSeconds;
            }
            foreach (Cell item in m.cells)
            {
                if (item.carries.Contains("bomb") && item.carries.Contains("character"))
                {
                    item.carries = item.carries.Replace("bomb", "");
                    
                }
                if (item.carries.Contains("bomb") && item.carries.Contains("bullet"))
                {
                    item.carries = item.carries.Replace("bomb", "");
                    GameController.updateScore(10);
                }
            }
        }
    }
}
