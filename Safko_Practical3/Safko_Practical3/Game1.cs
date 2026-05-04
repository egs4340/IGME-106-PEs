using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Safko_Practical3
{
    // Evan Safko - 5/4/2026
    public class Game1 : Game
    {
        // Built-in MonoGame fields
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        // The maze itself
        Maze maze;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            // Create the maze
            maze = new Maze(GraphicsDevice);
            this.IsMouseVisible = true;

            // Initialize the base
            base.Initialize();
        }

        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Set up the maze data
            maze.SetMaze(
                Content.Load<Texture2D>("maze_simple"),
                GraphicsDevice.Viewport.Width,
                GraphicsDevice.Viewport.Height);


            // Calls the recursive solution
            int number = 481632;
            System.Diagnostics.Debug.WriteLine($"The digit sum of {number} is {maze.CalcDigitSum(number)}");

            number = 1234;
            System.Diagnostics.Debug.WriteLine($"The digit sum of {number} is {maze.CalcDigitSum(number)}");

            number = 9;
            System.Diagnostics.Debug.WriteLine($"The digit sum of {number} is {maze.CalcDigitSum(number)}");
        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightBlue);

            // Draw the maze
            spriteBatch.Begin();
            maze.Draw(spriteBatch);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }

}
