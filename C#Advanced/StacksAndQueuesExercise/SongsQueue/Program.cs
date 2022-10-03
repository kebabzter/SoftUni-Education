using System;
using System.Collections.Generic;

namespace SongsQueue
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] info = Console.ReadLine()
                  .Split(", ", StringSplitOptions.RemoveEmptyEntries);
            Queue<string> songs = new Queue<string>(info);
            while (songs.Count>0)
            {
                string command = Console.ReadLine();
                if (command=="Play")
                {
                    songs.Dequeue();
                }
                else if (command=="Show")
                {
                    Console.WriteLine(string.Join(", ",songs));
                }
                else if (command.Substring(0,3)=="Add")
                {
                    string addSong = command.Substring(4);
                    if (songs.Contains(addSong))
                    {
                        Console.WriteLine($"{addSong} is already contained!");
                    }
                    else
                    {
                        songs.Enqueue(addSong);
                    }
                }
            }
            Console.WriteLine("No more songs!");
        }
    }
}
