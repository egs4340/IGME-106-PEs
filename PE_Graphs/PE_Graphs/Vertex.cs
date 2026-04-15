using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Graphs
{
    internal class Vertex
    {

        internal string name;
        internal string description;


        public void ToString()
        {
            Console.WriteLine($"{name.ToUpper()}: {description}");
        }



    }
}
