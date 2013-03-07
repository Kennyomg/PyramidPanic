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
    public class Right : AnimatedSprite 
    {
        //Fields
        private Explorer explorer;

        //Constructor
        public Right(Explorer explorer) : base(explorer)
        {
            this.explorer = explorer;
            this.i = 0;
        }

        //Update
        public override void Update(GameTime gameTime)
        {
            this.explorer.Position += new Vector2(this.explorer.Speed, 0f);
            if (ExplorerManager.CollisionDetectionWalls())
            {
                int geheelAantalmalen32 = (int)this.explorer.Position.X / 32;
                this.explorer.Position = (this.explorer.Position.X >= 0) ?
                                          new Vector2((geheelAantalmalen32) * 32, this.explorer.Position.Y) :
                                          new Vector2((geheelAantalmalen32 - 1) * 32, this.explorer.Position.Y);
                if (Input.DetectKeyUp(Keys.Right))
                {
                    this.explorer.State = new Idle(this.explorer, 0f);
                }
            }
            if (Input.DetectKeyUp(Keys.Right))
            {
                float modulo = (this.explorer.Position.X >= 0) ?
                                this.explorer.Position.X % 32 :
                                32 + this.explorer.Position.X % 32;
                if (modulo >= (32f - this.explorer.Speed))
                {
                    int geheelAantalmalen32 = (int)this.explorer.Position.X / 32;
                    this.explorer.Position = (this.explorer.Position.X >= 0 ) ?
                                              new Vector2((geheelAantalmalen32 + 1) * 32, this.explorer.Position.Y) :
                                              new Vector2((geheelAantalmalen32) * 32, this.explorer.Position.Y);
                    this.explorer.State = new Idle(this.explorer, 0f);
                }
            }
            base.Update(gameTime);
        }

        //Draw
        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}
