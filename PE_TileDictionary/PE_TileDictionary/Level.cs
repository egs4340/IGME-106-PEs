using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_TileDictionary
{

    //Sprite batch is to draw the sprites/tiles to the screen, the leveltile 2d array is for the columns and rows for the tile sprites.
    //the intended scaling is to make sure the tiles are scaled properly/resize them
    //sprite sheet is for the roguelikeSheet png
    //dictionary is for the name the text file defines to a specific sprite and the source rectangle on the sprite sheet


    /// <summary>
    /// Class representing a series of LevelTile objects in a top-down game.
    /// </summary>
    public class Level
    {
        // Drawing: Draw the level to game window
        private SpriteBatch _spriteBatch;

        // Level design: Need a set of tiles for the floor
        private LevelTile[,] tileSet;

        // Level design: What size should each floor tile be?
        private int intendedSize;

        // Texture mapping: Which sprite sheet is the level pulling images from?
        private Texture2D spriteSheet;

        // Texture mapping: Uses a file to store texture name to source rectangle information
        private Dictionary<string, Rectangle> textureMap;


        /// <summary>
        /// Constructs a Level object.
        /// </summary>
        /// <param name="spriteSheet">Which image are the sprites coming from?</param>
        /// <param name="filepath">Which file holds image data?</param>
        public Level(Texture2D spriteSheet, string filepath, SpriteBatch _spriteBatch)
        {
            // *** FIELDS OF THE CLASS: ***
            // ------------------------------------------------------------------------------------
            // SpriteBatch reference is set
            this._spriteBatch = _spriteBatch;

            // Each LevelTile is rendered at 64 x 64 pixels
            intendedSize = 64;

            // The sprite sheet that contains all images
            this.spriteSheet = spriteSheet;

            // The Dictionary contains a source rectangle for each of the chosen image tiles
            textureMap = new Dictionary<string, Rectangle>();


            // *** TEXTURE MAPPING IS PERFORMED HERE: ***
            // ------------------------------------------------------------------------------------
            // Need to know each sprite's size for texture mapping
            // (This info will come from the file. For now, set to 0 before we read the data.)
            int spriteWidth = 0;
            int spriteHeight = 0;

            try
            {
                StreamReader reader = new StreamReader(filepath);

                // Get string variables ready for file lines being split!
                string line = "";
                string[] splitData = null;

                while ((line = reader.ReadLine()) != null)
                {
                    // Split line if is not a comment
                    if (line.Substring(0, 1) != "/" && line.Substring(0, 1) != "-")
                    {
                        splitData = line.Split(',');

                        // Set width and height of sprites
                        if (splitData.Length == 2)
                        {
                            spriteWidth = int.Parse(splitData[0]);
                            spriteHeight = int.Parse(splitData[1]);
                        }

                        // Add tiles to dictionary
                        if (splitData.Length == 3)
                        {
                            textureMap.Add(splitData[0],
                                new Rectangle(int.Parse(splitData[2]) * spriteWidth + int.Parse(splitData[2]),
                                int.Parse(splitData[1]) * spriteHeight + int.Parse(splitData[1]),
                                spriteWidth, spriteHeight));
                        }
                    }
                }

                // Close the stream
                reader.Close();
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine("FILE-READING ERROR UPON CONSTRUCTING LEVEL!");
                System.Diagnostics.Debug.WriteLine(error.Message);
            }


            // *** TEST LEVELS: ***
            // ------------------------------------------------------------------------------------
            // Test BEFORE the dictionary is in place.
            //TestLevel_BEFORE_Dictionary();

            // Test AFTER the dictionary is in place, but BEFORE level data is read in.
            //TestLevel_AFTER_Dictionary_NoLevelData();

            // Test AFTER everything is complete!
            LoadLevel("../../../Content/level1.csv");
        }


        #region Displaying Tiles in the window
        /// <summary>
        /// Draw all LevelTiles to the game window.
        /// </summary>
        /// <param name="_spriteBatch">SpriteBatch object (passed in from Game1 Draw)</param>
        public void DisplayTiles()
        {
            // Iterate and draw all tiles in the 2D array of LevelTiles.
            for (int r = 0; r < tileSet.GetLength(0); r++)
            {
                for (int c = 0; c < tileSet.GetLength(1); c++)
                {
                    tileSet[r, c].Draw(_spriteBatch);
                }
            }
        }
        #endregion


        #region Level Testing Methods called in the constructor
        /// <summary>
        /// Creates a 3 x 3 set of tiles that focus on the water feature.
        /// Does not need the texture mapping dictionary or level data from files.
        /// This is a hard-coded way to display a level and is DISCOURAGED for student work. :)
        /// </summary>
        public void TestLevel_BEFORE_Dictionary()
        {
            // Generate a 3 x 3 set of LevelTiles.
            tileSet = new LevelTile[3, 3];

            // First row of tiles:
            tileSet[0, 0] =
                new LevelTile(
                    spriteSheet,                                            // Sprite sheet to pull from
                    new Rectangle(0, 0, intendedSize, intendedSize),        // Drawn location, width and height
                    0,                                                      // Sprite sheet info: Which row?
                    2);                                                     // Sprite sheet info: Which column?
            tileSet[0, 1] =
                new LevelTile(
                    spriteSheet,
                    new Rectangle(64, 0, intendedSize, intendedSize),
                    0,
                    3);
            tileSet[0, 2] =
                new LevelTile(
                    spriteSheet,
                    new Rectangle(128, 0, intendedSize, intendedSize),
                    0,
                    4);

            // Second row of tiles:
            tileSet[1, 0] =
                new LevelTile(
                    spriteSheet,
                    new Rectangle(0, 64, intendedSize, intendedSize),
                    1,
                    2);
            tileSet[1, 1] =
                new LevelTile(
                    spriteSheet,
                    new Rectangle(64, 64, intendedSize, intendedSize),
                    1,
                    3);
            tileSet[1, 2] =
                new LevelTile(
                    spriteSheet,
                    new Rectangle(128, 64, intendedSize, intendedSize),
                    1,
                    4);

            // Third row of tiles:
            tileSet[2, 0] =
                new LevelTile(
                    spriteSheet,
                    new Rectangle(0, 128, intendedSize, intendedSize),
                    2,
                    2);
            tileSet[2, 1] =
                new LevelTile(
                    spriteSheet,
                    new Rectangle(64, 128, intendedSize, intendedSize),
                    2,
                    3);
            tileSet[2, 2] =
                new LevelTile(
                    spriteSheet,
                    new Rectangle(128, 128, intendedSize, intendedSize),
                    2,
                    4);
        }

        /// <summary>
        /// Creates a 3 x 3 set of tiles that focus on the water feature.
        /// Requires the texture mapping dictionary, but not level data.
        /// </summary>
        public void TestLevel_AFTER_Dictionary_NoLevelData()
        {
            // Generate a 3 x 3 set of LevelTiles.
            tileSet = new LevelTile[3, 3];

            // First row of tiles:
            tileSet[0, 0] =
                new LevelTile(
                    spriteSheet,                                                // Sprite sheet to pull from
                    new Rectangle(0, 0, intendedSize, intendedSize),            // Drawn location, width and height 
                    textureMap["WATER-corner-upper-left"]);                     // Looksup course rectangle from the texture map dictionary
            tileSet[0, 1] =
                new LevelTile(
                    spriteSheet,
                    new Rectangle(64, 0, intendedSize, intendedSize),
                    textureMap["WATER-edge-top"]);
            tileSet[0, 2] =
                new LevelTile(
                    spriteSheet,
                    new Rectangle(128, 0, intendedSize, intendedSize),
                    textureMap["WATER-corner-upper-right"]);

            // Second row of tiles:
            tileSet[1, 0] =
                new LevelTile(
                    spriteSheet,
                    new Rectangle(0, 64, intendedSize, intendedSize),
                    textureMap["WATER-edge-left"]);
            tileSet[1, 1] =
                new LevelTile(
                    spriteSheet,
                    new Rectangle(64, 64, intendedSize, intendedSize),
                    textureMap["WATER-inner"]);
            tileSet[1, 2] =
                new LevelTile(
                    spriteSheet,
                    new Rectangle(128, 64, intendedSize, intendedSize),
                    textureMap["WATER-edge-right"]);

            // Third row of tiles:
            tileSet[2, 0] =
                new LevelTile(
                    spriteSheet,
                    new Rectangle(0, 128, intendedSize, intendedSize),
                    textureMap["WATER-corner-lower-left"]);
            tileSet[2, 1] =
                new LevelTile(
                    spriteSheet,
                    new Rectangle(64, 128, intendedSize, intendedSize),
                    textureMap["WATER-edge-bottom"]);
            tileSet[2, 2] =
                new LevelTile(
                    spriteSheet,
                    new Rectangle(128, 128, intendedSize, intendedSize),
                    textureMap["WATER-corner-lower-right"]);
        }
        #endregion


        /// <summary>
        /// Reads data from a level file.
        /// </summary>
        /// <param name="filepath">Which level file to use?</param>
        public void LoadLevel(string filepath)
        {
            // Read data from a text file and create the tileset that way
            try
            {
                // ***SETUP VARIABLES FOR FILE READING: ***
                // ------------------------------------------------------------------------------------
                StreamReader reader = new StreamReader(filepath);
                string line = "";
                string[] splitData = null;

                // Needed for determining individual tile data placement
                int currentRow = 0;

                // ***GET DATA FROM FIRST 2 LINES FOR TILE INFORMATION ***
                // ------------------------------------------------------------------------------------
                // The first 2 lines give information about this level:
                // Line 1: How large should the level tiles be?
                line = reader.ReadLine();
                splitData = line.Split(',');
                int tileWidth = int.Parse(splitData[1]);
                int tileHeight = int.Parse(splitData[2]);

                // Line 2: How many tiles are there?
                line = reader.ReadLine();
                splitData = line.Split(',');
                int tilesetColumns = int.Parse(splitData[1]);
                int tilesetRows = int.Parse(splitData[2]);

                // Initialize the tileSet array to the correct size
                tileSet = new LevelTile[tilesetColumns, tilesetRows];

                // ***READ TILE TEXTURE INFORMATION TO GENERATE LEVELTILES ***
                // ------------------------------------------------------------------------------------
                // Read data line by line for tiles
                while ((line = reader.ReadLine()) != null)
                {
                    // Get this line of tile data and split by comma.
                    // That gives us data like: "WATER-inner,GRASS-1,DIRT-2"
                    splitData = line.Split(',');

                    // For each of the tiles across a row...
                    for (int c = 0; c < splitData.Length; c++)
                    {
                        //Create a new tile with the location on the window and the texture and location given in the text file
                        LevelTile tile = new LevelTile(spriteSheet,
                            new Rectangle(tileWidth * c, tileHeight * currentRow, tileWidth, tileHeight),
                            textureMap[splitData[c]]);

                        //Add the new tile to the 2D array at the current column and row
                        tileSet[c, currentRow] = tile;
                    }

                    // Increase the row
                    currentRow++;
                }

                // Close the stream
                reader.Close();
            }
            catch (Exception error)
            {
                System.Diagnostics.Debug.WriteLine("FILE-READING ERROR UPON LOADING LEVEL!");
                System.Diagnostics.Debug.WriteLine(error.Message);
            }
        }
    }

}

