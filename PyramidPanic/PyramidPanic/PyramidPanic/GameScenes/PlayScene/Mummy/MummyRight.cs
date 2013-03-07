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
    public class MummyRight : AnimatedSprite 
    {
        //Fields
        private Mummy mummy;
        private bool left, right;

        //Constructor
        public MummyRight(Mummy mummy)
            : base(mummy)
        {
            this.mummy = mummy;
            this.i = 0;
        }

        //Update
        public override void Update(GameTime gameTime)
        {
            //Console.WriteLine(this.mummy.State.ToString());
            this.mummy.Position += new Vector2(this.mummy.Speed, 0f);
            if (MummyManager.CollisionDetectionWalls())
            {
                int geheelAantalmalen32 = (int)this.mummy.Position.X / 32;
                this.mummy.Position = (this.mummy.Position.X >= 0) ?
                                          new Vector2((geheelAantalmalen32) * 32, this.mummy.Position.Y) :
                                          new Vector2((geheelAantalmalen32 - 1) * 32, this.mummy.Position.Y);
                MummyManager.MummyWalk();
            }

            float modulo = (this.mummy.Position.X >= 0) ?
                            this.mummy.Position.X % 32 :
                            32 + this.mummy.Position.X % 32;
            if (modulo >= (32f - this.mummy.Speed))
            {
               int geheelAantalmalen32 = (int)this.mummy.Position.X / 32;
               this.mummy.Position = (this.mummy.Position.X >= 0 ) ?
                                      new Vector2((geheelAantalmalen32 + 1) * 32, this.mummy.Position.Y) :
                                      new Vector2((geheelAantalmalen32) * 32, this.mummy.Position.Y);
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
