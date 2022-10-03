using CollectionHierarchy.Models;
using System;

namespace CollectionHierarchy
{
    public class StartUp
    {
        static void Main(string[] args)
        {
            string[] elements = Console.ReadLine().Split();

            AddCollection addCollection = new AddCollection();
            AddRemoveCollection addRemoveCollection = new AddRemoveCollection();
            MyList myList = new MyList();

            string addIndicesAddCollection = String.Empty;
            string addIndicesAddRemoveCollection = String.Empty;
            string addIndicesMyList = String.Empty;

            int indexOfAdding = 0;
            foreach (var element in elements)
            {
                indexOfAdding = addCollection.Add(element);
                addIndicesAddCollection += $"{indexOfAdding} ";

                indexOfAdding = addRemoveCollection.Add(element);
                addIndicesAddRemoveCollection += $"{indexOfAdding} ";

                indexOfAdding = myList.Add(element);
                addIndicesMyList += $"{indexOfAdding} ";
            }

            int amountOfRemoves = int.Parse(Console.ReadLine());

            string removedItemFromAddRemoveCollection = String.Empty;
            string removedItemFromMyList = String.Empty;

            string removedItem = string.Empty;
            for (int i = 0; i < amountOfRemoves; i++)
            {
                removedItem = addRemoveCollection.Remove();
                removedItemFromAddRemoveCollection += $"{removedItem} ";

                removedItem = myList.Remove();
                removedItemFromMyList += $"{removedItem} ";
            }

            Console.WriteLine(addIndicesAddCollection.TrimEnd());
            Console.WriteLine(addIndicesAddRemoveCollection.TrimEnd());
            Console.WriteLine(addIndicesMyList.TrimEnd());
            Console.WriteLine(removedItemFromAddRemoveCollection.TrimEnd());
            Console.WriteLine(removedItemFromMyList.TrimEnd());
        }
    }
}
