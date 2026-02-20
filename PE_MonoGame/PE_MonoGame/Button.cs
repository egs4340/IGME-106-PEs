using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PE_MonoGame
{
    //added the public class Button with the ability to access the Game1 class
    public class Button : Game1
    {
        private int X;
        private int Y;

        //public constructor for the button
        public Button()
        {
            this.X = 0;
            this.Y = 0;
        }

        //added the ability to use the Game1 class' Update Method
        public void Update()
        {

        }

        //added the ability to use the Game1 class' Draw method
        public void Draw(SpriteBatch _spriteBatch)
        { 
            _spriteBatch.Begin();
            _spriteBatch.Draw(
                dog,
                new Rectangle(20, 0, 20, 10),
                Color.Azure
                );
        }
    }
}
