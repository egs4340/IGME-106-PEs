using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameOfLife
{
    //Added the Cell Class
    internal class Cell
    {

        //string for alive
        public string Alive;
        public string AliveSymbol = "@";
        

        public bool alive = true;
        
        //string for dead
        public string Dead;
        public string DeadSymbol = "-";

        //public cell constructor
        public Cell()
        {
            //random for getting a random percent of dead or alive cells
            Random random = new Random();
            
            //Makes integer isAlive to equal a random value between 0 and 100 to be able to make a 30% chance where the
            //Cells are dead
            //int isAlive = random.Next(0, 100);

            ////checks if the cell is alive, then sets the symbol to '@'
            //if (isAlive <= 30)
            //{
                //Alive = AliveSymbol;
            //}

            ////If the cell is dead, they have the '-' symbol
            //else
            //{
                //Alive = DeadSymbol;
            //}
            Alive = AliveSymbol;
            Dead = DeadSymbol;
        }


        //ToString override that provides the cell with a symbol to print
        public override string ToString()
        {
            //Returns the symbol for the Cells, which will be '@' if alive, and '-' if dead
            if (alive)
            { return Alive; }

            else
            { return Dead; }
        }
    }
}
