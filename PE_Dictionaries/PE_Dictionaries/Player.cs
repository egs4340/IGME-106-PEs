using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Dictionaries
{
    internal class Player
    {
        //added the private ints and strings
        private int score;
        private string name;

        //Parameterized constructor
        public Player(string name, int score)
        {
            this.score = score;
            this.name = name;
        }


    }
}
