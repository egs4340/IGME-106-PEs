using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    internal class CustomLinkedNode<T>
    {

        //privte data integer
        private int data;

        //adds the next node
        private CustomLinkedNode<T> next
        {
                //Basic get/set for the next class
                get { return next; }

                set { return; }
        }

        //Constructor for the Custom Linked Node
        public CustomLinkedNode(int newData)
       
       {
            //data is set to newdata
            data = newData;

            //next node is set to null
            next = null;
       }

        


        
    }
}
