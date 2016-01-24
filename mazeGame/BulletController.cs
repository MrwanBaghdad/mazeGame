using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections;


namespace mazeGame
{
    class BulletController
    {
        //standard sigleton Implementation
        //static reference to instance of the class
        static BulletController instance;

        //static fields of the class
        static ArrayList  bullets=new ArrayList();
        static double  lastMoveWhen;

        private BulletController()
        {

        }
        public  void Update(CharacterController character,GameTime gameTime)
        {
            bool canMove = gameTime.TotalGameTime.TotalSeconds - lastMoveWhen > 0.2;

            if(canMove)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    bullets.Add(new Bullet(character.currentCell,"up"));
                    lastMoveWhen = gameTime.TotalGameTime.TotalSeconds;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    bullets.Add(new Bullet(character.currentCell, "down"));
                    lastMoveWhen = gameTime.TotalGameTime.TotalSeconds;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    bullets.Add(new Bullet(character.currentCell, "right"));
                    lastMoveWhen = gameTime.TotalGameTime.TotalSeconds;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    bullets.Add(new Bullet(character.currentCell, "left"));
                    lastMoveWhen = gameTime.TotalGameTime.TotalSeconds;
                }
            }

            foreach (Bullet b in bullets)
            {
                b.move();
            }
        }

        public static BulletController getInstance()
        {
            if (instance == null)
            {
                instance = new BulletController();
            }
            return instance;
        }
      
    }
}

