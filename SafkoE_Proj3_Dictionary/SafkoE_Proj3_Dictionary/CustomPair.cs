using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafkoE_Proj3_Dictionary
{
    internal class CustomPair<K, V>
    {
        public K Key;
        public V Value;

        CustomPair(K key, V value)
        {

            this.Key = key;
            this.Value = value;
        }


    }
}
