using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace SafkoE_Project4
{
    internal abstract class GameObject : Game1
    {
        protected Texture2D sprite;
        protected Rectangle position;

        //gameobject constructor
        protected GameObject() 
        {
            this.position = new Rectangle();
        }

        //Rectangle position for using the pos for other objects created
        internal Rectangle pos
        {
            get { return this.position; }
            set { this.position = value; }
        }

        //void draw method
        public virtual void Draw(SpriteBatch sb)
        {
            sb.Draw(
                sprite,
                position,
                Color.AliceBlue
                );
        }

        //void update method
        public abstract void Update(GameTime gt);
        
    }
}
