using CollectionHierarchy.Contracts;
using System.Collections.Generic;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection : IRemovable
    {
        private List<string> collection;

        public AddRemoveCollection()
        {
            this.collection = new List<string>();
        }
        public int Add(string item)
        {
            this.collection.Insert(0, item);

            return 0;
        }

        public string Remove()
        {
            int lastIndex = this.collection.Count - 1;
            string lastItem = this.collection[lastIndex];
            this.collection.RemoveAt(lastIndex);

            return lastItem;
        }
    }
}
