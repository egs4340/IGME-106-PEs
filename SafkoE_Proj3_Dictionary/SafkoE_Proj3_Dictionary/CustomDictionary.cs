using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafkoE_Proj3_Dictionary
{
    internal class CustomDictionary<K, V>
    {
        CustomPair<K, V>[] Data;




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
