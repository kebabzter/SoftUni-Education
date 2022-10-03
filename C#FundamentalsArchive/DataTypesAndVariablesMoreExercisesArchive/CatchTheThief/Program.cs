using System;

namespace CatchTheThief
{
    class Program
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();
            int n = int.Parse(Console.ReadLine());
            string maxNum = string.Empty;
                switch (type)
                {
                    case "sbyte":
                    sbyte maxSbyte = sbyte.MinValue;
                    for (int i = 0; i < n; i++)
                    {
                        if (sbyte.TryParse(Console.ReadLine(), out sbyte sbyteNum))
                        {
                            if (sbyteNum>maxSbyte)
                            {
                                maxSbyte =sbyteNum;
                            }
                        }
                    }
                    maxNum = maxSbyte.ToString();
                        break;
                    case "int":
                    int maxInt = int.MinValue;
                    for (int i = 0; i < n; i++)
                    {
                        if (int.TryParse(Console.ReadLine(), out int intNum))
                        {
                            if (intNum > maxInt)
                            {
                                maxInt = intNum;
                            }
                        }
                    }
                    maxNum = maxInt.ToString();
                    break;
                    case "long":
                    long maxLong = long.MinValue;
                    for (int i = 0; i < n; i++)
                    {
                        if (long.TryParse(Console.ReadLine(), out long longNum))
                        {
                            if (longNum > maxLong)
                            {
                                maxLong = longNum;
                            }
                        }
                    }
                    maxNum = maxLong.ToString();
                    break;
                }
            Console.WriteLine(maxNum);
        }
    }
}
