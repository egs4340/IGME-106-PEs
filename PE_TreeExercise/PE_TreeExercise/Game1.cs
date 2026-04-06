using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PE_TreeExercise
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // The three trees
        private Tree treeRed;
        private Tree treeGreen;
        private Tree treeBlue;


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Initialize all three trees
            treeRed = new Tree(_spriteBatch, Color.Red);
            treeGreen = new Tree(_spriteBatch, Color.Green);
            treeBlue = new Tree(_spriteBatch, Color.DodgerBlue);

            // *** FILL EACH TREE WITH DATA HERE ***************************
            treeRed.Add(0);
            treeGreen.Add(0);
            treeBlue.Add(0);
            // *************************************************************
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // *************************************************************
            // *** After you have the rest of the assignment working: ******
            //  What happens if you insert a new piece of 
            //  data into the trees each frame?


            // *************************************************************

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // Draw the trees
            treeRed.Draw(new Vector2(200, 400));
            treeGreen.Draw(new Vector2(400, 400));
            treeBlue.Draw(new Vector2(600, 400));

            base.Draw(gameTime);
        }

    }
}
