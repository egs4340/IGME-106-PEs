using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
namespace CrossPlatTestDemo
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D dog;
        private Texture2D whitebox;
        private Rectangle userControlledRect;
        private int screenWidth;
        private int screenHeight;
        private int xPosition;
        private float radians;
        private SpriteFont Arial;
        private int Y;
        private int X;



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
            userControlledRect.X = 0;
            userControlledRect.Y = 0;
            base.Initialize();
            radians = 1;

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            dog = Content.Load<Texture2D>("dog");
            whitebox = Content.Load<Texture2D>("WhiteBackground");
            Arial = Content.Load<SpriteFont>("Arial");
            userControlledRect = new Rectangle(X, Y, 20, 20);
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();


            xPosition += 3;

            if(xPosition > screenWidth)
                xPosition = -dog.Width;
            // TODO: Add your update logic here

            radians += 0.05f;
            if(radians> 6.20f)
            {
                radians = 0;
            }

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
                whitebox,                                                                                         //Texture2D
                new Rectangle(screenWidth/2, screenHeight/2, screenWidth/2, screenHeight/2),                      //Location upper left corner
                Color.Blue);                                                                                      //color tint

            //Rectangle line = new Rectangle();
            //if (vertical)
            //{
            //    line = new Rectangle(startingPosition, startingYPosition, 5, Math.Abs((endingPosition)));
            //}

            _spriteBatch.Draw(
                dog,
                new Rectangle(0, 0, dog.Width, dog.Height),
                null,
                Color.Yellow,
                radians,
                new Vector2(dog.Width / 2, dog.Height / 2),
                SpriteEffects.None,
                1f
                );

            _spriteBatch.Draw(
                dog,
                userControlledRect,
                Color.Black
                );


            _spriteBatch.DrawString(
                Arial,
                Math.Round(radians, 1).ToString(),
                new Vector2(0, 0),
                Color.Aquamarine);

            _spriteBatch.End();


            base.Draw(gameTime);
        }

        public void MoveImage()
        {

            KeyboardState currentKBState = Keyboard.GetState();
            if (currentKBState.IsKeyDown(Keys.W))
            {
                userControlledRect.Y -= 1;
            }

            if (currentKBState.IsKeyDown(Keys.S))
            {
                userControlledRect.Y += 1;
            }

            if (currentKBState.IsKeyDown(Keys.A))
            {
                userControlledRect.X -= 1;
            }

            if (currentKBState.IsKeyDown(Keys.D))
            {
                userControlledRect.X += 1;
            }
        }
    }
}
