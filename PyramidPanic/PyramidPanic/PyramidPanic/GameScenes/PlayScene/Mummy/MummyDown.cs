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
        private bool left, right;

        //Constructor
        public MummyDown(Mummy mummy) : base(mummy)
        {
            this.mummy = mummy;
            this.angle = (float)Math.PI / 2;
            this.i = 0;
        }

        //Update
        public override void Update(GameTime gameTime)
        {
            this.mummy.Position += new Vector2(0f, this.mummy.Speed);

            if (ExplorerManager.Distance(this.mummy))
            {
                float modulo = (this.mummy.Position.Y >= 0) ?
                                this.mummy.Position.Y % 32 :
                                32 + this.mummy.Position.Y;
                if (modulo >= (32f - this.mummy.Speed))
                {
                    int geheelAantalmalen32 = (int)this.mummy.Position.Y / 32;
                    this.mummy.Position = (this.mummy.Position.Y >= 0) ?
                                              new Vector2(this.mummy.Position.X, (geheelAantalmalen32 + 1) * 32) :
                                              new Vector2(this.mummy.Position.X, (geheelAantalmalen32) * 32);
                    this.mummy.Color = Color.Red;
                    this.mummy.Speed = this.mummy.ChaseSpeed;
                    this.mummy.State = this.mummy.MummyChase;
                }
            }
            else
            {
                this.mummy.Speed = this.mummy.NormalSpeed;
                this.mummy.Color = Color.White;
            }
            
            
            
            //Collisiondetection met NotPassable objects
            if (MummyManager.CollisionDetectionWalls())
            {
                int geheelAantalmalen32 = (int)this.mummy.Position.Y / 32;
                this.mummy.Position = (this.mummy.Position.Y >=0) ?
                    new Vector2(this.mummy.Position.X, geheelAantalmalen32 * 32) :
                    new Vector2(this.mummy.Position.X, (geheelAantalmalen32 - 1) * 32);

                    this.left = MummyManager.IsThereWallLeftOrRight(1, 0);
                    this.right = MummyManager.IsThereWallLeftOrRight(-1, 0);
                    if (!this.left && !this.right)
                    {
                        Console.WriteLine("Er zijn geen muren" + MummyManager.Random.Next(2));
                        switch (MummyManager.Random.Next(3))
                        {
                            case 0:
                                this.mummy.State = this.mummy.MummyRight;
                                break;
                            case 1:
                                this.mummy.State = this.mummy.MummyLeft;
                                break;
                            case 2:
                                this.mummy.State = this.mummy.MummyUp;
                                break;
                            default:
                                break;
                        }
                    }
                    else if (this.left && !this.right)
                    {
                        Console.WriteLine("Er is links een muur ik ga rechtsaf");
                        mummy.State = this.mummy.MummyLeft;
                    }
                    else if (this.right && !this.left)
                    {
                        Console.WriteLine("Er is rechts een muur ik ga linksaf");
                        mummy.State = this.mummy.MummyRight;
                    }
                    else
                    {
                        Console.WriteLine("Links en rechts zijn er muren ik ga terug");
                        mummy.State = this.mummy.MummyUp;
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
