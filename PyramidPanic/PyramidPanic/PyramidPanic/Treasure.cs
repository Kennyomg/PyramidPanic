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
    public class Treasure : Image
    {
        //Fields
        private Char character;

        //Properties
        public Char Character
        {
            get { return this.character; }
            set { this.character = value; }
        }

        //Constructor
        public Treasure(Char character, PyramidPanic game, string pathName, Vector2 position)  
            :base(game, pathName, position)
        {
            this.character = character;
        }
    }
}
