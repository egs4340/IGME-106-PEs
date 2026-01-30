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
        private T data;
        private CustomLinkedNode<T> next;

        //adds the next node
        public CustomLinkedNode<T> Next
        {
                //Basic get/set for the next class
                get { return next; }

                set { next = value; }
        }

        public T Data
        {
            //Basic get/set for the next class
            get { return data; }

            set { data = value; }
        }

        //Constructor for the Custom Linked Node
        public CustomLinkedNode(T newData)
       
       {
            //data is set to newdata
            data = newData;

            //next node is set to null
            next = null;
       }

        


        
    }
}
