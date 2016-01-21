using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeGame
{
    class GameController
    {
        public static int score = 0;
        public static double lastFinishedGameTime;
        public static bool gameHasStarted=false;
        
        
        public static void updateScore(int addedScore)
        {
            score += addedScore;
            
        }
        public static void finishGame(GameTime gameTime)
        {
            gameHasStarted = false;
            lastFinishedGameTime = gameTime.TotalGameTime.TotalMinutes;
        }
        public static void startGame()
        {
            gameHasStarted = true;
        }
       

    }
}
