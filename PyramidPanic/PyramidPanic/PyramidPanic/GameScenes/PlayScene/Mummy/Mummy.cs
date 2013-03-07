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
    public class Mummy : IAnimatedSprite
    {
        //Fields
        private PyramidPanic game;
        private Texture2D texture, collisionText;
        private Rectangle rectangle, collisionRectangle;
        private Vector2 position;
        private float speed;
        private float chaseSpeed;
        private float normalSpeed;
        private int chaseDistance;
        private Color color;
        private MummyChase mummyChase;
        private MummyUp mummyUp;
        private MummyDown mummyDown;
        private MummyLeft mummyLeft;
        private MummyRight mummyRight;

        //State variable is de parentclass van de toestandsklassen
        AnimatedSprite state;

        //Properties
        public AnimatedSprite State
        {
            set { this.state = value; }
            get { return this.state; }
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
            set { this.speed = value; }
        }
        public float ChaseSpeed
        {
            get { return this.chaseSpeed; }
            set { this.chaseSpeed = value; }
        }
        public float NormalSpeed
        {
            get { return this.normalSpeed; }
            set { this.normalSpeed = value; }
        }
        public int ChaseDistance
        {
            get { return this.chaseDistance; }
            set { this.chaseDistance = value; }
        }
        public Color Color
        {
            get { return this.color; }
            set { this.color = value; }
        }
        public MummyChase MummyChase
        {
            get { return this.mummyChase; }
            set { this.mummyChase = value; }
        }
        public MummyUp MummyUp
        {
            get { return this.mummyUp; }
            set { this.mummyUp = value; }
        }
        public MummyDown MummyDown
        {
            get { return this.mummyDown; }
            set { this.mummyDown = value; }
        }
        public MummyLeft MummyLeft
        {
            get { return this.mummyLeft; }
            set { this.mummyLeft = value; }
        }
        public MummyRight MummyRight
        {
            get { return this.mummyRight; }
            set { this.mummyRight = value; }
        }
        
        //Constructor
        public Mummy(PyramidPanic game, Vector2 position, float speed)
        {
            this.game = game;
            this.position = position;
            this.speed = speed;
            this.chaseSpeed = 1.5f;
            this.normalSpeed = 1.0f;
            this.chaseDistance = 150;
            this.texture = this.game.Content.Load<Texture2D>(@"PlaySceneAssets\Mummies\Mummy");
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
            this.mummyUp = new MummyUp(this);
            this.mummyDown = new MummyDown(this);
            this.mummyLeft = new MummyLeft(this);
            this.mummyRight = new MummyRight(this);
            this.mummyChase = new MummyChase(this);
            this.state = new MummyUp(this);
        }

        public void Update(GameTime gameTime)
        {
            MummyManager.Mummy = this;
            /* Maak de mummies rood als ze binnen een straal van 100 pixels zitten en 
             * maak ze wit als ze daar niet binnen zitten. */
            //ExplorerManager.Distance(this);
            this.state.Update(gameTime);
        }

        public void Draw(GameTime gameTime)
        {
            //this.game.SpriteBatch.Draw(this.collisionText, this.collisionRectangle, Color.White);
            this.state.Draw(gameTime);
        }
    }
}
