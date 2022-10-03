using System;

namespace EncryptSortАndPrintArray
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            int[] arr = new int[n];
            for (int i = 0; i <arr.Length; i++)
            {
                string str = Console.ReadLine();
                int code = 0;
                for (int j = 0; j < str.Length; j++)
                {
                    if (str[j] == 'a' || str[j] == 'A' || str[j] == 'o' || str[j] == 'O' || str[j] == 'e' || str[j] == 'E' || str[j] == 'i' || str[j] == 'I' || str[j] == 'u' || str[j] == 'U')
                    {
                        code += str[j] * str.Length;
                    }
                    else
                    {
                        code += str[j] / str.Length;
                    }
                }
                arr[i] = code;
            }
            Array.Sort(arr);
            foreach (var item in arr)
            {
                Console.WriteLine(item);
            }
        }
    }
}
