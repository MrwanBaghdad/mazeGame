﻿using Microsoft.Xna.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeGame
{
    class GiftController
    {
        public static int currentImageName = 1;
        private static bool canChangeImage;
        private static double lastChangeWhen = 0;
        public static void updateGifts (Maze m,GameTime gameTime)
        {
            canChangeImage = gameTime.TotalGameTime.TotalSeconds - lastChangeWhen > 0.05;
            if (canChangeImage) {
                currentImageName = (currentImageName + 1) % 9;
                if (currentImageName == 0) { currentImageName++; }
                lastChangeWhen = gameTime.TotalGameTime.TotalSeconds;
            }
            
            foreach (Cell item in m.cells)
            {
                if (item.carries.Contains("giftS") && item.carries.Contains("character"))
                {
                    item.carries = item.carries.Replace("giftS","");
                    GameController.updateScore(10);
                }
                if (item.carries.Contains("giftA") && item.carries.Contains("character"))
                {

                    Bullet.refillAmmo();
                    item.carries = item.carries.Replace("giftA", "");
                    GameController.updateScore(5);
                }

            }
        }
    }
}
