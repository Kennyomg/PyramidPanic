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
    public class MummyManager
    {
        //Fields
        private static Level level;
        private static Mummy mummy;
        private static Random random = new Random();

        //Properties
        public static Level Level
        {
            set { level = value; }
        }

        public static Mummy Mummy
        {
            set { mummy = value; }
        }

        public static Random Random
        {
            get { return random; }
        }

        public static bool CollisionDetectionWalls()
        {
            for (int i = 0; i < level.Blocks.GetLength(0); i++)
            {
                for (int j = 0; j < level.Blocks.GetLength(1); j++)
                {
                    if (level.Blocks[i, j].BlockCollision == BlockCollision.NotPassable)
                    {
                        if (mummy.CollisionRectangle.Intersects(level.Blocks[i, j].Rectangle))
                        {
                            return true;
                        }
                    }
                }
            }
            return false;
         }

        public static bool IsThereWallLeftOrRight(int offsetX, int offsetY)
        {
            if (level.Blocks[(int)(mummy.Position.X / 32) + offsetX, (int)(mummy.Position.Y / 32) + offsetY].BlockCollision
                    == BlockCollision.NotPassable)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string Distance()
        {
            Dictionary<string, double> distance;
            distance = new Dictionary<string,double>();
            distance.Add("normal", CalculateDistance(0, 0));
            distance.Add("up", CalculateDistance(0, -1));
            distance.Add("down", CalculateDistance(0, 1));
            distance.Add("left", CalculateDistance(-1, 0));
            distance.Add("right", CalculateDistance(1, 0));
            Console.WriteLine(distance.OrderBy(kvp => kvp.Value).First().Key);
            return distance.OrderBy(kvp => kvp.Value).First().Key; 
        }

        private static double CalculateDistance(int i, int j)
        {
            return Math.Sqrt(Math.Pow(((mummy.Position.X + i * 32) - level.Explorer.Position.X), 2d) +
                             Math.Pow(((mummy.Position.Y + j * 32) - level.Explorer.Position.Y), 2d));
        }
    }
}
