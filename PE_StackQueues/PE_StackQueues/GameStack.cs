using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_StackQueues
{
    internal class GameStack<T> : IStack<T>
    {

        //added list
        List<T> list;
        public GameStack() 
        {
            list = new List<T>();

        }


        public int Count
        { get 
            { return list.Count; }
        }

        public bool IsEmpty
        { get
            {
                //if statement for checking if the code is empty
                if (Count == 0)
                { return true; }
                else
                {
                    return false;
                }
            } 
        }

        //returns what's at the top of the stack
        public T Peek()
        {

            try
            {
                return list[list.Count - 1];
            }

            catch (Exception e)
            {
                Console.WriteLine("Cannot peek an empty stack!");
                //returns a default value so the pop can run
                return default(T);
            }
        }

        //code for the push method
        public void Push(T item)
        {
            list.Add(item);
        }

        //code for the pop method
        public T Pop()
        {
            try
            {
                T item = list[list.Count - 1];

                list.RemoveAt(list.Count - 1);

                return item;
            }

            catch(Exception e)
            {
                Console.WriteLine("Can't pop an empty list!");
                //returns a default value so the pop can run
                return default(T);
            }
            
        }

    }
}
