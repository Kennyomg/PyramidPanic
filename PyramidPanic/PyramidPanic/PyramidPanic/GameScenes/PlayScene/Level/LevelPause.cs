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
    public class LevelPause : ILevel
    {
        //Field
        private Level level;
        private Image overlay;
        private int pauseTimeOver = 3;
        private float timer = 0;
        private int removeIndex = -1;
        private string removeType;

        //Properties
        public int RemoveIndex
        {
            set { this.removeIndex = value; }
        }

        public string RemoveType
        {
            set { this.removeType = value; }
        }
        //Constructor
        public LevelPause(Level level)
        {
            this.level = level;
            this.overlay = new Image(level.Game, @"PlaySceneAssets\Overlay\overlay", Vector2.Zero);
        }

        public void Update(GameTime gameTime)
        {
            this.timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (this.timer > this.pauseTimeOver)
            {
                switch (this.removeType)
                {
                    case "Scorpion":
                        level.Scorpions.RemoveAt(this.removeIndex);
                        break;
                    case "Beetle":
                        level.Beetles.RemoveAt(this.removeIndex);
                        break;
                    case "Mummy":
                        level.Mummies.RemoveAt(this.removeIndex);
                        break;
                    default:
                        break;
                }
                level.Explorer.Position = new Vector2(9*32f, 6*32f);
                level.Explorer.State = new Idle(level.Explorer);
                this.removeIndex = -1;
                this.level.LevelState = level.LevelPlay;
                this.timer = 0f;
            }
        }

        public void Draw(GameTime gameTime)
        {
            this.overlay.Draw(gameTime);
        }
    }
}
