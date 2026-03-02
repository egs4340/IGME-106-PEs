using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace CollisionDetection
{
    /// <summary>
    /// CircleEntity represents any circular object in the game.
    /// Defined by a center and a radius.
    /// </summary>
    public class CircleEntity
    {
        // Fields
        private Texture2D texture;
        private Vector2 center;
        private int radius;

        /// <summary>
        /// Center point of this Circle
        /// </summary>
        public Vector2 Center
        {
            get { return center; }
        }

        /// <summary>
        /// Radius of this Circle
        /// </summary>
        public int Radius
        {
            get { return radius; }
        }

        /// <summary>
        /// Retrieve and/or change the X component of this circle's center
        /// </summary>
        public float X
        {
            get { return center.X; }
            set { center.X = value; }
        }

        /// <summary>
        /// Retrieve and/or change the Y component of this circle's center
        /// </summary>
        public float Y
        {
            get { return center.Y; }
            set { center.Y = value; }
        }

        /// <summary>
        /// Instantiates a CircleEntity
        /// </summary>
        /// <param name="texture">Image to use when rendering</param>
        /// <param name="x">X position of this circle's center</param>
        /// <param name="y">Y position of this circle's center</param>
        /// <param name="radius">Radius of this circle</param>
        public CircleEntity(Texture2D texture, int x, int y, int radius)
        {
            this.texture = texture;
            this.radius = radius;
            this.center = new Vector2(x, y);
        }


        // ************************************************************************************
        // TODO: Write the IntersectsWith method to implement circle-circle collision detection
        // ************************************************************************************

        public bool IntersectsWith()
        {
            return false;
        }

        // ************************************************************************************
        // TODO: Write the IntersectsWith overload to implement circle-rectangle collision detection
        // ************************************************************************************

        public bool IntersectsWith(SquareEntity squareEntity)
        {
            return false;
        }

        /// <summary>
        /// Draws this CircleEntity to the game window.
        /// </summary>
        /// <param name="spriteBatch">Reference to the SpriteBatch object in Game1.</param>
        /// <param name="tint">The color of this game object.</param>
        public void Draw(SpriteBatch spriteBatch, Color tint)
        {
            // ------------------------------------------------------------------------------------
            // Since a Circle is defined by a center location and a radius, why is a Rectangle needed?
            // Because the Draw method utilizes Rectangles!
            // Draw needs to know which image to render to the game window (a Texture2D), and needs to know
            //   where the object should be drawn and its  proper scale.
            //   A Rectangle handles both of those requirements.
            //
            // So why isn't the Rectangle a field of the class like it is in SquareEntity?
            // We *could* make this a field of the class, but we'd need to update its position every
            //   frame that the circle's center changes position. Instead, another option is to quickly
            //   calculate the bounds of this Rectangle every frame it's drawn based on the circle's
            //   current center and radius.
            // (What do I mean by 'quickly calculate'? Structs are fast to access, fast to instantiate,
            //   and fast to remove from the stack when they are out of scope. For this PE's 6 Circles,
            //   this is not a big deal and not computationally expensive... However, if you had MANY
            //   circles in your game I would recommend making those circles' Rectangles a field of this 
            //   class and updating their Rectangles' X, Y, width, and/or height values when necessary.)
            // ------------------------------------------------------------------------------------

            // ************************************************************************************
            // TODO: Use the correct coordinates, width, and height to represent this circle's rectangular bounds.
            // (0, 0, 0, 0) is a placeholder. These are NOT the correct values.
            // ************************************************************************************

            Rectangle circleRect = new Rectangle((int)center.X, (int)center.Y, 50, 50);



            // ************************************************************************************
            // TODO: Use the DebugLib class to draw a rectangle outline around the circleRect.
            // This is helpful while debugging to ensure that the circle's center coordinates
            //   and Rectangle coordinates & size are accurate!
            // ************************************************************************************



            // Draw this circle to the game window.
            spriteBatch.Draw(texture, circleRect, tint);
        }
    }
}
