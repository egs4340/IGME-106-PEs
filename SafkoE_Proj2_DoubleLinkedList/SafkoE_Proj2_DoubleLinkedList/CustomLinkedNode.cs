using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafkoE_Proj2_DoubleLinkedList
{
    internal class CustomLinkedNode<T>
    {

        //privte data integer, private next, and private previous
        private T data;
        private CustomLinkedNode<T> next;
        private CustomLinkedNode<T> prev;

        //adds the next node
        public CustomLinkedNode<T> Next
        {
            //Basic get/set for the next node
            get { return next; }

            set { next = value; }
        }

        public CustomLinkedNode<T> Prev
        {
            //Basic get/set for the previous node
            get { return prev; }

            set { prev = value; }
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

            //next node and previous node are set to null
            next = null;
            prev = null;
        }
    }
}
