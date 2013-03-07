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
    public class MummyDown : AnimatedSprite 
    {
        //Fields
        private Mummy mummy;

        //Constructor
        public MummyDown(Mummy mummy)
            : base(mummy)
        {
            this.mummy = mummy;
            this.angle = (float)Math.PI / 2;
            this.i = 0;
        }

        //Update
        public override void Update(GameTime gameTime)
        {
            this.mummy.Position += new Vector2(0f, this.mummy.Speed);
            //Collisiondetection met NotPassable objects
            if (MummyManager.CollisionDetectionWalls())
            {
                int geheelAantalmalen32 = (int)this.mummy.Position.Y / 32;
                this.mummy.Position = (this.mummy.Position.Y >=0) ?
                    new Vector2(this.mummy.Position.X, geheelAantalmalen32 * 32) :
                    new Vector2(this.mummy.Position.X, (geheelAantalmalen32 - 1) * 32);
                MummyManager.MummyWalk();
            }
            //Blijf op het grid
                float modulo = (this.mummy.Position.Y >= 0) ?
                                this.mummy.Position.Y % 32 : 
                                32 + this.mummy.Position.Y % 32;
                if (modulo >= (32f - this.mummy.Speed))
                {
                    int geheelAantalmalen32 = (int)this.mummy.Position.Y / 32;
                    this.mummy.Position = (this.mummy.Position.Y >= 0) ?
                        new Vector2(this.mummy.Position.X, (geheelAantalmalen32 + 1) * 32) :
                        new Vector2(this.mummy.Position.X, (geheelAantalmalen32) * 32);
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
