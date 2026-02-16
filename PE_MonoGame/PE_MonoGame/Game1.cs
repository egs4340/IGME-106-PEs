using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PE_MonoGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D dog;
        private Vector2 imagePosition;
        private float xPosition = 50;
        private float yPosition = 50;
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            //initializes a new vector for the image position
            imagePosition = new Vector2(xPosition, yPosition);

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            //loads the dog texture
            dog = Content.Load<Texture2D>("dog");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            
            imagePosition = new Vector2(xPosition++, yPosition);
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AliceBlue);

            _spriteBatch.Begin();
            // TODO: Add your drawing code here

            //draws the dog
            _spriteBatch.Draw(
                dog,
                imagePosition ,
                Color.White);

            _spriteBatch.End();
            base.Draw(gameTime);

        }
    }
}
