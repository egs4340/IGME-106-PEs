using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace SafkoE_Project4
{
    public enum GameState
    {
        Menu,
        Game,
        GameOver
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Player player;
        private Texture2D playerTexture;
        private List<Collectible> collectList;
        private Texture2D collectableTexture;
        private SpriteFont Arial;
        private int currentLvl = 0;
        private double timer;

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
            Player player = new Player();
            //collectList.Add(new Collectible);
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            playerTexture = Content.Load<Texture2D>("character_green_idle");
            collectableTexture = Content.Load<Texture2D>("coin_gold");
            Arial = Content.Load<SpriteFont>("Arial");
            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // FINITE STATE MACHINE GOES HERE!
            //3 States to switch between: Menu, Game, and Game Over

            

            base.Update(gameTime);
        }

        //code that resets the game
        private void ResetGame()
        {

        }


        //This method receives a parameter representing the key to check. Is this the first frame that key was
        //pressed? Is the key down in the current keyboard state and up in the previous keyboard state?
        //Return true if so and false otherwise.
        private bool SingleKeyPress(Keys key, KeyboardState currentState, KeyboardState previousState)
        {
            return false;
        }
        


        //method that changes to the next level
        private void Nextlevel()
        {
            if (currentLvl == 0)
            {

                currentLvl++;
                return;
            }

            if (currentLvl == 1)
            {
                currentLvl++;
            }

        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
