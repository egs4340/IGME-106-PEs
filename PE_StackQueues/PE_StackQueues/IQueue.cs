using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PE_StackQueues
{
    internal interface IQueue<T>
    {
        // Gets the current count of items in the queue
        int Count { get; }
        // Gets whether or not there are items in the queue
        bool IsEmpty { get; }
        // Returns the front-most data in the queue.
        // Throws an exception if the queue is empty.
        T Peek();
        // Adds new data to the back of the queue.
        // T: The data to add
        void Enqueue(T item);
        // Removes and returns the front-most data in the queue.
        // Throws an exception if the queue is empty.
        T Dequeue();
    }
}
