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
    internal abstract class GameObject
    {
        //protected Texture2D ;
        //protected Vector2 position;

        //gameobject constructor
        protected GameObject() 
        {

            
        }

        //void draw method
        public virtual void Draw(SpriteBatch sb)
        {
            
        }

        //void update method
        public abstract void Update(GameTime gt);





        
    }
}
