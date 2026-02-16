using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafkoE_Proj2_DoubleLinkedList
{
    internal class CustomLinkedList<T>
    {


        //Integer for the count of the list
        public int Count;


        //makes a CustomLinkedNode named head
        private CustomLinkedNode<T> head;

        private CustomLinkedNode<T> tail;

        //Constructor for CustomLinkedList
        public CustomLinkedList()
        {
            Count = 0;
            head = null;
            tail = null;
        }


        //private customlinked node class to get the node
        private CustomLinkedNode<T> GetNode(int index)
        {

            //checks if the index is out of range
            if (index < 0 || index > Count)
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

        //method for the getdata
        private T GetData(int index)
        {
            //gets the node first
            CustomLinkedNode<T> node = GetNode(index);

            //checks if the index is in range, then gets the data
            if (index >= 0 && index < Count)
            {
                Console.WriteLine("The data is in " + index);
                return node.Data;
            }

            //else statement in case the code is invalid
            else
            {
                throw new Exception("Invalid index. Index must be between 0 and " + (Count - 1).ToString());
            
            }
        }

        //added the add class to make is add to the count and the data
        public void Add(T data)
        {
            //created new node to add to the list
            CustomLinkedNode<T> newNode = new CustomLinkedNode<T>(data);
            newNode.Data = data;


            //sets the head to new node
            if (head == null)
            {
                head = newNode;
                Count++;
                return;
            }


            CustomLinkedNode<T> node = head;

            while (node.Next != null)
            {
                node = node.Next;
            }

            node.Next = newNode;


            Count++;

        }

        //indexer for the Linked List index
        public T this[int index]

        {
            get
            {
                if (index >= 0 && index < Count)
                {
                    //gets the data at the index position if it's in a valid range
                    return GetData(index);
                }
                //makes a string for the exception message
                string exceptionMessage;

                //checks if the Linked List's count is 0
                if (Count == 0)
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
                        Count - 1);
                }
                //Catches anything that tries to put something in a negative position or larger than the size of the array
                throw new IndexOutOfRangeException(exceptionMessage);
            }
        }

        //Added RemoveAt method, which should (HOPEFULLY) set the index to an empty value and make it nullified.
        public T RemoveAt(int index)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException("Index is out of range!");
            }
            //check if index is the head
            T data;

            if(index == 0)
            {
                data = head.Data;
                head = head.Next;
                head.Prev = null;
                return data;
            }
            
            CustomLinkedNode<T> node = head;

            int pos = 0;

            while (pos < index)
            {
                node = node.Next;
                pos++;
            }
            //sets the previous node to the new previous node and the next node to the new next node
            data = node.Data;
            (node.Next).Prev = node.Prev;
            (node.Prev).Next = node.Next;
            return data;
        }

        //insertat method
        public void Insert(T data, int index)
        {
            bool startAtHead = true;

            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException("Not in index!");
            }

            //if the count minus the index is greater than half of the count, start at the head;
            if (Count - index > Count / 2)
            {

            }

            //else, start at the tail
            else
            {

            }

            //the node that gets inserted
            CustomLinkedNode<T> node = new CustomLinkedNode<T>(data);
            node.Data = data;

            //if the index is no numbers, the node is everything in the index
            if (index == 0)
            {
                head.Prev = node;
                node.Next = head;
                head = node;
                tail = node;
                Count++;
                return;
            }

            //index = count, then insert at tail
            if (index == Count)
            {
                node.Next = null;
                node.Prev = tail;
                tail.Next = node;
                tail = node;
                Count++;
                return;
            }

            //new node for insertion
            CustomLinkedNode<T> newNode = new CustomLinkedNode<T>(data);
            int pos = 0;
            newNode = head;

            //if we start at the head, the node will move to the head
            if (startAtHead == true)
            {
                while (pos < index - 1)
                {
                    node = node.Next;
                    pos++;
                }
            }

            //if we start at tail, the node will move to the tail
            if (startAtHead == false)
            {
                pos = Count;
                node = tail;
                
                while (pos > index)
                {
                    node = node.Prev;
                    pos--;
                }
            }
            //sets the new node to the current position of the node, sets that node to the previous positiion
            newNode.Next = node.Next;
            newNode.Prev = node;
            node.Next.Prev = newNode;
            node.Next = newNode;
            Count++;

        }

        //added the ability to print the list forwards
        public void PrintForward()
        {
            if (Count == 0)
            {
                Console.WriteLine("Empty List!");
                return;
            }

            else
            {
                CustomLinkedNode<T> node = head;

                while (node != null)
                {
                    Console.WriteLine(node.Data);
                    node = node.Next;

                }
            }
        }

        //added the ability to print the list backwards
        public void PrintBackward()
        {
            if (Count == 0)
            {
                Console.WriteLine("Empty List!");
                return;
            }

            else
            {
                CustomLinkedNode<T> node = tail;

                while (node != null)
                {
                    Console.WriteLine(node.Data);
                    node = node.Prev;
                }
            }
        }

        //public void for cleaing the list
        public void Clear()
        {
            Count = 0;
            head = null;
            tail = null;
        }


    }
}
