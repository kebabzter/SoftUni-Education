using System;
using System.Linq;

namespace ArrayManipulator
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] arrNumbers = Console.ReadLine()
                 .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                 .Select(int.Parse)
                 .ToArray();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end")
                {
                    break;
                }

                string[] inputArr = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string command = inputArr[0];
                switch (command)
                {
                    case "exchange":
                        int index = int.Parse(inputArr[1]);
                        Exchange(arrNumbers, index);
                        break;
                    case "max":
                        string element = inputArr[1];
                        int indexElement = GetMaxIndex(arrNumbers, element);
                        if (indexElement >= 0)
                        {
                            Console.WriteLine(indexElement);
                        }
                        else
                        {
                            Console.WriteLine("No matches");
                        }
                        break;
                    case "min":
                        string elementMin = inputArr[1];
                        int indexElementMin = GetMinIndex(arrNumbers, elementMin);
                        if (indexElementMin ==-1)
                        {
                            Console.WriteLine("No matches");
                        }
                        else
                        {
                            Console.WriteLine(indexElementMin);
                        }
                        break;
                    case "first":
                        int count = int.Parse(inputArr[1]);
                        string typeElement = inputArr[2];
                        if (count > arrNumbers.Length)
                        {
                            Console.WriteLine("Invalid count");
                        }
                        else
                        {
                            FirstCountElem(arrNumbers, count, typeElement);
                        }
                        break;
                    case "last":
                        int countLast = int.Parse(inputArr[1]);
                        string typeLastElement = inputArr[2];
                        if (countLast > arrNumbers.Length)
                        {
                            Console.WriteLine("Invalid count");
                        }
                        else
                        {
                            LastCountElem(arrNumbers, countLast, typeLastElement);
                        }
                        break;
                }
            }
            Console.Write("[");
            Console.Write(string.Join(", ", arrNumbers));
            Console.WriteLine("]");
        }
        static void Exchange(int[] arrNumbers, int index)
        {
            if (index < 0 || index >= arrNumbers.Length)
            {
                Console.WriteLine("Invalid index");
                return;
            }

            for (int i = 0; i <= index; i++)
            {
                int first = arrNumbers[0];
                for (int j = 1; j < arrNumbers.Length; j++)
                {
                    arrNumbers[j - 1] = arrNumbers[j];
                }
                arrNumbers[arrNumbers.Length - 1] = first;
            }
        }
        static int GetMaxIndex(int[] arrNumbers, string element)
        {
            int maxElem = int.MinValue;
            int maxIndex = -1;
            if (element == "odd")
            {
                for (int i = 0; i < arrNumbers.Length; i++)
                {
                    if ((arrNumbers[i] % 2 != 0) && (arrNumbers[i] >= maxElem))
                    {
                        maxElem = arrNumbers[i];
                        maxIndex = i;
                    }
                }
            }
            else if (element == "even")
            {
                for (int i = 0; i < arrNumbers.Length; i++)
                {
                    if ((arrNumbers[i] % 2 == 0) && (arrNumbers[i] >= maxElem))
                    {
                        maxElem = arrNumbers[i];
                        maxIndex = i;
                    }
                }
            }
            return maxIndex;
        }
        static int GetMinIndex(int[] arrNumbers, string element)
        {
            int minElem = int.MaxValue;
            int minIndex = -1;
            if (element == "odd")
            {
                for (int i = 0; i < arrNumbers.Length; i++)
                {
                    if ((arrNumbers[i] % 2 != 0) && (arrNumbers[i] <= minElem))
                    {
                        minElem = arrNumbers[i];
                        minIndex = i;
                    }
                }
            }
            else if (element == "even")
            {
                for (int i = 0; i < arrNumbers.Length; i++)
                {
                    if ((arrNumbers[i] % 2 == 0) && (arrNumbers[i] <= minElem))
                    {
                        minElem = arrNumbers[i];
                        minIndex = i;
                    }
                }
            }
            return minIndex;
        }

        static void FirstCountElem(int[] arrNumbers, int count, string typeElement)
        {
            int currentCount = 0;
            int[] arr = new int[count];
            if (typeElement == "odd")
            {
                for (int i = 0; i < arrNumbers.Length; i++)
                {
                    if (arrNumbers[i] % 2 != 0)
                    {
                        arr[currentCount] = arrNumbers[i];
                        currentCount++;
                        if (currentCount == count)
                        {
                            break;
                        }
                    }
                }

            }
            else if (typeElement == "even")
            {
                for (int i = 0; i < arrNumbers.Length; i++)
                {
                    if (arrNumbers[i] % 2 == 0)
                    {
                        arr[currentCount] = arrNumbers[i];
                        currentCount++;
                        if (currentCount == count)
                        {
                            break;
                        }
                    }
                }
            }
            if (currentCount == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.Write("[");
                for (int i = 0; i < currentCount; i++)
                {
                    if (i == currentCount - 1)
                    {
                        Console.Write($"{arr[i]}");
                    }
                    else
                    {
                        Console.Write($"{arr[i]}, ");
                    }

                }
                Console.WriteLine("]");
            }
        }

        static void LastCountElem(int[] arrNumbers, int count, string typeElement)
        {
            int currentCount = 0;
            int[] arr = new int[count];
            if (typeElement == "odd")
            {
                for (int i = arrNumbers.Length - 1; i >= 0; i--)
                {
                    if (arrNumbers[i] % 2 != 0)
                    {
                        arr[currentCount] = arrNumbers[i];
                        currentCount++;
                        if (currentCount == count)
                        {
                            break;
                        }
                    }
                }

            }
            else if (typeElement == "even")
            {
                for (int i = arrNumbers.Length - 1; i >= 0; i--)
                {
                    if (arrNumbers[i] % 2 == 0)
                    {
                        arr[currentCount] = arrNumbers[i];
                        currentCount++;
                        if (currentCount == count)
                        {
                            break;
                        }
                    }
                }
            }
            if (currentCount == 0)
            {
                Console.WriteLine("[]");
            }
            else
            {
                Console.Write("[");
                for (int i = 0; i < currentCount; i++)
                {
                    if (i == currentCount - 1)
                    {
                       Console.Write($"{arr[currentCount-1-i]}");
                    }
                    else
                    {
                        Console.Write($"{arr[currentCount-1-i]}, ");
                    }

                }
                Console.WriteLine("]");
            }
        }
    }
}
