using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_Structs
{
    internal struct Vector2
    {
        private float x;
        private float y;

        //geting and setting the x
        public float X
        {
            get { return x; }
            set { x = value; }
        }

        //geting and setting the y
        public float Y
        {
            get { return y; }
            set { y = value; }
        }
        
        //parameterized constructor for Vector2
        public Vector2(float x, float y)
        {
            this.x = x;
            this.y = y;
        }

        public override string ToString()
        {
            Console.WriteLine("(" + X + ", " + Y + ")");
            return default;
        }

    }
}
