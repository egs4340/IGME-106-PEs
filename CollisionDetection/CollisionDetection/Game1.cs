using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;

namespace CollisionDetection
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // --------------------------------------------------------------------
        // Fields for the Collision PE
        // --------------------------------------------------------------------

        // Random object for use throughout class
        private Random randomGenerator;

        // Textures for Squares and Circles
        private Texture2D squareTexture;
        private Texture2D circleTexture;

        // Lists of all Squares and Circles
        private List<SquareEntity> squareList;
        private List<CircleEntity> circleList;

        // Player-controlled Square and Circle
        private SquareEntity playerSquare;
        private CircleEntity playerCircle;

        // Window size information
        private int windowWidth;
        private int windowHeight;

        //added a string for when the square is moving
        private string squareMovement;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // Get window size information
            windowWidth = GraphicsDevice.Viewport.Width;
            windowHeight = GraphicsDevice.Viewport.Height;

            // Instantiate Random for use throughout game.
            // Seeded to be consistent upon multiple plays of the game.
            randomGenerator = new Random(15);

            // Initialize list of Squares and Circles
            squareList = new List<SquareEntity>();
            circleList = new List<CircleEntity>();

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // --------------------------------------------------------------------
            // Load content for the PE
            // --------------------------------------------------------------------

            // Load the 2 textures for the game
            squareTexture = Content.Load<Texture2D>("square");
            circleTexture = Content.Load<Texture2D>("circle");


            // --------------------------------------------------------------------
            // Initialize values & objects dependent on loaded content
            // --------------------------------------------------------------------

            // Initialize ten randomly sized and positioned circles, squares, and rectangles.
            for (int i = 0; i < 5; i++)
            {
                // 3 squares
                if (i % 2 == 0)
                {
                    squareList.Add(
                        new SquareEntity(
                            squareTexture,
                            randomGenerator.Next(100, windowWidth - 100),
                            randomGenerator.Next(0, windowHeight - 100),
                            randomGenerator.Next(30, 100)));
                }
                else
                {
                    // 2 rectangles
                    squareList.Add(
                        new SquareEntity(
                            squareTexture,
                            randomGenerator.Next(100, windowWidth - 100),
                            randomGenerator.Next(0, windowHeight - 100),
                            randomGenerator.Next(30, 100),
                            randomGenerator.Next(30, 100)));
                }
                // 5 circles
                circleList.Add(
                    new CircleEntity(
                        circleTexture,
                        randomGenerator.Next(100, windowWidth - 100),
                        randomGenerator.Next(0, windowHeight - 100),
                        randomGenerator.Next(15, 50)));
            }

            // Get player-controlled units ready
            playerSquare = new SquareEntity(squareTexture, 0, 0, 100);
            playerCircle = new CircleEntity(circleTexture, 35, 120, 35);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // ************************************************************************************
            // TODO: Move the square using WASD and the circle using the mouse location
            // ************************************************************************************


            //If statements for changing the square movement to which key if being pressed down

            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                squareMovement = "Right";
            }
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                squareMovement = "Left";
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                squareMovement = "Down";
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                squareMovement = "Up";
            }
            //if (Keyboard.GetState().IsKeyDown(Keys.None))
            //{
            //    squareMovement = "Still";
            //}

            //Switch statement to move the square
            switch (squareMovement)

            {
                case "Left":
                    playerSquare.X--;
                    if (Keyboard.GetState().IsKeyUp(Keys.A))
                    {
                        playerSquare.X = playerSquare.X;
                    }
                    break;


                case "Right":
                    playerSquare.X++;
                    if (Keyboard.GetState().IsKeyUp(Keys.D))
                    {
                        playerSquare.X = playerSquare.X;
                    }
                    break;


                case "Down":
                    playerSquare.Y++;
                    if (Keyboard.GetState().IsKeyUp(Keys.S))
                    {
                        playerSquare.Y = playerSquare.Y;
                    }
                    break;


                case "Up":
                    playerSquare.Y--;
                    if (Keyboard.GetState().IsKeyUp(Keys.W))
                    {
                        playerSquare.Y = playerSquare.Y;
                    }
                    break;
            }

            base.Update(gameTime);
        }


        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            // ************************************************************************************
            // TODO: Draw all shapes in their appropriate color. 
            // Are any of the game objects intersecting with the player square or the player circle?
            // If so, draw both the Player and that intersecting shape in red.
            // If not, draw the shape in white.
            // If there are no intersections with any shapes, draw the player yellow.
            //
            // Right now, this code exists so that we can visualize everything on the screen.
            //   (Though since the Circle's Rectangles are (0, 0, 0, 0) we don't see any circles yet...)
            //
            // It's up to YOU to determine the logic for how to detect collisions and draw each shape
            //   with appropriate colors...  You may need to alter or combine for loops, use different loop
            //   types, add extra variables, etc.  There's no single way to do this!
            // You may alter the code below in ANY way you need to!!!
            // ************************************************************************************


            


            for (int i = 0; i < squareList.Count; i++)
            {
                squareList[i].Draw(_spriteBatch, Color.White);
            }

            for (int i = 0; i < circleList.Count; i++)
            {
                circleList[i].Draw(_spriteBatch, Color.White);
            }

            playerSquare.Draw(_spriteBatch, Color.Yellow);
            playerCircle.Draw(_spriteBatch, Color.Yellow);



            //bool squareOverlap = playerSquare.IntersectsWith(squareList[1]);

            bool squareAABBOverlap = playerSquare.AABBCollision(squareList[1]);

            bool circleOverlap = playerCircle.IntersectsWith(playerSquare);

            //if (squareOverlap)
            //{
            //    _spriteBatch.Draw(squareTexture, playerSquare.SquareRect, Color.White);
            //}
            //else
            //{
            //    _spriteBatch.Draw(squareTexture, playerSquare.SquareRect, Color.DarkGoldenrod);
            //}



            if (squareAABBOverlap)
            {
                _spriteBatch.Draw(squareTexture, playerSquare.SquareRect, Color.White);
            }

            else
            {
                _spriteBatch.Draw(squareTexture, playerSquare.SquareRect, Color.DarkGoldenrod);
            }




                _spriteBatch.End();

            base.Draw(gameTime);
        }
    }

}
