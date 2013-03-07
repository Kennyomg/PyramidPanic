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
    public class MummyLeft : AnimatedSprite 
    {
        //Fields
        private Mummy mummy;
        private bool left, right;

        //Constructor
        public MummyLeft(Mummy mummy) : base(mummy)
        {
            this.mummy = mummy;
            this.angle = (float)Math.PI;
            this.i = 0;
        }

        //Update
        public override void Update(GameTime gameTime)
        {
            this.mummy.Position -= new Vector2(this.mummy.Speed, 0f);

            if (ExplorerManager.Distance(this.mummy))
            {
                float modulo = (this.mummy.Position.X >= 0) ?
                                this.mummy.Position.X % 32 :
                                32 + this.mummy.Position.X % 32;
                if (modulo <= this.mummy.Speed)
                {
                    int geheelAantalmalen32 = (int)this.mummy.Position.X / 32;
                    this.mummy.Position = (this.mummy.Position.X >= 0) ?
                                              new Vector2((geheelAantalmalen32) * 32, this.mummy.Position.Y) :
                                              new Vector2((geheelAantalmalen32 - 1) * 32, this.mummy.Position.Y);
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
            
            //Collision detection met NotPassable objects
            if (MummyManager.CollisionDetectionWalls())
            {
                int geheelAantalmalen32 = (int)this.mummy.Position.X / 32;
                this.mummy.Position = new Vector2((geheelAantalmalen32 + 1) * 32, this.mummy.Position.Y);

                this.left = MummyManager.IsThereWallLeftOrRight(0, 1);
                this.right = MummyManager.IsThereWallLeftOrRight(0, -1);
                if (!this.left && !this.right)
                {
                    Console.WriteLine("Er zijn geen muren" + MummyManager.Random.Next(2));
                    switch (MummyManager.Random.Next(3))
                    {
                        case 0:
                            this.mummy.State = this.mummy.MummyDown; //new MummyDown(this.mummy);
                            break;
                        case 1:
                            this.mummy.State = this.mummy.MummyUp; //new MummyUp(this.mummy);
                            break;
                        case 2:
                            this.mummy.State = this.mummy.MummyRight; //new MummyRight(this.mummy);
                            break;
                        default:
                            break;
                    }
                }
                else if (this.left && !this.right)
                {
                    Console.WriteLine("Left: Er is omlaag een muur ik ga omhoog");
                    mummy.State = this.mummy.MummyUp; //new MummyUp(this.mummy);
                }
                else if (this.right && !this.left)
                {
                    Console.WriteLine("Left: Er is omhoog een muur ik ga omlaag");
                    mummy.State = this.mummy.MummyDown; //new MummyDown(this.mummy);
                }
                else
                {
                    Console.WriteLine("Left: Omhoog en omlaag is er een muur ik ga terug");
                    mummy.State = this.mummy.MummyRight; //new MummyRight(this.mummy);
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
