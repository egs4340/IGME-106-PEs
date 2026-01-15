using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    //Circle class with the interfaces for both position and area
    internal class Circle : IPosition, IArea 
    {
        //Added private int for the Circle's X and Y positions
        private int x = 0;
        private int y = 0;

        //Method that gets and returns the X to the xCircle
        public double X
        {
            get
            {
                return X;
            }
            set
            {
                double x;
            }
        }

        //Method that gets and returns the Y to the yCircle
        public double Y
        {
            get
            {
                return Y;
            }
            set
            {
                double y;
            }
        }

        //Constructor to add in the x and y units
        Circle(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

    }
}
