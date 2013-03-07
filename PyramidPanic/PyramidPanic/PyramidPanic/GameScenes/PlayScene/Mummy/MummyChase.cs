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
    class MummyChase : AnimatedSprite 
    {
        private Mummy mummy;
        private bool left, right;
        private Dictionary<string, AnimatedSprite> chaseState;
        private AnimatedSprite state;

        public MummyChase(Mummy mummy) : base(mummy)
        {
            this.mummy = mummy;
            this.i = 0;
            this.chaseState = new Dictionary<string, AnimatedSprite>()
            {
                {"up", new MummyUp(mummy)},
                {"down", new MummyDown(mummy)},
                {"left", new MummyLeft(mummy)},
                {"right", new MummyRight(mummy)}
            };
            this.state = this.chaseState[MummyManager.Distance()];

        }
        public override void Update(GameTime gameTime)
        {
            MummyManager.Distance();
            this.state.Update(gameTime);
            //base.Update(gameTime);
        }
        public override void Draw(GameTime gameTime)
        {
            this.state.Draw(gameTime);
            //base.Draw(gameTime);
        }
    }
}
