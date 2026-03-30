using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace Safko_Practical2
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        //All of the fields I'll be using
        //Texture 2Ds for the star sprites
        private Texture2D yellowStar;
        private Texture2D greenStar;

        //sprite font for the instruction text and displaying the number of stars
        private SpriteFont impact;
        
        //an int for all of the stars
        private List<int> starList;

        //mouse states for the previous and current mouse state
        private MouseState prevMouseState;
        private MouseState currentMouseState;

        //an int for the count of the stars in our game
        private int starCount;
        
        //a button state for being able to access the button state
        private ButtonState buttonState;
        
        //an int for the mouse's X position
        private int mousePosX;
        
        //an int for the mouse's Y position
        private int mousePosY;
        
        //Vector2 scale3 = new Vector2(40, 40);
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
            yellowStar = Content.Load<Texture2D>("yellow_star");
            greenStar = Content.Load<Texture2D>("green_star");
            impact = Content.Load<SpriteFont>("Impact");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            //sets the mouse state to a variable
            MouseState mouseState = Mouse.GetState();

            //creates a new list for all of the stars we'll be making!
            starList = new List<int>();

            //Sets the Mouse's X position for placing stars
            mousePosX = mouseState.X;

            //sets the mouse's Y position for placing stars
            mousePosY = mouseState.Y;

            //sets the current mouse state to the mouse state
            currentMouseState = mouseState;


            //the following code is my attempt to make sense of/utilize the mouse state that we've been working with. unfortunately i couldn't get it to work, and since the entire assignment is riding on this working,
            //i really have to apologize for just having this all be a waste of your time.


            if (currentMouseState.LeftButton == ButtonState.Pressed || currentMouseState.RightButton == ButtonState.Pressed)
            {
                mouseState.Equals(ButtonState.Released);
                //currentMouseState.LeftButton = ButtonState.Pressed;
            }

            if (prevMouseState == currentMouseState)
            {
                mouseState.Equals(ButtonState.Released);
            }

            if (mouseState.LeftButton.Equals(ButtonState.Released))
            {
                starList.Add(1);
                starCount++;
                currentMouseState = mouseState;
            }


            //If the Star List is above 10, remove the last star
            if (starList.Count > 10)
            {
                starCount--;
                starList.RemoveAt(0);
            }

            //if the star count is above 10, stop it from going higher
            if (starCount > 10)
            {
                starCount--;
            }


            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.AntiqueWhite);

            // TODO: Add your drawing code here

            //(float, float) scale;
            _spriteBatch.Begin();

            //DrawString for the instruction text
            _spriteBatch.DrawString(
                impact,
                "Left Click to place stars, Right Click to remove stars!",
                new Vector2(0, 0),
                Color.Black);

            //draw string for the number of stars on screen
            _spriteBatch.DrawString(
                impact,
                ($"Current no. of stars: {starCount}"),
                new Vector2(0, 20),
                Color.Black);

            //Drawing the initial star
            _spriteBatch.Draw(
                yellowStar,
                new Rectangle(350, 175, 100, 100),
                Color.Black);


            //Adds a new star for each star listed in the star list
            foreach (int i in starList)
            {
                _spriteBatch.Draw(
                    yellowStar,
                    new Rectangle(mousePosX, mousePosY, 100, 100),
                    Color.Yellow);
            }

            //Checks the mouse's current state and adds to the star list and star count accordingly
            if(currentMouseState.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed)
            {
                starList.Add(1);
                starCount++;
            }


            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
