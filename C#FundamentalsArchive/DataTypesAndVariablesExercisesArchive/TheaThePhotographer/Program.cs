using System;

namespace TheaThePhotographer
{
    class Program
    {
        static void Main(string[] args)
        {
            ulong numberOfPictures = ulong.Parse(Console.ReadLine());
            ulong secondsForEveryPicture = ulong.Parse(Console.ReadLine());
            ulong pictureFaktor = ulong.Parse(Console.ReadLine());
            ulong secondsForFilterPicture = ulong.Parse(Console.ReadLine());
            ulong firstOperationTime = numberOfPictures * secondsForEveryPicture;
            ulong timeForFilter = (ulong)Math.Ceiling((pictureFaktor * 0.01) * numberOfPictures);
            ulong secondOperationTime = timeForFilter * secondsForFilterPicture;
            ulong timeAllInSeconds = firstOperationTime + secondOperationTime;
            TimeSpan time = TimeSpan.FromSeconds(timeAllInSeconds);
            string totalTime = time.ToString(@"d\:hh\:mm\:ss");
            Console.WriteLine(totalTime);
        }
    }
}
