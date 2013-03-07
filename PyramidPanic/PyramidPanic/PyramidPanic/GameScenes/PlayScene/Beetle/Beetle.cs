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
    public class Beetle : IAnimatedSprite
    {
        //Field
        private PyramidPanic game;
        private Texture2D texture, collisionTexture;
        private Vector2 position;
        private Rectangle rectangle, collisionRectangle;
        private IBeetle state;
        private float speed;
        private float top, bottom;
        private Color color;
       

        //Properties
        public float Top
        {
            set { this.top = value; }
            get { return this.top; }
        }
        public float Bottom
        {
            get { return this.bottom; }
            set { this.bottom = value; }
        }
        public float Speed
        {
            get { return this.speed; }
        }
        public Vector2 Position
        {
            get { return this.position; }
            set 
            { 
                this.position = value;
                this.rectangle.X = (int)this.position.X + 16;
                this.rectangle.Y = (int)this.position.Y + 16;
                this.collisionRectangle.X = (int)this.position.X;
                this.collisionRectangle.Y = (int)this.position.Y;
            }
        }
        public PyramidPanic Game
        {
            get { return this.game; }
        }
        public Texture2D Texture
        {
            get { return this.texture; }
        }
        public Rectangle Rectangle
        {
            get { return this.rectangle; }
        }
        public Rectangle CollisionRectangle
        {
            get { return this.collisionRectangle; }
        }
        public IBeetle State
        {
            get { return this.state; }
            set { this.state = value; }
        }
        public Color Color
        {
            get { return this.color; }
            set { this.color = value; }
        }

        //De constructor
        public Beetle(PyramidPanic game, Vector2 position, float speed)
        {
            this.game = game;
            this.texture = game.Content.Load<Texture2D>(@"PlaySceneAssets\Beetles\Beetle");
            this.collisionTexture = game.Content.Load<Texture2D>(@"PlaySceneAssets\Explorer\collisionTexture");
            this.position = position;
            this.speed = speed;
            this.rectangle = new Rectangle((int)this.position.X + 16, (int)this.position.Y + 16, this.texture.Width/4, this.texture.Height);
            this.collisionRectangle = new Rectangle((int)this.position.X, (int)this.position.Y, this.texture.Width / 4, this.texture.Height);
            this.color = Color.White;
            this.state = new WalkDown(this);
        }

        //Update
        public void Update(GameTime gameTime)
        {
            this.state.Update(gameTime);
        }

        //Draw methode
        public void Draw(GameTime gameTime)
        {
            //this.game.SpriteBatch.Draw(this.collisionTexture, this.collisionRectangle, Color.White);
            this.state.Draw(gameTime);
        }
    }
}
