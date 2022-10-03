using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnonymousThreat
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> inputData = Console.ReadLine()
              .Split(" ", StringSplitOptions.RemoveEmptyEntries)
              .ToList();
            while (true)
            {
                string commandsInfo = Console.ReadLine();
                if (commandsInfo=="3:1")
                {
                    break;
                }

                string[] commands = commandsInfo.Split(" ",StringSplitOptions.RemoveEmptyEntries);
                string command = commands[0];
                if (command=="merge")
                {
                    int startIndex = int.Parse(commands[1]);
                    int endIndex = int.Parse(commands[2]);
                    if (startIndex>=inputData.Count||endIndex<0)
                    {
                        continue;
                    }
                    if (startIndex<0)
                    {
                        startIndex = 0;
                    }
                    if (endIndex>=inputData.Count)
                    {
                        endIndex = inputData.Count - 1;
                    }
                    StringBuilder sb = new StringBuilder();
                    for (int i = startIndex; i <= endIndex; i++)
                    {
                        sb.Append(inputData[i]);
                    }
                    inputData.RemoveRange(startIndex,endIndex-startIndex+1);
                    inputData.Insert(startIndex, sb.ToString());

                }
                else if (command=="divide")
                {
                    int index = int.Parse(commands[1]);
                    int partitions = int.Parse(commands[2]);
                    string element = inputData[index];
                    inputData.RemoveAt(index);
                    int size = element.Length / partitions;
                    List<string> substringList = new List<string>();
                    for (int i = 0; i < partitions-1; i++)
                    {
                        string substring = element.Substring(i*size,size);
                        substringList.Add(substring);
                    }
                    string lastSubstring = element.Substring((partitions-1)*size);
                    substringList.Add(lastSubstring);
                    inputData.InsertRange(index,substringList);
                }

            }
            Console.WriteLine(string.Join(" ",inputData));
        }
    }
}
