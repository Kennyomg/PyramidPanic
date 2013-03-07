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
    public class Scorpion : IAnimatedSprite
    {
        //Field
        private PyramidPanic game;
        private Texture2D texture, collisionTexture;
        private Vector2 position;
        private Rectangle rectangle, collisionRectangle;
        private IScorpion state;
        private float speed;
        private float right, left;
        private WalkLeft walkLeft;
        private WalkRight walkRight;
        private Color color;

        //Properties
        public WalkLeft WalkLeft
        {
            get { return this.walkLeft; }
        }
        public WalkRight WalkRight
        {
            get { return this.walkRight; }
        }
        public float Left
        {
            set { this.left = value; }
            get { return this.left; }
        }
        public float Right
        {
            set { this.right = value; }
            get { return this.right; }
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
            set { this.collisionRectangle = value; }
        }
        public IScorpion State
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
        public Scorpion(PyramidPanic game, Vector2 position, float speed)
        {
            this.game = game;
            this.texture = game.Content.Load<Texture2D>(@"PlaySceneAssets\Scorpion\Scorpion");
            this.collisionTexture = game.Content.Load<Texture2D>(@"PlaySceneAssets\Explorer\collisionTexture");
            this.position = position;
            this.speed = speed;
            this.rectangle = new Rectangle((int)this.position.X + 16, (int)this.position.Y + 16, this.texture.Width/4, this.texture.Height);
            this.collisionRectangle = new Rectangle((int)this.position.X,
                                                    (int)this.position.Y,
                                                    this.texture.Width / 4,
                                                    this.texture.Height);
            this.color = Color.White;
            this.walkLeft = new WalkLeft(this);
            this.walkRight = new WalkRight(this);
            this.state = this.walkRight;
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
