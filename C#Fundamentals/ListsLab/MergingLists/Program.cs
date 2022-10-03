using System;
using System.Collections.Generic;
using System.Linq;

namespace MergingLists
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> firstList = Console.ReadLine()
                  .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                  .Select(int.Parse)
                  .ToList();
            List<int> secondList = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToList();

            List<int> resultList = new List<int>(firstList.Count+secondList.Count);
            int countShortList = Math.Min(firstList.Count,secondList.Count);

            for (int i = 0; i < countShortList; i++)
            {
                resultList.Add(firstList[i]);
                resultList.Add(secondList[i]);
            }

            if (firstList.Count>secondList.Count)
            {
                resultList.AddRange(AddRangeList(secondList,firstList));
            }
            else
            {
                resultList.AddRange(AddRangeList(firstList, secondList));
            }

            Console.WriteLine(string.Join(" ",resultList));
        }

        private static List<int> AddRangeList(List<int> shortList, List<int> largeList)
        {
            List<int> result = new List<int>(largeList.Count-shortList.Count);
            for (int i = shortList.Count; i < largeList.Count; i++)
            {
                result.Add(largeList[i]);
            }
            return result;
        }
    }
}
