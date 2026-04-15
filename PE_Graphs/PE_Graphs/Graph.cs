using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace PE_Graphs
{
    internal class Graph
    {
        List<Vertex> vertices;

        Dictionary<String, List<Vertex>> adjacencyList;


        public Graph()
        {

            //All of the room vertexes

            Vertex room0 = new Vertex();
            Vertex room1 = new Vertex();
            Vertex room2 = new Vertex();
            Vertex room3 = new Vertex();
            Vertex room4 = new Vertex();
            Vertex room5 = new Vertex();
            Vertex room6 = new Vertex();


            //lists to hold the adjacencies of the rooms

            List<Vertex> adj0 = new List<Vertex>();
            List<Vertex> adj1 = new List<Vertex>();
            List<Vertex> adj2 = new List<Vertex>();
            List<Vertex> adj3 = new List<Vertex>();
            List<Vertex> adj4 = new List<Vertex>();
            List<Vertex> adj5 = new List<Vertex>();
            List<Vertex> adj6 = new List<Vertex>();


            //All of the adjacencies with the rooms

            adj0.Add(room1);
            adj0.Add(room2);

            adj1.Add(room0);
            adj1.Add(room1);
            adj1.Add(room4);

            adj2.Add(room0);
            adj2.Add(room1);
            adj2.Add(room2);
            adj2.Add(room3);
            adj2.Add(room4);

            adj3.Add(room2);
            adj3.Add(room4);
            adj3.Add(room5);

            adj4.Add(room1);
            adj4.Add(room2);
            adj4.Add(room3);
            adj4.Add(room5);

            adj5.Add(room3);
            adj5.Add(room4);
            adj5.Add(room6);

            adj6.Add(room5);


            //adds the rooms to the vertices list

            vertices.Add(room0);
            vertices.Add(room1);
            vertices.Add(room2);
            vertices.Add(room3);
            vertices.Add(room4);
            vertices.Add(room5);
            vertices.Add(room6);


            //adds the rooms and their adjacencies to the adjacencylist

            adjacencyList.Add("kitchen", adj0);

            adjacencyList.Add("dining", adj1);

            adjacencyList.Add("library", adj2);

            adjacencyList.Add("conservatory", adj3);

            adjacencyList.Add("Hall", adj4);

            adjacencyList.Add("deck", adj5);

            adjacencyList.Add("exit", adj6);


            //initializes the rooms and their descriptions

            room0.name = "Kitchen";
            room0.description = "This is the Kitchen";

            room1.name = "dining";
            room1.description = "This is the Dining Room";

            room2.name = "library";
            room2.description = "This is the Library";

            room3.name = "Conservatory";
            room3.description = "This is the Conservatory";

            room4.name = "hall";
            room4.description = "This is the Hall";

            room5.name = "deck";
            room5.description = "This is the Deck";

            room6.name = "exit";
            room6.description = "This is the exit";

        }


        public void ListAllVertices()
        {
            vertices.ToString();
        }


        public bool MapContainsRoom(string room)
        {
            if (string.IsNullOrEmpty(room))
            {
                return false;
            }

            else
            {
                return true;
            }
        
        }


        public bool AreAdjacent(string firstRoom, string secondRoom)
        {
            return false;
        }

        List<Vertex> GetAdjacentList(string room)
        {

        }

    }
}
