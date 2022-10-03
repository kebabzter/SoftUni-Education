using System;

namespace BPMCounter
{
    class Program
    {
        static void Main(string[] args)
        {
            int bpm = int.Parse(Console.ReadLine());
            int beats = int.Parse(Console.ReadLine());
            decimal bars = Math.Round((decimal)beats / 4,1);
            decimal time = (decimal)beats/bpm * 60;
            decimal minutes = Math.Floor(time / 60);
            decimal secounds = Math.Truncate(time % 60);
            Console.WriteLine($"{bars} bars - {minutes}m {secounds}s");
        }
    }
}
