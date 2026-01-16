using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Interfaces
{
    //Point class with the interface for position
    internal class Point : IPosition 
    {

        //Added private ints for the Point's X and Y coordinates and X and Y Offsets
        private int x = 0;
        private int y = 0;
        private int xOffset = 2;
        private int yOffset = 2;


        //basic Point constructor
        public Point()
        {

        }


        //Constructor to add in the x and y units
        internal Point(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }


        //Method that gets and returns the X to the xPoint
        public double X { get; set; }


        //Method that gets and returns the Y to the yPoint
        public double Y {  get; set; }


        //Added the MoveTo to hopefully be able to be used by the Points
        public void MoveTo(double x, double y)
        {
            X = x;
            Y = y;
        }


        //Added the MoveBy to hopefully be able to be used by the Points
        public void MoveBy(double xOffset, double yOffset)
        {
            { X += (int)xOffset; } { Y += (int)yOffset; }
        }


        //Allows the Point to check it's distance using the distance formula
        public double DistanceTo(IPosition position)
        {
            double distance = (X - position.X) * (X - position.X) + (Y - position.Y) * (Y - position.Y);
            return Math.Sqrt(distance);
        }


        //The way in which the Point's info will be printed
        public void PrintInfo()
        {
            Console.WriteLine("Point: X " + this.X + " Y " + this.Y);
        }

    }
}
