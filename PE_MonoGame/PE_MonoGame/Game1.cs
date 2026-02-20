using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PE_MonoGame
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //adds our 'main' Texture2D
        private Texture2D dog;
        private Texture2D button;
        //Added a Vector2 to set the image position for objects
        private Vector2 imagePosition;

        //Floats for the image position
        private float xPosition = 50;
        private float yPosition = 50;

        //Added a Vector2 for the second image position, for the moving object
        private Vector2 imagePosition2;
        
        //Floats for the second image position, used for the moving image
        private float xPosition2 = 50;
        private float yPosition2 = 50;
        
        //Added the SpriteFont
        private SpriteFont Arial;

        //added the button as a private field
        private Button myButtonObject;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            //Added the new button Object
            myButtonObject = new Button();

            //initializes a new vector for the image position
            imagePosition = new Vector2(xPosition, yPosition);

            //initializes a new vector for the movable image's position
            imagePosition2 = new Vector2(xPosition2, yPosition2);


            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            //loads the dog texture
            dog = Content.Load<Texture2D>("dog");
            Arial = Content.Load<SpriteFont>("Arial");
            button = Content.Load<Texture2D>("Button");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            //updates the imagePosition to make the image move
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


            //draws another dog (which can move from the player's input!)
            _spriteBatch.Draw(
                dog,
                imagePosition2,
                Color.Green);

            //Text WIP
            _spriteBatch.DrawString(
                Arial,
                "This is Test Text",
                new Vector2(0, 0),
                Color.Aquamarine
                );

            _spriteBatch.Draw(
                button,
                new Button(),
                Color.Olive
                );
                
            

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
