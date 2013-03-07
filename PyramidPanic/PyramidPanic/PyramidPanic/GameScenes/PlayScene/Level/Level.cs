using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Storage;

namespace PyramidPanic
{
    public class Level
    {
        //Fields
        private PyramidPanic game;
        private string levelPath;
        private List<string> lines;
        private Block[,] blocks;
        private const int GRIDWIDTH = 32;
        private const int GRIDHEIGHT = 32;
        private Image background;
        private List<Image> treasures;
        private Panel panel;
        //private Scorpion scorpion;
        private List<Scorpion> scorpions;
        private List<Beetle> beetles;
        private List<Mummy> mummies;
        private Stream stream;
        private Explorer explorer;
        private ILevel levelState;
        private LevelPause levelPause;
        private LevelPlay levelPlay;
        private LevelDoorOpen levelDoorOpen;
        private LevelGameOver levelGameOver;
        private LevelNextLevel levelNextLevel;
        private int levelIndex;

        //Properties
        public List<Image> Treasures
        {
            get { return this.treasures; }
            set { this.treasures = value; }
        }

        public List<Scorpion> Scorpions
        {
            get { return this.scorpions; }
        }

        public List<Beetle> Beetles
        {
            get { return this.beetles; }
        }

        public List<Mummy> Mummies
        {
            get { return this.mummies; }
        }

        public Explorer Explorer
        {
            get { return this.explorer; }
            set { this.explorer = value; }
        }

        public Block[,] Blocks
        {
            get { return this.blocks; }
        }

        public PyramidPanic Game
        {
            get { return this.game; }
        }

        public ILevel LevelState
        {
            get { return this.levelState; }
            set { this.levelState = value; }
        }

        public LevelPause LevelPause
        {
            get { return this.levelPause; }
            set { this.levelPause = value; }
        }

        public LevelPlay LevelPlay
        {
            get { return this.levelPlay; }
            set { this.levelPlay = value; }
        }

        public LevelDoorOpen LevelDoorOpen
        {
            get { return this.levelDoorOpen; }
            set { this.levelDoorOpen = value; }
        }

        public LevelGameOver LevelGameOver
        {
            get { return this.levelGameOver; }
            set { this.levelGameOver = value; }
        }

        public LevelNextLevel LevelNextLevel
        {
            get { return this.levelNextLevel; }
            set { this.levelNextLevel = value; }
        }

        public int LevelIndex
        {
            get { return this.levelIndex; }
        }

        public string LevelPath
        {
            get { return this.levelPath; }
        }

        //Constructor
        public Level(PyramidPanic game, int levelIndex)
        {
            this.game = game;
            this.levelIndex =  levelIndex;
            /*
            System.IO.Stream stream = TitleContainer.OpenStream(@"Content\PlaySceneAssets\Levels\0.txt");
            System.IO.StreamReader sreader = new System.IO.StreamReader(stream);
            // use StreamReader.ReadLine or other methods to read the file data

            Console.WriteLine("File Size: " + stream.Length);
            stream.Close();
            */

            this.levelPath = @"Content\PlaySceneAssets\Levels\" + levelIndex + ".txt";
            this.stream = TitleContainer.OpenStream(this.levelPath);
            //this.levelPath = @"Content\PlaySceneAssets\Levels\0.txt";
            //this.levelPath = @"Content\PlaySceneAssets\Levels\" + levelIndex + ".txt";

            //eeee
            //IAsyncResult result = StorageDevice.BeginShowSelector(
            //        PlayerIndex.One, null, null);
            //StorageDevice device = StorageDevice.EndShowSelector(result);
            //device.BeginOpenContainer.

            //eeeee
            this.LoadAssets();
            ExplorerManager.Explorer = this.explorer;
            this.levelPause = new LevelPause(this);
            this.levelPlay = new LevelPlay(this);
            this.levelDoorOpen = new LevelDoorOpen(this);
            this.levelGameOver = new LevelGameOver(this);
            this.levelNextLevel = new LevelNextLevel(this);
            this.levelState = this.levelPlay;
            this.stream.Close();
        }

        private void LoadAssets()
        {
            this.treasures = new List<Image>();
            this.scorpions = new List<Scorpion>();
            this.beetles = new List<Beetle>();
            this.mummies = new List<Mummy>();
            this.panel = new Panel(this.game, new Vector2(0f, 448f));
            this.lines = new List<string>();
            //StreamReader reader = new StreamReader(this.levelPath);
            StreamReader reader = new StreamReader(this.stream);
            string line = reader.ReadLine();
            int width = line.Length;
            while ( line != null)
            {
                lines.Add(line);
                line = reader.ReadLine();
            }
            int height = lines.Count;
            this.blocks = new Block[width, height];
            reader.Close();
            this.stream.Close();

            for (int row = 0; row < height; row++)
            {
                for (int column = 0; column < width; column++)
                {
                    char blockElement = this.lines[row][column];
                    this.blocks[column, row] = LoadBlock(blockElement, column * GRIDWIDTH, row * GRIDHEIGHT);
                }
            }
            BeetleManager.Level = this;
            ScorpionManager.Level = this;
            ExplorerManager.Level = this;
            MummyManager.Level = this;
        }

        private Block LoadBlock(char blockElement, int x, int y)
        {
            switch (blockElement)
            {
                case 'a':
                    this.treasures.Add(new Treasure('a', this.game, @"PlaySceneAssets\Treasures\Treasure1", new Vector2(x, y)));
                    return new Block(this.game, @"Transparant", new Vector2(x, y), BlockCollision.Passable, 'a');
                case 'b':
                    this.treasures.Add(new Treasure('b', this.game, @"PlaySceneAssets\Treasures\Treasure2", new Vector2(x, y)));
                    return new Block(this.game, @"Transparant", new Vector2(x, y), BlockCollision.Passable, 'b');
                case 'c':
                    this.treasures.Add(new Treasure('c', this.game, @"PlaySceneAssets\Treasures\Potion", new Vector2(x, y)));
                    return new Block(this.game, @"Transparant", new Vector2(x, y), BlockCollision.Passable, 'c');
                case 'd':
                    this.treasures.Add(new Treasure('d', this.game, @"PlaySceneAssets\Treasures\Scarab", new Vector2(x, y)));
                    return new Block(this.game, @"Transparant", new Vector2(x, y), BlockCollision.Passable, 'd');
                case 'w':
                    return new Block(this.game, @"Block", new Vector2(x, y), BlockCollision.NotPassable, 'w');
                case 'x':
                    return new Block(this.game, @"Wall1", new Vector2(x, y), BlockCollision.NotPassable, 'x');
                case 'y':
                    return new Block(this.game, @"Wall2", new Vector2(x, y), BlockCollision.NotPassable, 'y');
                case 'z':
                    return new Block(this.game, @"Door", new Vector2(x, y), BlockCollision.NotPassable, 'z');
                case 'B':
                    this.beetles.Add(new Beetle(this.game, new Vector2(x, y), 1.0f));
                    return new Block(this.game, @"Transparant", new Vector2(x, y), BlockCollision.Passable, 'B');
                case 'M':
                    this.mummies.Add(new Mummy(this.game, new Vector2(x, y), 1f));
                    return new Block(this.game, @"Transparant", new Vector2(x, y), BlockCollision.Passable, 'M');
                case 'S':
                    this.scorpions.Add(new Scorpion(this.game, new Vector2(x, y), 1.0f));
                    return new Block(this.game, @"Transparant", new Vector2(x, y), BlockCollision.Passable, 'S');
                case 'E':
                    this.explorer = new  Explorer (this.game, new Vector2(x, y), 2.0f);
                    return new Block(this.game, @"Transparant", new Vector2(x, y), BlockCollision.Passable, 'E');
                case '@':
                    this.background = new Image(this.game, @"PlaySceneAssets\Background\Background2", new Vector2(x, y));
                    return new Block(this.game, @"Block", new Vector2(x, y), BlockCollision.NotPassable, '@');
                case '.':
                    return new Block(this.game, @"Transparant", new Vector2(x, y), BlockCollision.Passable, '.');
                default:
                    return new Block(this.game, @"Transparant", new Vector2(x, y), BlockCollision.Passable, '.');
            }
        }

        //Update method
        public void Update(GameTime gameTime)
        {
            this.levelState.Update(gameTime);
        }

        //Draw method
        public void Draw(GameTime gameTime)
        {
            this.background.Draw(gameTime);

            for ( int row = 0; row < this.blocks.GetLength(1); row++ )
            {
                for ( int column = 0; column < this.blocks.GetLength(0); column++ )
                {
                    this.blocks[column, row].Draw(gameTime);
                }
            }

            foreach (Image treasure in this.treasures)
            {
                treasure.Draw(gameTime);
            }

            foreach (Scorpion scorpion in this.scorpions)
            {
                scorpion.Draw(gameTime);
            }

            foreach (Beetle beetle in this.beetles)
            {
                beetle.Draw(gameTime);
            }

            foreach (Mummy mummy in this.mummies)
            {
                mummy.Draw(gameTime);
            }

            if (this.explorer != null)
            {
                this.explorer.Draw(gameTime);
            }
            this.levelState.Draw(gameTime);
            this.panel.Draw(gameTime);
        }
    }
}
