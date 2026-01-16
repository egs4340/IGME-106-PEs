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

        //Added private int for the Circle's X and Y positions and X and Y Offsets, and the Circle's area, perimeter, and radius.
        private int centerX = 0;
        private int centerY = 0;
        private double circleArea;
        private double circlePerimeter;
        private double circleRadius;
        private int xOffset = 2;
        private int yOffset = 2;
        
        //Method that gets and returns the X to the xCircle
        public double X { get; set; }


        //Method that gets and returns the Y to the yCircle
        public double Y { get; set; }


        //Method that gets the Area
        public double Area { get; }


        //Method that gets the Perimeter
        public double Perimeter { get; } 


        //Constructor to add in the x and y units
        internal Circle(int centerX, int centerY, double radius)
        {
            this.X = centerX;
            this.Y = centerY;
            this.circleRadius = radius;
            Perimeter = 2 * Math.PI * circleRadius;
            Area = Math.PI * circleRadius * circleRadius;
        }


        //Added the MoveTo to hopefully be able to be used by the Circle
        public void MoveTo(double x, double y)
        {
            X = x;
            Y = y;
        }


        //Added the MoveBy to hopefully be able to be used by the Circle
        public void MoveBy(double xOffset, double yOffset)
        {
            { X += (int)xOffset; }{ Y += (int)yOffset; }
        }


        //Allows the Circle to check it's distance using the distance formula
        public double DistanceTo(IPosition position)
        {
            double distance = (X - position.X) * (X - position.X) + (Y - position.Y) * (Y - position.Y);
            return Math.Sqrt(distance);
        }


        //Adds the ContainsPosition boolean
        public bool ContainsPosition(IPosition position)
        {

            //Is the distance from the center to the point less than the radius?
            //If yes, return true, else return false
            double distance = (X - position.X) * (X - position.X) + (Y - position.Y) * (Y - position.Y);
            distance = Math.Sqrt(distance);

            if (distance < circleRadius)
            {
                return true;
            }

            else
            {
                return false;
            }
        }


        //Adds the IsLargerThan boolean
        public bool IsLargerThan(IArea areaToCheck)
        {
            //Is the area of this circle larger than the area of another circle?

            if (Area > areaToCheck.Area)
            {
                return true;
            }

            else
            {
                return false;
            }
        }

        public void PrintInfo()
        {
            Console.WriteLine("Circle: Center X " + this.X + " Center Y " + this.Y + ", Radius " + this.circleRadius +
                ", Area " + this.Area + ", Perimeter " + this.Perimeter);
        }


    }
}
