using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class AddRemoveCollection:IAddRemoveCollection
    {
        private List<string> collection;
        public AddRemoveCollection()
        {
            collection = new List<string>();
        }
        public int Add(string item)
        {
            var indexOfAdding = 0;
            collection.Insert(indexOfAdding, item);
            return indexOfAdding;
        }

        public string Remove()
        {
            var removedItem = collection.LastOrDefault();
            collection.RemoveAt(collection.Count - 1);
            return removedItem;
        }
    }
}
