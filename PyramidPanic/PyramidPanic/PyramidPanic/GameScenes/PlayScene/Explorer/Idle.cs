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
    public class Idle : AnimatedSprite
    {
        //Fields
        private Explorer explorer;
        

        //Properties

        //Constructor
        public Idle(Explorer explorer) : base(explorer)
        {
            this.explorer = explorer;
        }

        //Dit is een overload van de constructor van de Idle class.
        public Idle(Explorer explorer, float angle) : base(explorer)
        {
            this.explorer = explorer;
            this.angle = angle;
        }

        //Update
        public override void Update(GameTime gameTime)
        {
            if (Input.DetectKeyDown(Keys.Right))
            {
                this.explorer.State = new Right(this.explorer);
            }
            else if (Input.DetectKeyDown(Keys.Left))
            {
                this.explorer.State = new Left(this.explorer);
            }
            else if (Input.DetectKeyDown(Keys.Up))
            {
                this.explorer.State = new Up(this.explorer);
            }
            else if (Input.DetectKeyDown(Keys.Down))
            {
                this.explorer.State = new Down(this.explorer);
            }
            //base.Update(gameTime);
        }

        //Draw
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
