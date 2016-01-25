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
        //fields that control animation
        public static int currentImageName = 1;
        private static bool canChangeImage;
        private static double lastChangeWhen = 0;
        private BulletController()
        {

        }
        public  void Update(CharacterController character,GameTime gameTime)
        {
            bool canMove = gameTime.TotalGameTime.TotalSeconds - lastMoveWhen > 0.05;
            canChangeImage = gameTime.TotalGameTime.TotalSeconds - lastChangeWhen > 0.05;
            if (canChangeImage)
            {
                currentImageName = (currentImageName + 1) % 5;
                if (currentImageName == 0) { currentImageName++; }
                lastChangeWhen = gameTime.TotalGameTime.TotalSeconds;
            }
            if(canMove)
            {
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    bullets.Add(Bullet.getInstance(character.currentCell,"up"));
                    lastMoveWhen = gameTime.TotalGameTime.TotalSeconds;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    bullets.Add(Bullet.getInstance(character.currentCell, "down"));
                    lastMoveWhen = gameTime.TotalGameTime.TotalSeconds;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    bullets.Add(Bullet.getInstance(character.currentCell, "right"));
                    lastMoveWhen = gameTime.TotalGameTime.TotalSeconds;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    bullets.Add(Bullet.getInstance(character.currentCell, "left"));
                    lastMoveWhen = gameTime.TotalGameTime.TotalSeconds;
                }
            }

            Bullet.moveAll();
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

