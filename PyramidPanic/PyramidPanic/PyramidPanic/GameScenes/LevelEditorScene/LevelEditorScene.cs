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
    public class LevelEditorScene : IStateGame
    {
        //Fields
        private PyramidPanic game;
        private Level level;
        private int levelIndex = 0;
        private LevelEditorPanel levelEditorPanel;
        

        //Properties
        public PyramidPanic Game
        {
            get { return this.game; }
        }

        public int LevelIndex
        {
            get { return this.levelIndex; }
            set { this.levelIndex = value; }
        }

        public Level Level
        {
            get { return this.level; }
            set { this.level = value; }
        }

        //Constructor
        public LevelEditorScene(PyramidPanic game)
        {
            this.game = game;
            this.Initialize();
        }

        //Initialize
        public void Initialize()
        {
            this.LoadContent();
        }

        //LoadContent
        public void LoadContent()
        {
            this.levelEditorPanel = new LevelEditorPanel(this, new Vector2(0f, 448f));
            this.LoadLevel();
        }

        public void LoadLevel()
        {
            this.level = new Level(this.game, this.levelIndex);
        }

        //Update
        public void Update(GameTime gameTime)
        {
            if (Input.EdgeDetectKeyDown(Keys.Escape) || Input.EdgeDetectButtonDown(Buttons.B))
            {
                this.game.GameState = new StartScene(this.game);
            }
            if (Input.EdgeDetectKeyDown(Keys.B))
            {
                this.game.GameState = new StartScene(this.game);
            }
            this.levelEditorPanel.Update(gameTime);            
        }

        //Draw
        public void Draw(GameTime gameTime)
        {
            this.game.GraphicsDevice.Clear(Color.Olive);
            this.level.Draw(gameTime);
            this.levelEditorPanel.Draw(gameTime);
        }
    }
}

