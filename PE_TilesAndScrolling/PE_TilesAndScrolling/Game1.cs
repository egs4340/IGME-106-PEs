using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.IO;

namespace PE_TilesAndScrolling
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D[] mapSet;
        private Texture2D grass;
        private Texture2D crops;
        private Texture2D stump;
        private Texture2D tree;
        private Texture2D pineTree;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            grass = Content.Load<Texture2D>("grass_1");
            crops = Content.Load<Texture2D>("farm_small_crops");
            stump = Content.Load<Texture2D>("tree_chop_1");
            tree = Content.Load<Texture2D>("tree_round_2");
            pineTree = Content.Load<Texture2D>("tree_xmas_3");

            
            try
            {
                StreamReader reader = new StreamReader("Content/TileSet.txt");
                string line = "";

                while ((line = reader.ReadLine()) != null)
                {
                    string[] mapRow = line.Split(',');

                    for(int i = 0; i <  mapRow.Length; i++)
                    {

                    }

                }
                
                    
            }


        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
