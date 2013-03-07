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
    public class MummyChase : AnimatedSprite 
    {
        //Fields
        private Mummy mummy;
        private bool left, right;
        private Dictionary<string, AnimatedSprite> chaseState;
        private AnimatedSprite state;

        //Constructor
        public MummyChase(Mummy mummy) : base(mummy)
        {
            this.mummy = mummy;
            this.i = 0;
            this.chaseState = new Dictionary<string, AnimatedSprite>()
            {
                { "up", this.mummy.MummyUp }, //new MummyUp(mummy)},
                { "down", this.mummy.MummyDown }, //new MummyDown(mummy)},
                { "left", this.mummy.MummyLeft }, //new MummyLeft(mummy)},
                { "right", this.mummy.MummyRight } //new MummyRight(mummy)}
            };
            /* Default waarde up */
            this.state = this.chaseState["up"];
        }

        //Update
        public override void Update(GameTime gameTime)
        {
            this.mummy.State = this.chaseState[MummyManager.Distance()];
            this.mummy.State.Update(gameTime);
            //base.Update(gameTime);
        }

        //Draw
        public override void Draw(GameTime gameTime)
        {
           this.state.Draw(gameTime);
           //base.Draw(gameTime);
        }
    }
}
