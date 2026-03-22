using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using System.Net.Http.Headers;

namespace PE_TilesAndScrolling
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Map fields
        private Vector2 worldPosition;
        private Texture2D[,] mapSet;
        private Texture2D grass;
        private Texture2D crops;
        private Texture2D stump;
        private Texture2D tree;
        private Texture2D pineTree;

        // Player fields
        private Vector2 playerPosition;
        private Texture2D playerImage;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // Initialize map array
            mapSet = new Texture2D[20, 20];

            //Initialize world position
            worldPosition = new Vector2(0, 0);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load player
            playerImage = Content.Load<Texture2D>("player");
            playerPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2 - playerImage.Width/2,
                _graphics.PreferredBackBufferHeight / 2 - playerImage.Height/2);

            // TODO: use this.Content to load your game content here
            grass = Content.Load<Texture2D>("grass_1");
            crops = Content.Load<Texture2D>("farm_small_crops");
            stump = Content.Load<Texture2D>("tree_chop_1");
            tree = Content.Load<Texture2D>("tree_round_2");
            pineTree = Content.Load<Texture2D>("tree_xmas_3");

            //try catch block for the stream reader to get the tile layout
            StreamReader reader = null;
            try
            {
                reader = new StreamReader("Content/TileSet.txt");
                string line = "";
                int row = 0;

                // Read text file and turn it into map tile textures
                while ((line = reader.ReadLine()) != null)
                {
                    string[] mapRow = line.Split(',');

                    for (int i = 0; i < mapRow.Length; i++)
                    {
                        switch (mapRow[i])
                        {
                            case "0":
                                mapSet[row, i] = grass;
                                break;

                            case "1":
                                mapSet[row, i] = crops;
                                break;

                            case "2":
                                mapSet[row, i] = stump;
                                break;

                            case "3":
                                mapSet[row, i] = tree;
                                break;

                            case "4":
                                mapSet[row, i] = pineTree;
                                break;
                        }
                    }
                    row++;
                }
            }
            catch(Exception error)
            {
                System.Diagnostics.Debug.WriteLine(error.Message);
            }
            finally
            {
                // Close reader
                if(reader != null)
                {
                    reader.Close();
                }
            }



        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            //Get keyboard information
            KeyboardState kbState= Keyboard.GetState();

            //Move player
            if(kbState.IsKeyDown(Keys.W))
            {
                worldPosition.Y-=5;
            }
            if (kbState.IsKeyDown(Keys.A))
            {
                worldPosition.X-=5;
            }
            if (kbState.IsKeyDown(Keys.S))
            {
                worldPosition.Y+=5;
            }
            if (kbState.IsKeyDown(Keys.D))
            {
                worldPosition.X+=5;
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            //Determine world to screen difference
            Vector2 worldToScreen = playerPosition - worldPosition;

            _spriteBatch.Begin();

            // Draw map to screen
            for(int i = 0; i < mapSet.GetLength(0); i++)
            {
                for(int j = 0; j < mapSet.GetLength(1); j++)
                {
                    _spriteBatch.Draw(
                        mapSet[i, j],
                        (new Vector2
                        (j * mapSet[i,j].Width,
                        i* mapSet[i, j].Height)) + worldToScreen,
                        Color.White
                        );
                }
            }

            // Draw player
            _spriteBatch.Draw(
                playerImage,
                playerPosition,
                Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
