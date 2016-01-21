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
        static ArrayList  bullets=new ArrayList();


        public static void Update(CharacterController character)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                bullets.Add(new Bullet(character.currentCell,"up"));
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                bullets.Add(new Bullet(character.currentCell, "down"));
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                bullets.Add(new Bullet(character.currentCell, "right"));
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                bullets.Add(new Bullet(character.currentCell, "left"));
            }
            foreach (Bullet b in bullets)
            {
                b.move();
            }
        }

      
    }
}

