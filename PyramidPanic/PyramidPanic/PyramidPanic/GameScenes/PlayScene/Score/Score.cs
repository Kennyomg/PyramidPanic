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
        private static int points = 0; 
        private static int lives = 3;
        private static int scarabs = 0;
        private static int minPoints = 500;
        private static bool doorsAreClosed = true;

        public static bool DoorsAreClosed
        {
            get { return doorsAreClosed; }
            set { doorsAreClosed = value; }
        }

        public static int Points
        {
            get { return points; }
            set { points = value; }
        }
        public static int MinPoints
        {
            get { return minPoints; }
            set { minPoints = value; }
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

        public static void Initialize()
        {
            doorsAreClosed = true;
            //minPoints = 500;
        }

        public static bool OpenDoors()
        {
            //ternary
            return (points >= minPoints) ? true : false;
        }
        public static bool isDead()
        {
            return (lives < 1) ? true : false;
        }
    }
}
