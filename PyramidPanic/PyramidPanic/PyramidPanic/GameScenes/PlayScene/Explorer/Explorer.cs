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
    public class Explorer : IAnimatedSprite
    {
        //Fields
        private PyramidPanic game;
        private Texture2D texture, collisionText;
        private Rectangle rectangle, collisionRectangle;
        private Vector2 position;
        private float speed;
        private Color color;

        //State variable is de parentclass van de toestandsklassen
        AnimatedSprite state;

        //Properties
        public AnimatedSprite State
        {
            set { this.state = value; }
        }

        public PyramidPanic Game
        {
            get { return this.game; }
        }

        public Rectangle Rectangle
        {
            get { return this.rectangle; }
        }

        public Rectangle CollisionRectangle
        {
            get { return this.collisionRectangle; }
        }

        public Texture2D Texture
        {
            get { return this.texture; }
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

        public float Speed
        {
            get { return this.speed; }
        }

        public Color Color
        {
            get { return this.color; }
        }

        //Constructor
        public Explorer(PyramidPanic game, Vector2 position, float speed)
        {
            this.game = game;
            this.position = position;
            this.speed = speed;
            this.texture = this.game.Content.Load<Texture2D>(@"PlaySceneAssets\Explorer\Explorer");
            this.rectangle = new Rectangle((int)position.X + 16,
                                           (int)position.Y + 16,
                                           this.texture.Width/4,
                                           this.texture.Height);
            this.collisionText = this.game.Content.Load<Texture2D>(@"PlaySceneAssets\Explorer\collisionTexture");
            this.collisionRectangle = new Rectangle((int)position.X,
                                                    (int)position.Y,
                                                    32,
                                                    32);
            this.color = Color.White;
            this.state = new Idle(this);
        }

        public void Update(GameTime gameTime)
        {
            ExplorerManager.Explorer = this;
            ExplorerManager.CollisionDetectTreasures();
            ExplorerManager.CollisionDetectScorpions();
            ExplorerManager.CollisionDetectBeetles();
            ExplorerManager.CollisionDetectMummies();
            
            this.state.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            //this.game.SpriteBatch.Draw(this.collisionText, this.collisionRectangle, Color.White);
            this.state.Draw(gameTime);
        }
    }
}
