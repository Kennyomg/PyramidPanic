using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;

namespace PyramidPanic
{
    public class LevelPlay : ILevel
    {
        //Fields
        private Level level;

        public LevelPlay(Level level)
        {
            this.level = level;
        }
        
        public void Update(GameTime gameTime)
        {
            foreach (Scorpion scorpion in level.Scorpions)
            {
                scorpion.Update(gameTime);
            }

            foreach (Beetle beetle in level.Beetles)
            {
                beetle.Update(gameTime);
            }

            foreach (Mummy mummy in level.Mummies)
            {
                mummy.Update(gameTime);
            }

            level.Explorer.Update(gameTime);
        }
        
        public void Draw(GameTime gameTime)
        {

        }
    }
}
