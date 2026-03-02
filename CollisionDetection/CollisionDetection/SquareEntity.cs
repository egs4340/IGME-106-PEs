using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;

namespace CollisionDetection
{
        /// <summary>
        /// SquareEntity represents any square object in the game.
        /// Defined by an (X,Y) and a side length.
        /// </summary>
        public class SquareEntity
        {
            // Fields
            private Texture2D texture;
            private Rectangle squareRect;

            /// <summary>
            /// Reference to the bounds of this object. Cannot be changed.
            /// </summary>
            public Rectangle SquareRect
            {
                get { return squareRect; }
            }

            /// <summary>
            /// X position of the upper-left corner of the SquareEntity
            /// </summary>
            public int X
            {
                get { return squareRect.X; }
                set { squareRect.X = value; }
            }

            /// <summary>
            /// Y position of the upper-left corner of the SquareEntity
            /// </summary>
            public int Y
            {
                get { return squareRect.Y; }
                set { squareRect.Y = value; }
            }

            /// <summary>
            /// Instantiates a square-shaped SquareEntity.
            /// </summary>
            /// <param name="texture">Image to use when rendered</param>
            /// <param name="x">X position of the upper-left corner</param>
            /// <param name="y">Y position of the upper-left corner</param>
            /// <param name="size">Size of the Square</param>
            public SquareEntity(Texture2D texture, int x, int y, int size)
            {
                this.texture = texture;
                this.squareRect = new Rectangle(x, y, size, size);
            }

            /// <summary>
            /// Instantiates a rectangular-shaped SquareEntity
            /// </summary>
            /// <param name="texture">Image to use when rendered</param>
            /// <param name="x">X position of the upper-left corner</param>
            /// <param name="y">Y position of the upper-left corner</param>
            /// <param name="width">Width of the rectangle (in pixels)</param>
            /// <param name="height">Height of the rectangle (in pixels)</param>
            public SquareEntity(Texture2D texture, int x, int y, int width, int height)
            {
                this.texture = texture;
                this.squareRect = new Rectangle(x, y, width, height);
            }


            // ************************************************************************************
            // TODO: Write the IntersectsWith method
            // ************************************************************************************
           
            
            public bool IntersectsWith(SquareEntity otherSquare)
            {
                if (this.SquareRect.Left > otherSquare.SquareRect.Right && this.SquareRect.Right < otherSquare.SquareRect.Left
                || this.SquareRect.Bottom < otherSquare.SquareRect.Top && this.SquareRect.Top > otherSquare.SquareRect.Bottom)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            public bool AABBCollision(SquareEntity squareEntity)
            {
                var ToTheRightOf = this.SquareRect.Left > squareEntity.SquareRect.Right;
                var ToTheLeftOf = this.SquareRect.Right < squareEntity.SquareRect.Left;
                var AboveOf = this.SquareRect.Bottom < squareEntity.SquareRect.Top;
                var BelowOf = this.SquareRect.Top > squareEntity.SquareRect.Bottom;
                return !(ToTheRightOf || ToTheLeftOf || AboveOf || BelowOf);
            }


            /// <summary>
            /// Draws this SquareEntity to the game window.
            /// </summary>
            /// <param name="sb">Reference to the SpriteBatch object in Game1.</param>
            /// <param name="tint">The color of this game object.</param>
            public void Draw(SpriteBatch sb, Color tint)
            {
                sb.Draw(texture, squareRect, tint);

                // ************************************************************************************
                // TODO: Use the DebugLib class to draw a rectangle outline around the squareRect.
                // This is helpful while debugging!
                // ************************************************************************************

                DebugLib.DrawRectOutline(sb, squareRect, 2, Color.DarkRed);
            }
        }

    
}
