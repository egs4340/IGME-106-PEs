using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PE_FiniteStateMachines
{
    public class Game1 : Game
    {
        // ************************************************
        // * Remove ALL CODE inside of your Game1 class.  *
        // * Replace it with the code below.              *
        // ************************************************


        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // Mario texture fields
        private Texture2D marioTexture;
        private Vector2 marioPosition;

        // Sprite sheet data
        private int numSpritesInSheet;
        private int widthOfSingleSprite;

        // Animation data
        private int mariosCurrentFrame;
        private double fps;
        private double secondsPerFrame;
        private double timeCounter;

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

            // Load the sprite sheet and fill in sprite data
            marioTexture = Content.Load<Texture2D>("MarioSpriteSheet");
            numSpritesInSheet = 4;
            widthOfSingleSprite = marioTexture.Width / numSpritesInSheet;

            // Start Mario at (200, 200) in the game window
            marioPosition = new Vector2(200, 200);

            // Set up animation data:
            fps = 8.0;                      // Speed of animation
            secondsPerFrame = 1.0 / fps;    // Time to render each animation frame
            timeCounter = 0;                // Time counter per animation frame
            mariosCurrentFrame = 1;         // Sprite sheet's first animation frame is 1 (not 0)
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed ||
                Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // ********************************************************
            // *** EXERCISE:
            // *** Put code here to check and update your Finite State Machine
            // *** to properly change mario's state and make him move!
            // ********************************************************

            // Always update Mario's animation
            UpdateAnimation(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            // ********************************************************
            // *** EXERCISE:

            // *** Put your debug text here


            // *** Put code here to check your Finite State Machine
            // *** and properly draw mario based on his state


            // *** EXAMPLE HELPER METHOD CALLS:
            // *** Call these to draw mario in different ways:
            DrawMarioWalking(SpriteEffects.FlipHorizontally);
            //DrawMarioWalking(SpriteEffects.FlipHorizontally);
            //DrawMarioStanding(SpriteEffects.None);
            // ********************************************************

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        /// <summary>
        /// Helper for updating Mario's animation based on time
        /// </summary>
        /// <param name="gameTime">Info about time from MonoGame</param>
        private void UpdateAnimation(GameTime gameTime)
        {
            // ElapsedGameTime is the duration of the last GAME frame
            timeCounter += gameTime.ElapsedGameTime.TotalSeconds;

            // Time to go to the next animation frame
            if (timeCounter >= secondsPerFrame)
            {
                // Change the active animation frame
                mariosCurrentFrame++;
                if (mariosCurrentFrame >= 4)
                {
                    mariosCurrentFrame = 1;
                }

                // Reset the time counter
                timeCounter -= secondsPerFrame;
            }
        }

        /// <summary>
        /// Draws Mario with a walking animation.
        /// </summary>
        /// <param name="flip">Should he be flipped horizontally or vertically?</param>
        private void DrawMarioWalking(SpriteEffects flip)
        {
            // This version of draw can flip (mirror) the image horizontally or vertically,
            // depending on the method's SpriteEffects parameter.

            // Mario is animated with this method.
            // He is drawn starting at the second animation frame in the sprite sheet 
            //   and cycles through animation frames 1, 2, and 3.
            //   (i.e. the second through fourth images in the sheet)
            _spriteBatch.Draw(
                marioTexture,                                   // Whole sprite sheet
                marioPosition,                                  // Position of the Mario sprite
                new Rectangle(                                  // Which portion of the sheet is drawn:
                    mariosCurrentFrame * widthOfSingleSprite,   // - Left edge
                    0,                                          // - Top of sprite sheet
                    widthOfSingleSprite,                        // - Width 
                    marioTexture.Height),                       // - Height
                Color.White,                                    // No change in color
                0.0f,                                           // No rotation
                Vector2.Zero,                                   // Start origin at (0, 0) of sprite sheet 
                1.0f,                                           // Scale
                flip,                                           // Flip it horizontally or vertically?    
                0.0f);                                          // Layer depth
        }

        /// <summary>
        /// Draws Mario in a standing position.  Mario is not animated.
        /// </summary>
        /// <param name="flip">Should he be flipped horizontally or vertically?</param>
        private void DrawMarioStanding(SpriteEffects flip)
        {
            // This version of draw can flip (mirror) the image horizontally or vertically,
            // depending on the method's SpriteEffects parameter.

            // Mario is not animated with this method.
            // He is drawn using the first animation frame in the sprite sheet 
            //   (i.e. the first image in the sheet)
            _spriteBatch.Draw(
                marioTexture,                                   // Whole sprite sheet
                marioPosition,                                  // Position of the Mario sprite
                new Rectangle(                                  // Which portion of the sheet is drawn:
                    0,                                          // - Left edge
                    0,                                          // - Top of sprite sheet
                    widthOfSingleSprite,                        // - Width 
                    marioTexture.Height),                       // - Height
                Color.White,                                    // No change in color
                0.0f,                                           // No rotation
                Vector2.Zero,                                   // Start origin at (0, 0) of sprite sheet 
                1.0f,                                           // Scale
                flip,                                           // Flip it horizontally or vertically?    
                0.0f);                                          // Layer depth
        }
    }
}