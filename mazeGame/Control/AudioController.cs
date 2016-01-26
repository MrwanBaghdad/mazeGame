using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Media;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mazeGame.Control
{
    class AudioController
    {
        private static Song stepsSound;
        public static void playSteps(Game game)
        {
            if (stepsSound == null)
            {
                stepsSound = game.Content.Load<Song>("steps");

            }
            MediaPlayer.Play(stepsSound);
        }
    }
}
