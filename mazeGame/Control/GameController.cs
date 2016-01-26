using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        public static int level = 1;
        
        
        public static void updateScore(int addedScore)
        {
            score += addedScore;
            
        }
        public static void finishGame(GameTime gameTime,Maze m)
        {
            gameHasStarted = false;
            level++;
            
            updateScore(100);
            updateScore((int) (10000 / (gameTime.TotalGameTime.TotalSeconds - lastFinishedGameTime)));
            lastFinishedGameTime = gameTime.TotalGameTime.TotalMinutes;
        }
        public static void startGame()
        {
            gameHasStarted = true;
        }
        public static void drawStatus(SpriteBatch sb, Game game, Maze m, GameTime gameTime)
        {
            sb.Draw(game.Content.Load<Texture2D>("numbers/level field"), new Rectangle( m.mazeSize * m.cellSize + 40,30, 112, 137), Color.White);
            sb.Draw(game.Content.Load<Texture2D>("numbers/score field"), new Rectangle(m.mazeSize * m.cellSize + 10, 200, 160, 60), Color.White);
            drawScore(sb, game,m);
            sb.Draw(game.Content.Load<Texture2D>("numbers/" + GameController.level), new Rectangle(m.mazeSize * m.cellSize + 55, 50, 80, 80), Color.White);
            sb.Draw(game.Content.Load<Texture2D>("numbers/bullet field"), new Rectangle(m.mazeSize * m.cellSize + 10, 270, 160, 60), Color.White);
            drawBullets(sb, game, m);
            sb.Draw(game.Content.Load<Texture2D>("numbers/time field"), new Rectangle(m.mazeSize * m.cellSize + 10, 340, 160, 60), Color.White);
            drawTime(sb, game, m, gameTime);


        }
        private static void drawScore(SpriteBatch sb,Game game,Maze m)
        {
            string score = GameController.score + "";
            for (int i = 1; i <= score.Length; i++)
            {
                sb.Draw(game.Content.Load<Texture2D>("numbers/" + score[i - 1]), new Rectangle(m.mazeSize * m.cellSize + 40 + (i * 15), 220, 20, 20), Color.White);
            }
        }
        private static void drawBullets(SpriteBatch sb, Game game, Maze m)
        {
            string bullets = Bullet.getBulletsLeft() + "";
            for (int i = 1; i <= bullets.Length; i++)
            {
                sb.Draw(game.Content.Load<Texture2D>("numbers/" + bullets[i - 1]), new Rectangle(m.mazeSize * m.cellSize + 40 + (i * 15), 290, 20, 20), Color.White);
            }
        }
        private static void drawTime(SpriteBatch sb, Game game, Maze m,GameTime gameTime)
        {

            int lastPositionX=0;
            ///draw minutes 
            string minutes = ((int)(gameTime.TotalGameTime.TotalSeconds - GameController.lastFinishedGameTime) / 60) + "";
            for (int i = 1; i <= minutes.Length; i++)
            {
                sb.Draw(game.Content.Load<Texture2D>("numbers/" + minutes[i - 1]), new Rectangle(m.mazeSize * m.cellSize + 50 + (i * 15), 360, 20, 20), Color.White);
                lastPositionX = m.mazeSize * m.cellSize + 50 + (i * 15);
            }
            //draw the " : " between minutes and seconds 
            sb.Draw(game.Content.Load<Texture2D>("numbers/" +"00"), new Rectangle(lastPositionX+15, 360, 20, 20), Color.White);
            //draw Seconds
            string seconds = ((int)(gameTime.TotalGameTime.TotalSeconds - GameController.lastFinishedGameTime) % 60) + "";
            for (int i = 1; i <= seconds.Length; i++)
            {
                sb.Draw(game.Content.Load<Texture2D>("numbers/" + seconds[i - 1]), new Rectangle(lastPositionX + 15 + (i * 15), 360, 20, 20), Color.White);
            }
        }

    }
}
