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
            this.count = 0;
            this.head = null;
        }


        //private customlinked node class to get the node
        private CustomLinkedNode<T> GetNode(int index)
        {
            index = this.count;
            //checks if the index is out of range
            if (index < 0)
            {
                Console.WriteLine("Index is out of range!");
                index = 0;
            }

            //if the index is in range, make the node the head
            if (index >= 0 && index < count)
            {
                index = count - 1;
                Console.WriteLine("Node is in " + index);
            }


            //This bit of code is only here so that the error message would stop and so a value would get returned. I really hope
            //this is okay because I couldn't figure out any other way of making the GetNode method stop being an error
            return head;


            /*Code Commented out because it just wouldn't work. Nothing I tried made any of this work and the more I worked on it
             the less any of it made sense.
             * 
             * 
             * //for loop for the node to go to the next node
            CustomLinkedNode<T> node = this.head;
            for (int i = index; i >= 0; i--)
            {
                node = node.next;
            }
            */
        }

        //method for the getdata. I couldn't find a way to make it work, it just wouldn't work no matter what I tried.
        private T GetData(int index)
        {
            GetNode(index);
            //checks if the index is out of range
            if (index < 0)
            {
                Console.WriteLine("Index is out of range!");
                index++;
            }

            //checks if the index is in range, then gets the data
            if (index >= 0 && index < count)
            {
                CustomLinkedNode<T> node = head;
                index = count - 1;
                count++;
                Console.WriteLine("The data is in " + index);
                return GetData(index);
            }

            else
            {
                Console.WriteLine("Invalid Index of -1. Index must be between 0 and 4");
                index--;
            }

            //much like the other code line, this is only added so that the machine would stop flagging the GetData Method as an
            //error. I really don't think I'm good at linked lists.
            return GetData(index);
        }

        //added the add class to make is add to the count and the data
        public void Add(T data)
        {
            for (int i = 0; i < count; i++)
            {
                CustomLinkedNode<T> node = this.head;
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
