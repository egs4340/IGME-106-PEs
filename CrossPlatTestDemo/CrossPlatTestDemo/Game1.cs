using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CrossPlatTestDemo
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D dog;
        private Texture2D whitebox;

        private int screenWidth;
        private int screenHeight;
        private int xPosition;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            screenWidth = _graphics.PreferredBackBufferWidth;
            screenHeight = _graphics.PreferredBackBufferHeight;
            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            dog = Content.Load<Texture2D>("dog");
            whitebox = Content.Load<Texture2D>("WhiteBackground");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            xPosition += 3;

            if(xPosition > screenWidth)
                xPosition = dog.Width;
            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();


            _spriteBatch.Draw(
                dog,                     //Texture2D
                new Vector2(xPosition, 0),       //Location upper left corner
                Color.Red);              //color tint


            _spriteBatch.Draw(
                dog,                                 //Texture2D
                new Vector2(screenWidth/2, 0),       //Location upper left corner
                Color.Blue);                         //color tint


            _spriteBatch.Draw(
                whitebox,                             //Texture2D
                new Rectangle(screenWidth/2, screenHeight/2, screenWidth/2, screenHeight/2),                      //Location upper left corner
                Color.Blue);                          //color tint


            _spriteBatch.End();


            base.Draw(gameTime);
        }
    }
}
