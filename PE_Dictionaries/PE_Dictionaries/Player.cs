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

        Player()
        {
            score = 0;
            name = null;
        }

        //Parameterized constructor
        public Player(string name, int score)
        {
            this.score = score;
            this.name = name;
        }


        public override string ToString()
        {
            Console.WriteLine(this.name + "'s Score is: " + this.score);
            return default;
        }

    }
}
