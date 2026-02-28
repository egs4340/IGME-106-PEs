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
        
        public CustomPair<K, V>[] data;

        public CustomPair<K, V>[] count;

        //CustomDictionary<string, string>


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
