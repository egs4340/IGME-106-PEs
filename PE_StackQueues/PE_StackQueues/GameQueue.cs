using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_StackQueues
{
    internal class GameQueue<T> : IQueue<T>
    {
        //added list
        List<T> list;
        public GameQueue()
        {
            list = new List<T>();

        }


        public int Count
        {
            get
            { return list.Count; }
        }

        public bool IsEmpty
        {
            get
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

        //returns what's at the top of the Queue
        public T Peek()
        {

            try
            {
                return list[list.Count - 1];
            }

            catch (Exception e)
            {
                Console.WriteLine("Cannot peek an empty Queue!");
                //returns a default value so the pop can run
                return default(T);
            }
        }

        //code for the push method
        public void Enqueue(T item)
        {
            list.Add(item);
        }

        //code for the pop method
        public T Dequeue()
        {
            try
            {
                T item = list[list.Count - 1];

                list.RemoveAt(list.Count - 1);

                return item;
            }

            catch (Exception e)
            {
                Console.WriteLine("Can't Dequeue an empty list!");
                //returns a default value so the pop can run
                return default(T);
            }

        }

    }
}
