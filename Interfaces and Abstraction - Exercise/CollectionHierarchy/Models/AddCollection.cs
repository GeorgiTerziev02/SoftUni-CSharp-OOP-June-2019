using CollectionHierarchy.Contracts;
using System.Collections.Generic;

namespace CollectionHierarchy.Models
{
    public class AddCollection : IAddable
    {
        private List<string> collection;
        public AddCollection()
        {
            this.collection = new List<string>();
        }

        public int Add(string item)
        {
            this.collection.Add(item);

            return this.collection.Count - 1;
        }
    }
}
