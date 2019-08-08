using CollectionHierarchy.Contracts;
using System.Collections.Generic;

namespace CollectionHierarchy.Models
{
    public class MyList : ICountable
    {
        private List<string> collection;

        public MyList()
        {
            this.collection = new List<string>();
        }

        public int Used
        {
            get
            {
                return this.collection.Count;
            }
        }
        public int Add(string item)
        {
            this.collection.Insert(0, item);

            return 0;
        }

        public string Remove()
        {
            string firstItem = this.collection[0];
            this.collection.RemoveAt(0);

            return firstItem;
        }
    }
}
