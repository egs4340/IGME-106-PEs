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
        private Vector2 imagePosition2;
        private float xPosition2 = 50;
        private float yPosition2 = 50;
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
            imagePosition2 = new Vector2(xPosition2, yPosition2);

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
            MoveImage();
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



            _spriteBatch.Draw(
                dog,
                imagePosition2,
                Color.Green);

            _spriteBatch.End();
            base.Draw(gameTime);

        }

        //move image method
        protected void MoveImage()
        {
            //checks if the image is moving up
            KeyboardState upState = Keyboard.GetState();
            if (upState.IsKeyDown(Keys.W))
            {
                imagePosition2 = new Vector2(xPosition2, yPosition2--);
            }

            //checks if the image is moving down
            KeyboardState downState = Keyboard.GetState();
            if (downState.IsKeyDown(Keys.S))
            {
                imagePosition2 = new Vector2(xPosition2, yPosition2++);
            }

            //checks if the image is moving left
            KeyboardState leftState = Keyboard.GetState();
            if (leftState.IsKeyDown(Keys.A))
            {
                imagePosition2 = new Vector2(xPosition2--, yPosition2);
            }

            //checks if the image is moving right
            KeyboardState rightState = Keyboard.GetState();
            if (rightState.IsKeyDown(Keys.D))
            {
                imagePosition2 = new Vector2(xPosition2++, yPosition2);
            }
        }


    }
}
