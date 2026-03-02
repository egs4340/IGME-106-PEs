using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafkoE_Proj3_Dictionary
{
    internal class CustomDictionary<K, V>
    {
        //test for the custom pair array

        //private CustomPair<K, V>[] Data = new CustomPair<K, V>[10];
        //CustomPair<K, V>[] Data;
        //CustomDictionary<string, string>

        private int count = 0;

        private int size;

        private double MaxLoadFactor = 0.7;

        public double LoadFactor;

        private List<CustomPair<K, V>>[] data;

        //constructor for Custom Dictionary
        public CustomDictionary()
        {
            size = 100;
            data = new List<CustomPair<K, V>>[size];
        }

        //overloaded constructor
        public CustomDictionary(int size)
        { 
            this.size = size;
            data = new List<CustomPair<K, V>>[size];
        }

        //test for the indexer
        private V[] v = new V[0];
        public V this[int i]
        { 
            get { return v[i]; }
            set { v[i] = value; }
        }



        //test for the count
        public int Count
        {
            get { return count; }
        }


        public int this[K position]
        {
            //the indexer's getter
            get
            {
                //sets the position to the key's position's hash code divided by its size
                int pos = position.GetHashCode() / size;

                //if statement for when the position is empty/doesn't exist
                if (data[pos] == null)
                {
                    throw new KeyNotFoundException("Error! The key " + position.ToString() +
                        " Was not found!");
                }

                List<CustomPair<K, V>> myList = data[pos];
                //for loop with an if statement that returns the pos if the key is equal to the position
                for (int i = 0; i < myList.Count; i++)
                {
                    if (myList[i].Key.Equals(position))
                    {
                        return pos; 
                    }
                }
                return -1;
            }

            //the indexer's setter
            set
            {
                int pos = position.GetHashCode() / size;
                if(data[pos] == null)
                {
                    throw new KeyNotFoundException("Position doesn't exist yet!");
                }
            }
        }

        public void Add(K key, V value)
        {

        }

        //contains key method
        public bool ContainsKey(K key)
        {
            int pos = key.GetHashCode() / size;
            if (data[pos] == null)
            {
                throw new KeyNotFoundException("Key doesn't exist in this position!");
            }
            //gets the position of the data, for loop checks if it's equal, then returns true if it is
            List<CustomPair<K, V>> myList = data[pos];
            for (int i = 0; i < myList.Count; i++)
            {
                if (myList[i].Key.Equals(key))
                {
                    return true;
                }
            }
            return false;
        }

        public bool Remove(K key)
        {
            return false;
        }


        //clear method
        public void Clear()
        {
            //create a new list array of the same size, wipe out everything in it
            data = new List<CustomPair<K, V>>[size];
        }


        //Print Debug method
        public void PrintDebug()
        {
            Console.WriteLine("All Debugging info about the dictionary");
            Console.WriteLine("Count is " + Count);
            Console.WriteLine("LoadFactor is " + LoadFactor);
            Console.WriteLine("Number of Buckets: " + size);
            for (int i = 0; i < data.Length; i++)
            {
                if (data[i] != null)
                {
                    Console.WriteLine("Bucket List " + i + " has not been instantiated yet");
                }
                else
                {
                    Console.WriteLine("Bucket List " + i + " contains list of size " +  data[i].Count);
                }
            }
        }


    }
}
