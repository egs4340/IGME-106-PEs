using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace SafkoE_Proj5
{
	class QuadTreeNode
	{
		// The maximum number of objects in a quad
		// BEFORE a subdivision occurs.  In other words,
		// once this node has MORE than this many objects,
		// it should divide.
		private const int MaxObjectsBeforeSubdivide = 3;

		/// <summary>
		/// The 4 divisions of this quad
		/// </summary>
		public QuadTreeNode[] Divisions { get; private set; }

		/// <summary>
		/// This quad's rectangular bounded area
		/// </summary>
		public Rectangle Bounds { get; private set; }

		/// <summary>
		/// The game objects (colored rectangles) inside this quad
		/// </summary>
		public List<GameObject> GameObjects { get; private set; }

		/// <summary>
		/// Creates a new Quad Tree Node
		/// </summary>
		/// <param name="x">This quad's x position</param>
		/// <param name="y">This quad's y position</param>
		/// <param name="width">This quad's width</param>
		/// <param name="height">This quad's height</param>
		public QuadTreeNode(int x, int y, int width, int height)
		{
			// Save the rectangle
			Bounds = new Rectangle(x, y, width, height);

			// Create the object list
			GameObjects = new List<GameObject>();

			// No divisions yet
			Divisions = null;
		}


		/// <summary>
		/// Adds a game object to the best fitting quad's list of GameObjects.  
		/// If the quad has too many objects in its GameObjects list, and hasn't
		/// been divided already, it divides into four children.
		/// </summary>
		/// <param name="gameObj">The object to add</param>
		public bool AddObject(GameObject gameObj)
		{
            // ----------------------------------------------------------
            // TODO: Complete this recursive AddObject method
            // ----------------------------------------------------------
			
			//The GameObject's ability to add to the list
			if (GameObjects.Count < 4)
			{
				GameObjects.Add(gameObj);
			}


			// You MAY modify this statement.
            return false;
		}

		/// <summary>
		/// Divides this quad into 4 smaller quads.  Moves any game objects
		/// that are completely contained within the new smaller quads into
		/// those quads and removes them from this one.
		/// </summary>
		public void Divide()
		{
			// ----------------------------------------------------------
			// TODO: Complete this Divide method
			// ----------------------------------------------------------
			//the divisions method wouldn't work
			if (GameObjects.Count > MaxObjectsBeforeSubdivide)
			{

				//GameObjects[Divisions];
			}

        }

        /// <summary>
        /// Recursively populates a list with all of the bounding rectangles
        /// in the tree.  This include the bounding rectangle for this quad and 
        /// all child quads (if they exist).  Use the "AddRange" method of
        /// the list class to add the elements from one list to another.
        /// </summary>
        /// <returns>A list of rectangles representing all of the quads in the tree</returns>
        public List<Rectangle> GetAllQuadBounds()
		{
			// DO NOT MODIFY THIS STATEMENT:
			List<Rectangle> rects = new List<Rectangle>();

			// ----------------------------------------------------------
			// TODO: Complete the rest of this recursive GetAllQuadBounds in here

			//Unable to get this to work without crashing the program, but here is the code


			//rects.AddRange(rects);

			//if (rects.Count > 4)
			//{
			//	//Divide();
			//	return rects;
			//}
            // ----------------------------------------------------------

            // DO NOT MODIFY THIS STATEMENT:
            return rects;
		}

		/// <summary>
		/// A possibly recursive method that returns the
		/// smallest quad that contains the specified rectangle
		/// </summary>
		/// <param name="gameObjectRect">A GameObject's rectangle to check</param>
		/// <returns>The smallest quad that contains the rectangle</returns>
		public QuadTreeNode GetSmallestContainingQuad(Rectangle gameObjectRect)
		{
            // ----------------------------------------------------------
            // TODO: Complete this recursive GetSmallestContainingQuad method
            // ----------------------------------------------------------

			//much of this code also caused problem that just completely stopped the program from being able to run
			//if (gameObjectRect.IsEmpty)
			//{
			//	//return null;
			//}

			//if (GetAllQuadBounds().Contains(gameObjectRect))
			//{
   //             //return null;
			//}

			//if (Bounds.Contains(gameObjectRect))

			//{
			//	GetSmallestContainingQuad(gameObjectRect);
			//}



            // You MAY modify this statement.
            return null;
		}
	}
}
