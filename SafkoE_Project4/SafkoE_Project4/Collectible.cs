using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SafkoE_Project4
{
    internal class Collectible : GameObject
    {
        private Texture2D texture;
        private Rectangle pos;
        //collectible constructor
        public Collectible()
        {
            texture = Content.Load<Texture2D>("coin_gold");
        }



        //void update method
        public override void Update(GameTime gt)
        {

        }

        //boolean method for checking collision
        public bool CheckCollision(GameObject otherObject)
        {
            if (Intersects(otherObject))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //intersects method
        private bool Intersects(GameObject otherObject)
        {
            if (this.position.Left > otherObject.pos.Right && this.position.Right < otherObject.pos.Left
                || this.position.Bottom < otherObject.pos.Top && this.position.Top > otherObject.pos.Bottom)
            {
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
