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

namespace PyramidPanic
{
    public class LevelEditorPanel
    {
        //Fields
        private LevelEditorScene levelEditorScene;
        private Vector2 position;
        private Image background;
        private List<Image> levelEditorButtons, levelEditorAssets;
        private int levelEditorAssetsIndex = 0;
        private SpriteFont Arial;

        //Properties
        public List<Image> LevelEditorAssets
        {
            get { return this.levelEditorAssets; }
        }

        //Constructor
        public LevelEditorPanel(LevelEditorScene levelEditorScene, Vector2 position)
        {
            this.levelEditorScene = levelEditorScene;
            this.position = position;
            this.Initialize();
        }

        //Initialize
        private void Initialize()
        {
            this.LoadContent();
        }

        //LoadContent
        private void LoadContent()
        {
            this.Arial = this.levelEditorScene.Game.Content.Load<SpriteFont>(@"PlaySceneAssets\Fonts\Arial");
            this.levelEditorButtons = new List<Image>();
            this.levelEditorAssets = new List<Image>();
            //levelnumber verlagen
            this.levelEditorButtons.Add(
                new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Left",
                    this.position + new Vector2(2.5f * 32f, 0f)));
            //levelnumber verhogen
            this.levelEditorButtons.Add(
                new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Right",
                    this.position + new Vector2(4.5f * 32f, 0f)));
            //plaatje wisselen naar beneden in list
            this.levelEditorButtons.Add(
                new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Left",
                    this.position + new Vector2(9f * 32f, 0f)));
            //plaatje wisselen naar omhoog in list
            this.levelEditorButtons.Add(
                new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Right",
                    this.position + new Vector2(11f * 32f, 0f)));
            this.levelEditorButtons.Add(
                new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Button_save",
                    this.position + new Vector2(15f * 32f, 0f)));

            //Assets toevoegen aan de list levelEditorAssets
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"PlaySceneAssets\Blocks\Block",
                                                    this.position + new Vector2(10f * 32f, 0f)));
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"PlaySceneAssets\Blocks\Door",
                                                    this.position + new Vector2(10f * 32f, 0f)));
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"PlaySceneAssets\Blocks\Wall1",
                                                    this.position + new Vector2(10f * 32f, 0f)));
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"PlaySceneAssets\Blocks\Wall2",
                                                    this.position + new Vector2(10f * 32f, 0f)));
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Beetle",
                                                    this.position + new Vector2(10f * 32f, 0f)));
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Scorpion",
                                                    this.position + new Vector2(10f * 32f, 0f)));
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorAssets\mummy",
                                                    this.position + new Vector2(10f * 32f, 0f)));
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Potion",
                                                   this.position + new Vector2(10f * 32f, 0f)));
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Scarab",
                                                   this.position + new Vector2(10f * 32f, 0f)));
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Treasure1",
                                                   this.position + new Vector2(10f * 32f, 0f)));
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Treasure2",
                                                   this.position + new Vector2(10f * 32f, 0f)));
            this.levelEditorAssets.Add(new Image(this.levelEditorScene.Game, @"PlaySceneAssets\Panel\Lives",
                                                   this.position + new Vector2(10f * 32f, 0f)));
            this.background = new Image(this.levelEditorScene.Game, @"LevelEditorAssets\Panel", this.position);
        }

        //Update
        public void Update(GameTime gameTime)
        {
            foreach (Image image in this.levelEditorButtons)
            {
                if (image.Rectangle.Intersects(Input.MouseRectangle()))
                {
                    //Bepaal om welk image het gaat in list en geef het indexnummer
                    int indexOfImage = this.levelEditorButtons.IndexOf(image);
                    
                    //Detecteer of er linksgeklikt wordt op muisknop
                    if (Input.MouseEdgeDetectPressLeft())
                    {
                        switch (indexOfImage)
                        {
                            case 0:
                                //ternary
                                this.levelEditorScene.LevelIndex = (this.levelEditorScene.LevelIndex > 0) ?
                                    this.levelEditorScene.LevelIndex-1 : 0;
                                this.levelEditorScene.LoadLevel();
                                break;
                            case 1:
                                //ternary
                                this.levelEditorScene.LevelIndex = (this.levelEditorScene.LevelIndex < 11) ?
                                    this.levelEditorScene.LevelIndex + 1 : 11;
                                this.levelEditorScene.LoadLevel();
                                break;
                            case 2:
                                this.levelEditorAssetsIndex = (this.levelEditorAssetsIndex > 0) ?
                                    this.levelEditorAssetsIndex - 1 : 0;
                                //Console.WriteLine(this.levelEditorAssetsIndex);
                                break;
                            case 3:
                                this.levelEditorAssetsIndex = (this.levelEditorAssetsIndex < this.levelEditorAssets.Count - 1) ?
                                    this.levelEditorAssetsIndex + 1 : this.levelEditorAssets.Count - 1;
                                //Console.WriteLine(this.levelEditorAssetsIndex);
                                break;
                            case 4:
                                this.SaveGame();
                                break;
                            default:
                                break;
                        }                        
                    }
                }
            }

            if ((Input.MouseEdgeDetectPressLeft() || Input.MouseEdgeDetectPressRight()) &&
                 Input.MousePosition().X < 640f &&
                 Input.MousePosition().X > 0f &&
                 Input.MousePosition().Y > 0f &&
                 Input.MousePosition().Y < 448f)
            {
                //Console.WriteLine(this.levelEditorAssetsIndex);
                if (Input.MouseEdgeDetectPressRight())
                {
                    this.RemoveAsset();
                }
                else
                {
                    if (this.levelEditorScene.Level.Explorer.Position !=
                        new Vector2(((int)Input.MousePosition().X / 32) * 32,
                                    ((int)Input.MousePosition().Y / 32) * 32))
                    {
                        this.RemoveAsset();
                        switch (this.levelEditorAssetsIndex)
                        {
                            case 0:
                                this.PlaceBlock(@"Block", 'w');
                                break;
                            case 1:
                                this.PlaceBlock(@"Door", 'z');
                                break;
                            case 2:
                                this.PlaceBlock(@"Wall1", 'x');
                                break;
                            case 3:
                                this.PlaceBlock(@"Wall2", 'y');
                                break;
                            case 4:
                                this.PlaceBlock(@"Transparant", 'B');
                                this.levelEditorScene.Level.Beetles.Add(new Beetle(this.levelEditorScene.Game,
                                                                        new Vector2(((int)Input.MousePosition().X / 32) * 32f,
                                                                                    ((int)Input.MousePosition().Y / 32) * 32f),
                                                                        2.0f));
                                break;
                            case 5:
                                this.PlaceBlock(@"Transparant", 'S');
                                this.levelEditorScene.Level.Scorpions.Add(new Scorpion(this.levelEditorScene.Game,
                                                                          new Vector2(((int)Input.MousePosition().X / 32) * 32f,
                                                                                    ((int)Input.MousePosition().Y / 32) * 32f),
                                                                          2.0f));
                                break;
                            case 6:
                                this.PlaceBlock(@"Transparant", 'M');
                                this.levelEditorScene.Level.Mummies.Add(new Mummy(this.levelEditorScene.Game,
                                                                        new Vector2(((int)Input.MousePosition().X / 32) * 32f,
                                                                                    ((int)Input.MousePosition().Y / 32) * 32f),
                                                                          1.0f));
                                break;
                            case 7:
                                this.PlaceBlock(@"Transparant", 'c');
                                this.addTreasure('c', @"PlaySceneAssets\Treasures\Potion");
                                break;
                            case 8:
                                this.PlaceBlock(@"Transparant", 'd');
                                this.addTreasure('d', @"PlaySceneAssets\Treasures\Scarab");
                                break;
                            case 9:
                                this.PlaceBlock(@"Transparant", 'a');
                                this.addTreasure('a', @"PlaySceneAssets\Treasures\Treasure1");
                                break;
                            case 10:
                                this.PlaceBlock(@"Transparant", 'b');
                                this.addTreasure('b', @"PlaySceneAssets\Treasures\Treasure2");
                                break;
                            case 11:
                                this.PlaceBlock(@"Transparant", 'E');
                                this.levelEditorScene.Level.Explorer = new Explorer(this.levelEditorScene.Game,
                                                                                    new Vector2(((int)Input.MousePosition().X / 32) * 32f,
                                                                                                ((int)Input.MousePosition().Y / 32) * 32f),
                                                                                    2.0f);
                                break;

                        }
                    }
                }
            }           
        }//Update

        private void PlaceBlock(string name, Char charItem)
        {
            this.levelEditorScene.Level.Blocks[(int)Input.MousePosition().X / 32, (int)Input.MousePosition().Y / 32] =
                           new Block(this.levelEditorScene.Game,
                                     name,
                                     new Vector2(((int)Input.MousePosition().X / 32) * 32f,
                                                 ((int)Input.MousePosition().Y / 32) * 32f),
                                     BlockCollision.NotPassable,
                                     charItem);
        }

        private void addTreasure(Char charItem, string name)
        {
            this.levelEditorScene.Level.Treasures.Add(new Treasure(charItem,
                                                                   this.levelEditorScene.Game,
                                                                   name,
                                                                   new Vector2(((int)Input.MousePosition().X / 32) * 32f,
                                                                              ((int)Input.MousePosition().Y / 32) * 32f)));
        }

        private void RemoveAsset()
        {
            foreach (Scorpion scorpion in this.levelEditorScene.Level.Scorpions)
            {
                if (scorpion.Position == new Vector2(((int)Input.MousePosition().X/32)*32, ((int)Input.MousePosition().Y/32)*32))
                {
                    this.levelEditorScene.Level.Scorpions.Remove(scorpion);
                    break;
                }
            }

            foreach (Treasure treasure in this.levelEditorScene.Level.Treasures)
            {
                if (treasure.Position == new Vector2(((int)Input.MousePosition().X / 32) * 32, ((int)Input.MousePosition().Y / 32) * 32))
                {
                    this.levelEditorScene.Level.Treasures.Remove(treasure);
                    break;  
                }
            }

            foreach (Beetle beetle in this.levelEditorScene.Level.Beetles)
            {
                if (beetle.Position == new Vector2(((int)Input.MousePosition().X / 32) * 32, ((int)Input.MousePosition().Y / 32) * 32))
                {
                    this.levelEditorScene.Level.Beetles.Remove(beetle);
                    break;
                }
            }

            foreach (Mummy mummy in this.levelEditorScene.Level.Mummies)
            {
                if (mummy.Position == new Vector2(((int)Input.MousePosition().X / 32) * 32,
                                                  ((int)Input.MousePosition().Y / 32) * 32))
                {
                    this.levelEditorScene.Level.Mummies.Remove(mummy);
                    break;
                }
            }
            Console.WriteLine(this.levelEditorAssetsIndex);
            if (this.levelEditorAssetsIndex == 11)
            {
                this.levelEditorScene.Level.Explorer = null;
            }

            for (int i = 0; i < this.levelEditorScene.Level.Blocks.GetLength(0); i++)
            {
                for (int j = 0; j < this.levelEditorScene.Level.Blocks.GetLength(1); j++)
                {
                    if (this.levelEditorScene.Level.Blocks[i, j].Position ==
                        new Vector2(((int)Input.MousePosition().X / 32) * 32,
                                    ((int)Input.MousePosition().Y / 32) * 32))
                    {
                        this.PlaceBlock("Transparant", '.');
                    }
                }
            }            
        }

        private void SaveGame()
        {
            string contentLevelPath = @"C:\Users\Kenny\Documents\Visual Studio 2010\Projects\Pyramidpanic2\PyramidPanic\PyramidPanic\PyramidPanicContent\PlaySceneAssets\Levels\" + this.levelEditorScene.Level.LevelIndex + ".txt";
            //Tekstbestand in de executable
            StreamWriter writer =
                new StreamWriter(new FileStream(this.levelEditorScene.Level.LevelPath,
                                                FileMode.Open,
                                                FileAccess.Write));
            //Tekstbestand in het project
            StreamWriter writer1 =
                new StreamWriter(new FileStream(contentLevelPath,
                                                FileMode.Open,
                                                FileAccess.Write));
            string line = "";
            for (int j = 0; j < this.levelEditorScene.Level.Blocks.GetLength(1); j++)
            {
                for (int i = 0; i < this.levelEditorScene.Level.Blocks.GetLength(0); i++)
                {
                    if (this.levelEditorScene.Level.Blocks[i, j].CharItem == 'E')
                    {
                        Console.WriteLine(this.levelEditorScene.Level.Blocks[i, j].CharItem);
                    }
                    line += this.levelEditorScene.Level.Blocks[i, j].CharItem;
                }
                writer.WriteLine(line);
                writer1.WriteLine(line);
                line = "";
            }
            writer.Close();
            writer1.Close();
        }

        //Draw
        public void Draw(GameTime gameTime)
        {
            this.background.Draw(gameTime);
            foreach (Image image in this.levelEditorButtons)
            {
                image.Draw(gameTime);
            }
            this.levelEditorAssets[this.levelEditorAssetsIndex].Draw(gameTime);
            //Ternary
            float levelIndexOffset = (levelEditorScene.LevelIndex > 9) ? 3.4f : 3.7f;
            this.levelEditorScene.Game.SpriteBatch.DrawString(this.Arial, 
                this.levelEditorScene.LevelIndex.ToString(), this.position +
                    new Vector2(levelIndexOffset * 32f, -3f), Color.Yellow);
        }
    }
}
