using mazeGame.View;
using mazeGame.Control;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace mazeGame.Control
{
    class DroppingController
    {   
        
        public static void putDroppings(Maze m)
        {
            for (int i = 0; i < 10; i++)
            {
                DroppingsFactory.putDropping(m);
            }
        }
        public static void updateDroppings(Maze m,GameTime gameTime)
        {
            GiftController.updateGifts(m,gameTime);
            BombController.updateBombs(m,gameTime);
        }
    }
}
