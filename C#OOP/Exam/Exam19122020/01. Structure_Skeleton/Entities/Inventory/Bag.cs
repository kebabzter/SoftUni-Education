using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using WarCroft.Constants;
using WarCroft.Entities.Items;

namespace WarCroft.Entities.Inventory
{
    public abstract class Bag : IBag
    {
        private readonly List<Item> internalItems;
        protected Bag(int capacity)
        {
            Capacity = capacity;
            internalItems = new List<Item>();
            Items = new ReadOnlyCollection<Item>(internalItems);
        }
        public int Capacity { get; set; } = 100;

        public int Load => Items.Sum(x=>x.Weight);

        public IReadOnlyCollection<Item> Items { get; }

        public void AddItem(Item item)
        {
            if (Load+item.Weight>Capacity)
            {
                throw new InvalidOperationException(ExceptionMessages.ExceedMaximumBagCapacity);
            }
            internalItems.Add(item);
        }

        public Item GetItem(string name)
        {
            
            if (Items.Count==0)
            {
                throw new InvalidOperationException(ExceptionMessages.EmptyBag);
            }
            Item result = Items.FirstOrDefault(x=>x.GetType().Name==name);

            if (result==null)
            {
                throw new ArgumentException(string.Format(ExceptionMessages.ItemNotFoundInBag, name));
            }

            internalItems.Remove(result);
            return result;
        }
    }
}
