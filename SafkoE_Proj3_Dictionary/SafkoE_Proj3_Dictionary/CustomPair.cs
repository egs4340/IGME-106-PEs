using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SafkoE_Proj3_Dictionary
{
    internal class CustomPair<K, V>
    {
        //class parts
        public K Key;
        public V Value;


        //constructor
        public CustomPair(K key, V value)
        {
            Key = key;
            Value = value;
        }

        public int GetHash()
        {
            return Key.GetHashCode();
        }
    }
}
