using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddCollection : IAddCollection
    {
        private List<string> collection;

        public AddCollection()
        {
            collection = new List<string>();
        }

        public int Add(string item)
        {
            var indexOfAdding = collection.Count;
            this.collection.Insert(indexOfAdding, item);
            return indexOfAdding;
        }
    }
}
