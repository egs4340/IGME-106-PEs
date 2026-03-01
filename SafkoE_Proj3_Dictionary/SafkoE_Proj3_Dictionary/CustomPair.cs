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
        private K Key;
        private V Value;


        //constructor
        public CustomPair(K key, V value)
        {
            this.Key = key;
            this.Value = value;
        }


    }
}
