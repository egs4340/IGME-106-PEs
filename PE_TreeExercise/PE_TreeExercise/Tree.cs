using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_TreeExercise
{
        /// <summary>
        /// Represents a tree-centric data structure
        /// that can have data dynamically inserted, 
        /// and can be drawn as a literal "tree" on the screen
        /// </summary>
        class Tree : DrawableTree
        {
            // Already has an inherited root node field called "root"

            /// <summary>
            /// Creates a tree that can be drawn
            /// </summary>
            /// <param name="sb">The sprite batch used to draw</param>
            /// <param name="treeColor">The color of this tree</param>
            public Tree(SpriteBatch sb, Color treeColor)
                : base(sb, treeColor)
            { }

            /// <summary>
            /// Public facing Add method
            /// </summary>
            /// <param name="data">The data to add</param>
            public void Add(int data)
            {
                // *** Fill in this method *************************************


                // *************************************************************
            }

            /// <summary>
            /// Private recursive Add method
            /// </summary>
            /// <param name="data">The data to add</param>
            /// <param name="node">The node to attempt to add into</param>
            private void Add(int data, TreeNode node)
            {
                // *** Fill in this method *************************************


                // *************************************************************
            
            }
        }
}
