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
    public abstract class AnimatedSprite
    {
        //Field
        private IAnimatedSprite animatedSprite;
        private int[] xValue = { 0, 32, 64, 96 };
        protected int i = 1;
        private float timer;
        protected float angle = 0f;
        private Color color = Color.White;

        public Color Color
        {
            get {return this.color;}
            set { this.color = value; }
        }
        //Constructor
        public AnimatedSprite(IAnimatedSprite animatedSprite)
        {
            this.animatedSprite = animatedSprite;
        }

        public virtual void Update(GameTime gameTime)
        {
            //Dit is de code voor de animatie van de sprite
            this.timer += (float)gameTime.ElapsedGameTime.TotalSeconds;
            if (this.timer > 1f / 12f)
            {
                this.timer = 0;
                this.i++;
                if (this.i > 3)
                {
                    this.i = 0;
                }
            }
        }

        public virtual void Draw(GameTime gameTime)
        {
            this.animatedSprite.Game.SpriteBatch.Draw(this.animatedSprite.Texture,
                                              this.animatedSprite.Rectangle,
                                              new Rectangle(this.xValue[this.i], 0, 32, 32),
                                              color,
                                              this.angle,
                                              new Vector2(16f, 16f),
                                              SpriteEffects.None,
                                              0f);
        }
    }
}
