using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    internal class CustomLinkedNode<T>
    {

        //privte generic data
        private T data;

        //Next node in the list
        private CustomLinkedNode<T> next
        {
            //Basic get/set for the next class
            get { return next; }

            set { return; }
        }


        

        //Constructor for the Custom Linked Node
       public CustomLinkedNode(int data)
       
       {
            //
            data = 0;

            //
            next = null;
       }


        
    }
}
