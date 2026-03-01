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

        private int count;

        public double LoadFactor;

        private List<CustomPair<K, V>>[] Data;

        //test for the indexer
        private V[] v = new V[0];
        public V this[int i]
        { 
            get { return v[i]; }
            set { v[i] = value; }
        }


        //test for the data
        public CustomPair<K, V>[] data;

        //test for the count
        public int Count
        {
            get { return count; }
        }




        //contains key method
        public bool ContainsKey(K key)
        {

            if (key.Equals(key.GetHashCode()))
            { return; }
        }


        //clear method
        public void Clear()
        {
            CustomPair<K, V>.ReferenceEquals(this, null);
        }


        //Print Debug method
        public void PrintDebug()
        {

        }


    }
}
