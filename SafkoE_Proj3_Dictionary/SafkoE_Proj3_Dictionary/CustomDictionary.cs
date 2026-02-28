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

        private int Count;

        private string LoadFactor;

        //test for the indexer
        private V[] v = new V[0];
        public V this[int i]
        { 
            get { return v[i]; }
            set { v[i] = value; }
        }

            
        //test for the data
        public CustomDictionary<K, V>[] data
        {
            get { return data; }
            set { data = value; }   
        }

        //test for the count
        public CustomDictionary<K, V>[] count
        {
            get { return count; }
            set { count = CustomPair<K, V>[].Length(); }
        }




        //contains key method
        public void ContainsKey(K key)
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
