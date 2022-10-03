using CollectionHierarchy.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CollectionHierarchy.Models
{
    public class MyList: IMyList
    {
        private List<string> collection;
        public MyList()
        {
            collection = new List<string>();
            Used = 0;
        }
        public int Used { get; private set; }

        public int Add(string item)
        {
            var indexOfAdding = 0;
            collection.Insert(indexOfAdding, item);
            Used++;
            return indexOfAdding;
        }

        public string Remove()
        {
            var removedItem = collection.FirstOrDefault();
            collection.RemoveAt(0);
            Used--;
            return removedItem;
        }
    }
}
