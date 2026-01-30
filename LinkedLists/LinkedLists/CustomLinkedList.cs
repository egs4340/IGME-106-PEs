using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedLists
{
    internal class CustomLinkedList<T>
    {


        //Integer for the count of the list
        private int count;


        //makes a CustomLinkedNode named head
        private CustomLinkedNode<T> head;

        

        //Constructor for CustomLinkedList
        public CustomLinkedList()
        {
            count = 0;
            head = null;
        }


        //private customlinked node class to get the node
        private CustomLinkedNode<T> GetNode(int index)
        {

            //checks if the index is out of range
            if (index < 0 || index > count)
            {
                Console.WriteLine("Index is out of range!");
                return null;
            }

            //if the index is in range, make the node the head
            else
            {
                CustomLinkedNode<T> node = head;

                for (int i = index; i >= 0; i--)
                {
                    node = node.Next;
                }

                return node;
            }
            
        }

        //method for the getdata. I couldn't find a way to make it work
        private T GetData(int index)
        {
            //gets the node first
            CustomLinkedNode<T> node = GetNode(index);

            //checks if the index is in range, then gets the data
            if (index >= 0 && index < count)
            {
                Console.WriteLine("The data is in " + index);
                return node.Data;
            }

            //else statement in case the code is invalid
            else
            {
                throw new Exception("Invalid index. Index must be between 0 and 4");
            }
        }

        //added the add class to make is add to the count and the data
        public void Add(T data)
        {
            for (int i = 0; i < count; i++)
            {
                CustomLinkedNode<T> node = head;
                count++;
            }

        }

        //indexer for the Linked List index
        public T this[int index]

        {
            get
            {
                if (index >= 0 && index < count)
                {
                    //gets the data at the index position if it's in a valid range
                    return GetData(index);
                }
                //makes a string for the exception message
                string exceptionMessage;

                //checks if the Linked List's count is 0
                if (count == 0)
                {
                    //If count is zero, then there is no data in the list
                    exceptionMessage = "No data to retrieve, list is empty.";
                }

                //checks if the count is out of range
                else
                {
                    //Exception string for the error
                    exceptionMessage = String.Format(
                        "Index {0} is out of range. Index must be between 0 and {1}",
                        index,
                        count - 1);
                }
                //Catches anything that tries to put something in a negative position or larger than the size of the array
                throw new IndexOutOfRangeException(exceptionMessage);
            }
        }

    }
}
