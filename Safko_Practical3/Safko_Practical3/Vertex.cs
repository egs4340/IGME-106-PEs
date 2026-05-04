using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Safko_Practical3
{
    // ---------------------------------------------------------------------------
    // DO NOT EDIT THIS CLASS!
    // ---------------------------------------------------------------------------

    /// <summary>
    /// Vertex class represents a single Vertex in a 2D array (grid/graph) of tiles (Vertices)
    /// </summary>
    public class Vertex
    {
        // Fields
        private int x;
        private int y;
        private Tile data;
        private bool visited;

        // Properties
        public int X { get { return x; } set { x = value; } }
        public int Y { get { return y; } set { y = value; } }
        public Tile Data { get { return data; } set { data = value; } }
        public bool Visited { get { return visited; } set { visited = value; } }

        // Constructor
        public Vertex(int x, int y, Tile data)
        {
            this.x = x;
            this.y = y;
            this.data = data;
            this.visited = false;
        }
    }

}
