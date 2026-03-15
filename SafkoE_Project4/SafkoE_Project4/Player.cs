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
        int levelScore;
        int totalScore;
        int windowWidth = 200;
        int windowHeight = 100;
        private Texture2D texture;

        //player constructor
        public Player()
        {
           texture = Content.Load<Texture2D>("character_green_idle");
            totalScore = 0;
            levelScore = 0;
        }

        //method for updating
        public override void Update(GameTime gt)
        {
            
        }

        //method for resetting the player's location to the center of the window
        public void Center()
        {

        }
    }
}
