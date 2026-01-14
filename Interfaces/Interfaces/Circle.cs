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
        private int xCircle;
        private int yCircle;

        //Method that gets and returns the X to the xCircle
        public double X
        {
            get
            {
                return xCircle;
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
                return yCircle;
            }
            set
            {
                double Y;
            }
        }


    }
}
