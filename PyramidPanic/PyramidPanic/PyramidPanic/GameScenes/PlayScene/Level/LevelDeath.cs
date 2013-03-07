using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace PyramidPanic
{
    public class LevelDeath : ILevel
    {
        //Fields
        private Level level;
        private Image gameOver;
        private int pauseTimeOver = 6;
        private float timer = 0f;

        public LevelDeath(Level level)
        {
            this.level = level;
            this.gameOver = new Image(level.Game, @"PlaySceneAssets\Overlay\overlayDeath",  Vector2.Zero);
        }

        public void Update(GameTime gameTime)
        {
            this.timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (this.timer > this.pauseTimeOver)
            {
                level.Game.GameState = new StartScene(level.Game);
                this.timer = 0;
            }

        }

        public void Draw(GameTime gameTime)
        {
            this.gameOver.Draw(gameTime);
        }
    }
}
