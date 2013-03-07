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
    public class BeetleManager
    {
        //Fields
        private static Level level;

        //Properties
        public static Level Level
        {
            set 
            { 
                level = value;
                CollisionWallBeetleUp();
                CollisionWallBeetleDown();
            }
        }

        private static void CollisionWallBeetleUp()
        {
            foreach (Beetle beetle in level.Beetles)
            {
                for (int i = (int)(beetle.Position.Y / 32); i >= 0; i--)
                {
                    if (level.Blocks[(int)(beetle.Position.X / 32), i].BlockCollision == BlockCollision.NotPassable)
                    {
                        beetle.Top = (i + 1) * 32;
                        break;
                    }
                }
            }
        }

        private static void CollisionWallBeetleDown()
        {
            foreach (Beetle beetle in level.Beetles)
            {
                for (int i = (int)(beetle.Position.Y / 32); i < 14; i++)
                {
                    if (level.Blocks[(int)(beetle.Position.X / 32), i].BlockCollision == BlockCollision.NotPassable)
                    {
                        beetle.Bottom = (i - 1) * 32;
                        break;
                    }
                }
            }
        }
    }
}
