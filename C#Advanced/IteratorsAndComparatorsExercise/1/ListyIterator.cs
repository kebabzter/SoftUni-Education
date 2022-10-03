using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace ListyIterator
{
    public class ListyIterator<T>:IEnumerable<T>
    {
        private List<T> colection;
        private int currentIndex;

        public ListyIterator(params T[] data)
        {
            colection = new List<T>(data);
            currentIndex = 0;
        }

       // public List<T> List => colection;

        public IEnumerator<T> GetEnumerator()
        {
            foreach (T element in colection)
            {
                yield return element;
            }
        }

        public bool HasNext() => currentIndex < colection.Count - 1;

        public bool Move()
        {
            bool canMove = HasNext();
            if (canMove)
            {
                currentIndex++;
            }
            return canMove;
        }

        public void Print()
        {
            if (colection.Count==0)
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
            Console.WriteLine($"{colection[currentIndex]}");
        }

        public void PrintAll()
        {
            Console.WriteLine(string.Join(" ",colection));
        }
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
