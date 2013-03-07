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
    public class LevelEndGame : ILevel
    {
        //Field
        private Level level;
        private Image background, congratulations;
        private int pauseTimeOver = 5;
        private float timer = 0;

        //Constructor
        public LevelEndGame(Level level)
        {            
            this.level = level;
            this.background = new Image(this.level.Game, @"PlaySceneAssets\Background\Background2", Vector2.Zero);
            this.congratulations = new Image(this.level.Game, @"PlaySceneAssets\Background\Congratulation", new Vector2(120f,100f));
        }        

        public void Update(GameTime gameTime)
        {
            this.timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (this.timer > this.pauseTimeOver)
            {
                level.Game.Exit();
                this.timer = 0f;
            }
        }

        public void Draw(GameTime gameTime)
        {
            this.level.Game.GraphicsDevice.Clear(Color.Red);
            this.background.Draw(gameTime);
            this.congratulations.Draw(gameTime);
        }
    }
}
