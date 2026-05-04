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
    // ************************************************************************
    // ---------------------------------------------------------------------------
    // 4 possible Maze Tile values 
    // ---------------------------------------------------------------------------
    public enum Tile
    {
        Empty,
        Wall,
        Start,
        End
    }

    /// <summary>
    /// Maze contains a 2D array (grid) of tiles (Vertex objects).
    /// Does not use any adjacency structures, as they are not needed - 
    ///    adjacency is naturally built-into a 2D array of Vertices.
    /// </summary>
    public class Maze
    {
        #region Maze class fields for drawing the maze (no need to read, you don't need these)
        // ---------------------------------------------------------------------------
        // Constants
        // ---------------------------------------------------------------------------

        // Drawing-related constant: size of each tile in square pixels
        const int MAZE_UNIT_SIZE = 40;

        // ---------------------------------------------------------------------------
        // Fields
        // ---------------------------------------------------------------------------

        // Maze colors
        private Color MAZE_COLOR_EMPTY = Color.White;
        private Color MAZE_COLOR_WALL = Color.Black;
        private Color MAZE_COLOR_START = Color.Lime;
        private Color MAZE_COLOR_END = Color.Red;
        private Color MAZE_COLOR_PATH = Color.CornflowerBlue;
        private Color[] MAZE_COLORS;

        // A 1x1 white texture (basically a single pixel) for drawing
        private Texture2D pixel;

        // Maze offsets (used for centering the maze)
        int xOffset;
        int yOffset;
        #endregion

        #region Maze class fields for graph searching (these are needed for graph searching!)

        // Maze sizes: Number of tiles in the gridded maze
        private int mazeSizeX;			// Width/columns
        private int mazeSizeY;			// Height/rows

        // Maze Vertices: This class's graph and adjacency structure, all rolled into one!
        // And NO, you do NOT need an adjacency list or adjacency matrix to determine whether
        //   any Vertex is adjacent to another Vertex. The gridded nature of storing Vertices
        //   in a 2D array means adjacencies (neighbors) are simply found as the Vertex above,
        //   below, to the left, and to the right of any Vertex.
        private Vertex[,] vertices;

        // Starting and ending vertices for maze graph searching
        private Vertex startVertex;     // Drawn in green
        private Vertex endVertex;		// Drawn in red
        #endregion

        #region Constructor/Drawing methods (No need to read unless curious, you won't need these)

        // ---------------------------------------------------------------------------
        // Constructor
        // ---------------------------------------------------------------------------
        /// <summary>
        /// Creates a new maze object
        /// </summary>
        /// <param name="device">The graphics device for the game</param>
        public Maze(GraphicsDevice device)
        {
            // Create the 1x1 white pixel texture
            pixel = new Texture2D(device, 1, 1);
            pixel.SetData<Color>(new Color[] { Color.White });

            // Set up the color array
            MAZE_COLORS = new Color[4];
            MAZE_COLORS[(int)Tile.Empty] = MAZE_COLOR_EMPTY;
            MAZE_COLORS[(int)Tile.Wall] = MAZE_COLOR_WALL;
            MAZE_COLORS[(int)Tile.Start] = MAZE_COLOR_START;
            MAZE_COLORS[(int)Tile.End] = MAZE_COLOR_END;
        }

        // ---------------------------------------------------------------------------
        // Method for setting up the maze graph
        // ---------------------------------------------------------------------------

        /// <summary>
        /// Sets up the maze data
        /// </summary>
        /// <param name="mazeTexture">The texture to get the maze from</param>
        public void SetMaze(Texture2D mazeTexture, int screenWidth, int screenHeight)
        {
            // Get the maze sizes
            mazeSizeX = mazeTexture.Width;
            mazeSizeY = mazeTexture.Height;

            // Offsets (for centering maze in the output window)
            xOffset = (screenWidth - MAZE_UNIT_SIZE * mazeSizeX) / 2;
            yOffset = (screenHeight - MAZE_UNIT_SIZE * mazeSizeY) / 2;

            // Get data from the maze texture (black and white maze Texture2D)
            Color[] textureData = new Color[mazeTexture.Width * mazeTexture.Height];
            mazeTexture.GetData<Color>(textureData);

            // Set up the Vertices graph
            vertices = new Vertex[mazeSizeX, mazeSizeY];
            for (int y = 0; y < mazeSizeY; y++)
            {
                for (int x = 0; x < mazeSizeX; x++)
                {
                    // Start with data to represent an empty space - 
                    // assume the current Texture2D pixel is white
                    Tile currentData = Tile.Empty;

                    // Get the color of the current pixel
                    Color currentColor = textureData[y * mazeSizeX + x];

                    // Check for various colors from the maze image png to determine whether a
                    //   given tile is a wall, start, end or empty vertex.
                    // Black pixel in the Texture2D: Wall
                    if (currentColor == MAZE_COLOR_WALL)
                        currentData = Tile.Wall;
                    // Green pixel in the Texture2D: Start vertex
                    else if (currentColor == MAZE_COLOR_START)
                        currentData = Tile.Start;
                    // Red pixel in the Texture2D: End vertex
                    else if (currentColor == MAZE_COLOR_END)
                        currentData = Tile.End;

                    // Assign this Vertex to the grid
                    // Check for start/end vertices
                    vertices[x, y] = new Vertex(x, y, currentData);

                    // Found the start or end? Set the appropriate fields with Vertex references.
                    if (currentColor == MAZE_COLOR_START)
                        startVertex = vertices[x, y];
                    else if (currentColor == MAZE_COLOR_END)
                        endVertex = vertices[x, y];

                }
            }
        }

        // ---------------------------------------------------------------------------
        // Drawing Methods
        // Having trouble with the maze solution?  COMMENT OUT the DrawSolution() method below!
        // ---------------------------------------------------------------------------

        /// <summary>
        /// Draws the maze on the screen
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void Draw(SpriteBatch spriteBatch)
        {
            // Draw the maze itself
            DrawMaze(spriteBatch);

            // Reset all Vertices and get the starting Vertex
            ResetAllVertices();

            // Solve the maze and draw the solution
            DrawSolution(spriteBatch, SolveMaze());
        }

        /// <summary>
        /// Draws the walls, start and end locations of the map
        /// </summary>
        /// <param name="spriteBatch"></param>
        public void DrawMaze(SpriteBatch spriteBatch)
        {
            // The current color to draw
            Color currentColor = Color.White;

            // The rectangle to use for drawing
            Rectangle rect = new Rectangle();
            rect.Width = MAZE_UNIT_SIZE;
            rect.Height = MAZE_UNIT_SIZE;

            // Loop and draw
            for (int x = 0; x < mazeSizeX; x++)
            {
                for (int y = 0; y < mazeSizeY; y++)
                {
                    // Set up each rectangle
                    rect.X = x * MAZE_UNIT_SIZE + xOffset;
                    rect.Y = y * MAZE_UNIT_SIZE + yOffset;

                    // Draw it!
                    spriteBatch.Draw(pixel, rect, MAZE_COLORS[(int)vertices[x, y].Data]);
                }
            }
        }

        /// <summary>
        /// Draw the solution path
        /// </summary>
        /// <param name="spriteBatch">Used for drawing</param>
        /// <param name="solution">The list that represents the solution</param>
        public void DrawSolution(SpriteBatch spriteBatch, List<Vertex> solution)
        {
            // Set up the rectangle
            Rectangle rect = new Rectangle();
            rect.Width = MAZE_UNIT_SIZE;
            rect.Height = MAZE_UNIT_SIZE;

            // Loop until we're out of Vertices
            foreach (Vertex currentVertex in solution)
            {
                // Check the data
                if (currentVertex.Data == Tile.Empty)
                {
                    // Set up this rectangle
                    rect.X = currentVertex.X * MAZE_UNIT_SIZE + xOffset;
                    rect.Y = currentVertex.Y * MAZE_UNIT_SIZE + yOffset;

                    // Draw it!
                    spriteBatch.Draw(pixel, rect, MAZE_COLOR_PATH);
                }
            }
        }

        // ---------------------------------------------------------------------------
        // Graph Searching Reset Method
        // Having trouble with the maze solution?  COMMENT OUT the DrawSolution() method below!
        // ---------------------------------------------------------------------------

        /// <summary>
        /// Sets all Vertices to "unvisited"
        /// </summary>
        public void ResetAllVertices()
        {
            // Iterate through all Vertices in the graph
            for (int x = 0; x < mazeSizeX; x++)
            {
                for (int y = 0; y < mazeSizeY; y++)
                {
                    // Reset each Vertex
                    vertices[x, y].Visited = false;
                }
            }
        }
        #endregion

        #region Helper Method for Tile Validity (You can read this and call this if you want!)

        /// <summary>
        /// Determines whether a vertex is searchable/visitable.
        /// </summary>
        /// <param name="x">The x value (column) of the vertex to check</param>
        /// <param name="y">The y value (row) of the vertex to check</param>
        /// <returns>True if the vertex is valid, false otherwise</returns>
        public Boolean IsTileValid(int x, int y)
        {
            // Is the tile out of bounds of the tile grid?
            if (y < 0 || x < 0 ||
                y >= vertices.GetLength(0) ||
                x >= vertices.GetLength(1))
            {
                return false;
            }

            // Is the tile an open space and not yet visited?
            if (vertices[x, y].Data != Tile.Wall && vertices[x, y].Visited == false)
            {
                return true;
            }

            // The tile is an open space and HAS been visited already!
            return false;
        }
        #endregion

        #region Student Method 1: Solving the Maze (You will write this method!)
        // -------------------------------------------------------------------------
        // TODO: Complete the SolveMaze method below:
        // It must return a list of vertices on the path from start to the exit.
        // This is NOT Dijkstra's algorithm - Just a normal BFS or DFS graph search.
        // 
        // Some useful information/tips:
        // 
        // * Feel free to write any additional helper methods you think would be helpful!
        // 
        // * All vertices are stored in a 2D array: vertices[x, y]
        //    - This is the Graph for the maze.
        //    - This is NOT an adjacency matrix.
        //    - In fact, there is no adjacency matrix or adjacency list.
        //    - Neither are needed for a grid-based unweighted graph.
        //    - But determining adjacency on a grid is fairly uncomplicated!
        //    
        // * Assume only cardinal directions are adjacent. Diagonals are not adjacent.
        //   - Left, right, above and below are cardinal directions. 
        //   - Corners are not adjacent.
        // 
        // * The Maze already stores the start and end vertices in the following fields:
        //    - startVertex
        //    - endVertex
        //    
        // * Unlike other BFS or BFS searches you've done, this search may stop before
        //   all Vertices have had a chance to be visited!
        //
        // * The end condition is finding the "endVertex" during the search.
        //   Once it is reached, end the search and use the vertices
        //   currently in your data structure as the solution path.
        // -------------------------------------------------------------------------

        /// <summary>
        /// Runs an appropriate iterative DFS or BFS graph search on this maze.
        /// </summary>
        /// <returns>List of Vertices that represents the solution from start to end.</returns>
        public List<Vertex> SolveMaze()
        {
            // -------------------------------------------------------------------------
            // 1a. Use either Depth-First Search or Breadth-First Search to solve this maze.
            //    - One of them is more appropriate for this task.
            //
            // 1b. LEAVE A COMMENT answering the two following questions:
            //    - Which one are you using?  Why are you choosing that type of search?
            //    - Which data structure is needed for that type of search?
            // -------------------------------------------------------------------------
            // YOUR ANSWER:
            
            // I'm going to be trying to implement a depth first search, as I think that might be the easiest way for the code to traverse the maze
            // 

            Vertex currentVertex = new Vertex(startVertex.X, startVertex.Y, startVertex.Data);

            

            // -------------------------------------------------------------------------
            // 2. UNCOMMENT & use the SINGLE MOST APPROPRIATE structure below for your search.
            // DELETE the remaining one.
            // -------------------------------------------------------------------------

            // Queue<Vertex> queue = new Queue<Vertex>();
            // Stack<Vertex> stack = new Stack<Vertex>();



            // -------------------------------------------------------------------------
            // 3. COMPLETE AN ITERATIVE GRAPH SEARCH HERE USING THE DATA STRUCTURE FROM ABOVE.
            // -------------------------------------------------------------------------



            // -------------------------------------------------------------------------
            // 4. ADD SOLUTION PATH TO SOLUTION LIST.
            //    - Add vertices found during the search to the "path" List below
            //    - You can use the solutionPathlist's AddRange() method to shorten necessary code.
            // -------------------------------------------------------------------------
            List<Vertex> solutionPath = new List<Vertex>();
            //    - Add vertices found during the search to the List above
            //    - You can use the solutionPathList's AddRange() method if you want



            // -------------------------------------------------------------------------
            // 5. You are all done with this task!
            // This method now returns the full "path" to solve the maze
            // DO NOT change this return statement.
            // -------------------------------------------------------------------------
            return solutionPath;
        }
        #endregion


        #region Student Method 2: Recursively summing digits (You will write this method!)

        // -------------------------------------------------------------------------
        // TODO: Complete the CalcDigitSum method below:
        // -------------------------------------------------------------------------

        /// <summary>
        /// Calculates the sum of all digits in a number
        /// </summary>
        /// <param name="number">Integer value</param>
        /// <returns>The sum of all digits in a number</returns>
        public int CalcDigitSum(int number)
        {
            return 0;
        }
        #endregion

        #region Optional Extra credit (if you read this far!)

        // -------------------------------------------------------------------------
        // For up to 2 points of extra credit:
        //
        // A) Your biggest takeaway from IGME 106:
        //     - What will stick with you for a long time?
        //     - What topics piqued your curiosity the most?
        //     - What surprised you the most about this course?
        //
        // B) The biggest growth you've seen in your work in IGME 105/106:
        //     - How has your skill grown during the semester?
        //     - Where have you noticed positive growth?
        //     - What are you most proud of?
        //
        // C) What you learned about yourself during the course:
        //     - How are you changed?
        //     - What do you think differently about now?
        //     - Or what will you do differently in other courses?
        //
        // Answer any or all of the questions below in comments!!!
        // -------------------------------------------------------------------------
        // A:
        //
        // B:
        //
        // C:
        //
        // -------------------------------------------------------------------------
        #endregion
    }
}
