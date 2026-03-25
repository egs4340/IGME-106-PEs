using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.Marshalling;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SafkoE_Project4
{
    internal class Player : GameObject
    {
        internal int levelScore;
        internal int totalScore;
        internal int windowWidth = 200;
        internal int windowHeight = 100;
        private Texture2D texture;


        //player constructor
        public Player()
        {
           totalScore = 0;
           levelScore = 0;
           position.X = windowWidth/2;
           position.Y = windowHeight/2;
        }

        //method for updating, includes the player's movement
        public override void Update(GameTime gt)
        {
            KeyboardState kbState = Keyboard.GetState();

            if (kbState.IsKeyDown(Keys.A))
            {
                position.X -= 1;
            }

            if (kbState.IsKeyDown(Keys.D))
            {
                position.X += 1;
            }

            if (kbState.IsKeyDown(Keys.S))
            {
                position.Y += 1;
            }

            if (kbState.IsKeyDown(Keys.W))
            {
                position.Y -= 1;
            }



        }

        //method for resetting the player's location to the center of the window
        public void Center()
        {
            position.X = windowWidth / 2;
            position.Y = windowHeight/2;
        }

        public void Draw(SpriteBatch sb)
        {
            sb.Draw(texture, new Vector2(2, 2), Microsoft.Xna.Framework.Color.Green);
        }
    }
}
