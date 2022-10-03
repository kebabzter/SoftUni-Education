using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Generics
{
    public class Box<T>: IComparable<T> where T:IComparable<T>
    {
        public Box(T element)
        {
            Element = element;
        }

        public Box(List<T> elements)
        {
            Elements = elements;
        }
        public T Element { get;}

        public List<T> Elements { get; }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var item in Elements)
            {
                sb.AppendLine($"{item.GetType()}: {item}");
            }
            return sb.ToString().TrimEnd();
        }

        public void Swap(List<T> elements, int firstIndex, int secondIndex)
        {
            T temp = elements[firstIndex];
            elements[firstIndex] = elements[secondIndex];
            elements[secondIndex] = temp;
        }

        public int CompareTo(T other) => Element.CompareTo(other);

        public int CountGreaterElements<T>(List<T> list, T readLine) where T : IComparable
           => list.Count(x=>x.CompareTo(readLine)>0);
       
    }
}
