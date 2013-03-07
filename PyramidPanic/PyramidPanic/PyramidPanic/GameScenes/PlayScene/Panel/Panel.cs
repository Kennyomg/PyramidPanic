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
    public class Panel
    {
        //Field
        private PyramidPanic game;
        private Vector2 position;
        private SpriteFont font;
        private List<Image> images;
        
        //Constructor
        public Panel(PyramidPanic game, Vector2 position)
        {
            this.game = game;
            this.position = position;
            this.Initialize();
        }

        private void Initialize()
        {
            this.font = this.game.Content.Load<SpriteFont>(@"PlaySceneAssets\Fonts\Arial");
            this.images = new List<Image>();
            this.LoadContent();
        }

        private void LoadContent()
        {
            this.images.Add(new Image(this.game, @"PlaySceneAssets\Panel\Panel", this.position));
            this.images.Add(new Image(this.game, @"PlaySceneAssets\Panel\Lives", this.position
                                + new Vector2(2.5f * 32f, 0f)));
            this.images.Add(new Image(this.game, @"PlaySceneAssets\Treasures\Scarab", this.position
                                + new Vector2(8.0f * 32f, 0f)));
        }

        public void Draw(GameTime gameTime)
        {
            foreach (Image image in this.images)
            {
                image.Draw(gameTime);
            }
            this.game.SpriteBatch.DrawString(this.font, Score.Lives.ToString(), this.position + new Vector2(3.8f * 32f, -3f),
                                             Color.Yellow);
            this.game.SpriteBatch.DrawString(this.font, Score.Scarabs.ToString(), this.position + new Vector2(9.5f * 32f, -3f),
                                             Color.Yellow);
            this.game.SpriteBatch.DrawString(this.font, Score.Points.ToString(), this.position + new Vector2(17.0f * 32f, -3f),
                                             Color.Yellow);
        }
    }
}
