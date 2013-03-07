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
    public class Score
    {
        //Static Fields
        private static int points;
        private static int lives = 3;
        private static int scarabs;
        private static bool doorsAreClosed = true;
        private static int minimalPointsForNextLevel;

        public static int Points
        {
            get { return points; }
            set { points = value; }
        }

        public static int Lives
        {
            get { return lives; }
            set { lives = value; }
        }

        public static int Scarabs
        {
            get { return scarabs; }
            set { scarabs = value; }
        }

        public static bool DoorsAreClosed
        {
            get { return doorsAreClosed; }
            set { doorsAreClosed = value; }
        }

        public static int MinimalPointsForNextLevel
        {
            get { return minimalPointsForNextLevel; }
            set { minimalPointsForNextLevel = value; }
        }

        public static void Initialize()
        {
            points = 0;
            lives = 3;
            scarabs = 0;            
            doorsAreClosed = true;
            minimalPointsForNextLevel = 500;
        }

        public static bool openDoors()
        {
            //ternary
            return (points > minimalPointsForNextLevel) ? true : false;
         }

        public static bool isDead()
        {
            //ternary
            return (lives < 1) ? true : false;
        }
    }
}
