using System;
using System.IO;
using System.Threading.Tasks;

namespace LineNumbers
{
    class Program
    {
        static async Task Main(string[] args)
        {
            using (StreamReader str = new StreamReader("input.txt"))
            {
                string line = await str.ReadLineAsync();
                using (StreamWriter wrt = new StreamWriter("output.txt"))
                {
                    int count = 1;
                    while (line != null)
                    {
                        await wrt.WriteLineAsync($"{count}. {line}");
                        count++;
                        line = await str.ReadLineAsync();
                    }
                }

            }
        }
    }
}
