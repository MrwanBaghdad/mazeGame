using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeGame
{
    class CharacterController
    {
        Texture2D charImage;

        public void loadCharacterImage(Game game, string name)
        {
            charImage = game.Content.Load<Texture2D>(name);
        }
    }
}
