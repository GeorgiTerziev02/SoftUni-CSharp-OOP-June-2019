using System;
using System.Collections.Generic;

namespace CustomRandomList
{
    public class RandomList<T> : List<T>
    {
        private Random rand;

        public RandomList()
        {
            rand = new Random();
        }

        public T RandomString()
        {
            int index = rand.Next(0, this.Count);

            T element = this[index];

            this.RemoveAt(index);

            return element;
        }
    }
}
