using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace PE_Events
{
    public class Game1 : Game
    {
        // *********************************************************
        // TODO: A D D    Y O U R    N A M E    H E R E

        //         Evan Safko

        // TODO: P U T    T H E    D A T E    H E R E
        
        //         3/25/26 - 3/27/26
        
        // *********************************************************
        // PE:  Button Class for Events and Delegates
        // Project starter code written by Erika Mesh/Erin Cascioli




        // Fields created by the MG template
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // The list of buttons along with setup for setting a random background color
        private SpriteFont font;
        private List<Button> buttons;
        private Color bgColor;
        private Random rng;
        private Texture2D texture;

        // ********************************************************************
        // TODO: Add any new fields you need here!
        // ********************************************************************

        private int CountClick;
        
        //attempt to add random floats for the Vector2 to randomly select where the sprite goes

        //private float randX = Random(0, 400);

        //private double randY = Random(0, 400);


        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }


        protected override void Initialize()
        {
            // Initialize objects
            buttons = new List<Button>();
            bgColor = Color.DimGray;
            rng = new Random();

            // ****************************************************************
            // TODO: Initialize any new fields you need here!
            // ****************************************************************
            
            

            //randX = new Random(0, 400);
            
            //randY = new Random(0, 400);

            base.Initialize();
        }


        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load in the button's font
            font = Content.Load<SpriteFont>("buttonFont");

            // Create 3 200 x 100 buttons down the left side of game window
            Button changeBackgroundButton =
                new Button(
                    _graphics.GraphicsDevice,           // device reference
                    new Rectangle(10, 40, 200, 100),    // position and size of button
                    "Random BG",                        // button label
                    font,                               // label font
                    Color.Black);                       // button color

            Button addSomethingButton =
                new Button(
                    _graphics.GraphicsDevice,
                    new Rectangle(10, 160, 200, 100),
                    "Add",
                    font,
                    Color.AliceBlue);

            Button removeSomethingButton =
                new Button(
                    _graphics.GraphicsDevice,
                    new Rectangle(10, 280, 200, 100),
                    "Remove",
                    font,
                    Color.DarkSeaGreen);

            // Add them, in order, to the Button list.
            buttons.Add(changeBackgroundButton);
            buttons.Add(addSomethingButton);
            buttons.Add(removeSomethingButton);

            // ****************************************************************
            // TODO: Load your sprite
            // ****************************************************************

            texture = Content.Load<Texture2D>("NewSprite");

            // ****************************************************************
            // TODO: Subscribe methods to the buttons' event
            // ****************************************************************

            buttons[0].OnLeftButtonClick += this.RandomizeBackground;
            buttons[0].OnLeftButtonClick += this.CountLeftButtonClicks;

            buttons[0].OnRightButtonClick += this.RandomizeBackground;
            buttons[0].OnRightButtonClick += this.CountLeftButtonClicks;

            //buttons[1].OnLeftButtonClick +=

            //buttons[2].OnLeftButtonClick += this.

        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Update each Button (which internally checks if the Button has been clicked.)  
            // If it has been clicked, an action will occur.
            // This action is defined in the Button class.
            foreach (Button button in buttons)
            {
                button.Update();
            }

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            // Clears to gray
            GraphicsDevice.Clear(bgColor);

            // Begin the SpriteBatch
            _spriteBatch.Begin();

            // ****************************************************************
            // TODO: Any drawing code needed to complete the PE tasks can be put here.
            // ****************************************************************


            //tried to add the spritebatch to be able to draw the sprite randomly, I have no idea how to get the
            //Vector 2's to accept the random numbers even though I tried making them floats or doubles

            //_spriteBatch.Draw(
            //      texture,
            //      new Vector2(Random(0, 200), Random rand(0, 200)),
            //      Color.Red
            //      );


            // Draw all buttons in the foreground and layered
            //   "on top" of any other entities in the game.
            foreach (Button button in buttons)
            {
                button.Draw(_spriteBatch);
            }

            
            
            
            //foreach (int var in CountClick)
            //{
            _spriteBatch.DrawString(
                font,
                ($"Current Clicks: {CountClick.ToString()}"),
                new Vector2(250, 50),
                Color.Black
                );
           // }




            // End the SpriteBatch
            _spriteBatch.End();

            // Parent (Game) call to Draw
            base.Draw(gameTime);
        }


        /// <summary>
        /// Method that changes the background color of the game window.
        /// </summary>
        public void RandomizeBackground()
        {
            // Set the background color variable to a random color
            bgColor = new Color(rng.Next(0, 256), rng.Next(0, 256), rng.Next(0, 256));
        }


        // ********************************************************************
        // TODO: Add any new methods for completing your PE tasks here.
        // ********************************************************************

        //adds count to the number
        public void CountLeftButtonClicks()
        {
            CountClick++;
        }

        //adds count to the number (should probably have seperated it from the left button click count)
        public void CountRightButtonClicks()
        {
            CountClick++;
        }


    }
}
