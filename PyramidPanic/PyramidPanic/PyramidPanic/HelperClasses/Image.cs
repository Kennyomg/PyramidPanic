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
    public class Image
    {
        //Fields
        private Texture2D texture;
        private Rectangle rectangle;
        private Vector2 position;
        private PyramidPanic game;

        //Properties
        public Rectangle Rectangle
        {
            get { return this.rectangle; }
        }

        public Vector2 Position
        {
            get { return this.position; }
        }

        //Constructor
        public Image(PyramidPanic game, string pathName, Vector2 position)
        {
            this.game = game;
            this.position = position;
            this.texture = game.Content.Load<Texture2D>(pathName);
            this.rectangle = new Rectangle((int)position.X,
                                           (int)position.Y,
                                           this.texture.Width,
                                           this.texture.Height);
        }

        //Draw
        public void Draw(GameTime gameTime)
        {
            this.game.SpriteBatch.Draw(this.texture, this.rectangle, Color.White);
        }

        public void Draw(SpriteBatch spriteBatch, Color color)
        {
            spriteBatch.Draw(this.texture, this.rectangle, color);
        }
    }
}
