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
    public class WalkRight : AnimatedSprite, IScorpion
    {
        private Scorpion scorpion;
     
        //Constructor
        public WalkRight(Scorpion scorpion) : base(scorpion)
        {
            this.scorpion = scorpion;
            this.angle = 0f;
        }        
        
        public override void Update(GameTime gameTime)
        {
            //De scorpion loopt naar rechts
            this.scorpion.Position += new Vector2(this.scorpion.Speed, 0f);
            if (this.scorpion.Position.X > this.scorpion.Right)
            {
                this.scorpion.State = this.scorpion.WalkLeft;
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
