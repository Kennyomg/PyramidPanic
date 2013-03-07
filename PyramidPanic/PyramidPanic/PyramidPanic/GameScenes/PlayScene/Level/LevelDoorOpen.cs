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
    public class LevelDoorOpen : ILevel
    {
        //Fields
        private Level level;
        private Image doorsAreOpen;
        private int pauseTimeOver = 1;
        private float timer = 0;
        
        //Constructor
        public LevelDoorOpen(Level level)
        {
            this.level = level;
            this.doorsAreOpen = new Image(level.Game, @"PlaySceneAssets\Overlay\DoorOpenOverlay", Vector2.Zero);
        }
        
        public void Update(GameTime gameTime)
        {
            this.timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (this.timer > this.pauseTimeOver)
            {
                level.LevelState = level.LevelPlay;
                this.timer = 0;
            }
        }

        public void Draw(GameTime gameTime)
        {
            this.doorsAreOpen.Draw(gameTime);
        }
    }
}
