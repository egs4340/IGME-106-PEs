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
        private int xPoint;
        private int yPoint;

        //Method that gets and returns the X to the xPoint
        public double X
        {
            get
            {
                return xPoint;
            }
            set
            {
                double X;
            }
        }

        //Method that gets and returns the Y to the yCircle
        public double Y
        {
            get
            {
                return yPoint;
            }
            set
            {
                double Y;
            }
        }


    }
}
