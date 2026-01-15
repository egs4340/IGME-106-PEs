using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    //Point class with the interface for position
    internal class Point : IPosition 
    {
        //Added private ints for the Point's X and Y coordinates
        private int x = 0;
        private int y = 0;


        //Method that gets and returns the X to the xPoint
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
        Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

    }
}
