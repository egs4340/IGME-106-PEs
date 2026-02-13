using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Structs
{
    internal struct Circle
    {
        public double radius;
        private Vector2 center = new Vector2(0, 0);
        private double x;
        private double y;

        //geting and setting the x
        public double X
        {
            get { return x; }
            set { x = value; }
        }

        //geting and setting the y
        public double Y
        {
            get { return y; }
            set { y = value; }
        }

        //get set for the radius
        public double Radius
        {
            get { return radius; } 
            set { radius = value; }
        }

        //get set for the vector center
        public Vector2 Center
        { 
            get { return center; } 
            set {  center = value; }
        }

        //parameterized constructor #1
        public Circle(double Radius, Vector2 Center)
        {
            this.Radius = radius;
            this.Center = center;
        }

        //Parameterized constructor #2
        public Circle(double radius, double x, double y)
        {
            this.radius = radius;
            this.x = x;
            this.y = y;
        }



        public void CalculateArea()
        {
            Console.WriteLine(Radius * Radius * float.Pi);
        }


        public override string ToString()
        {
            CalculateArea();
            Console.WriteLine("This circle has a radius of: " + radius + " and has a center of: " + center);
            return default;
        }

    }
}
