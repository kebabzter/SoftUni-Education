using System;
using System.Linq;

namespace Lift
{
    class Program
    {
        static void Main(string[] args)
        {
            int peopleWaitingForLyft = int.Parse(Console.ReadLine());
            int[] wagon = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int peopleOnTheCurrentWagon = 0;
            int peopleonTheLyft = 0;
            bool NoMorePeople = false;
            for (int i = 0; i < wagon.Length; i++)
            {
                while (wagon[i] < 4)
                {
                    wagon[i]++;
                    peopleOnTheCurrentWagon++;
                    if (peopleonTheLyft + peopleOnTheCurrentWagon == peopleWaitingForLyft)
                    {
                        NoMorePeople = true;
                        break;
                    }
                }
                peopleonTheLyft += peopleOnTheCurrentWagon;
                if (NoMorePeople)
                {
                    break;
                }
                peopleOnTheCurrentWagon = 0;
            }
            if (peopleWaitingForLyft > peopleonTheLyft)
            {
                Console.WriteLine($"There isn't enough space! {peopleWaitingForLyft - peopleonTheLyft} people in a queue!");
                Console.WriteLine(string.Join(" ", wagon));
            }
            else if (peopleWaitingForLyft < wagon.Length * 4 && wagon.Any(w => w < 4))
            {
                Console.WriteLine("The lift has empty spots!");
                Console.WriteLine(string.Join(" ", wagon));
            }
            else if (wagon.All(w => w == 4) && NoMorePeople == true)
            {
                Console.WriteLine(string.Join(" ", wagon));
            }
        }
    }
}
