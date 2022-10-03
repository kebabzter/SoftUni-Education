using System;
using System.Collections.Generic;
using System.Linq;

namespace Songs
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Song> listSongs = new List<Song>();

            for (int i = 0; i < n; i++)
            {
                string[] currentSong = Console.ReadLine()
                    .Split("_",StringSplitOptions.RemoveEmptyEntries);
                Song song = new Song(currentSong[0],currentSong[1],currentSong[2]);
                listSongs.Add(song);
            }

            string filter = Console.ReadLine();
            var filterList = listSongs;
            if (filter!="all")
            {
                filterList = listSongs.Where(x => x.TypeList == filter).ToList();
            }

            foreach (var item in filterList)
            {
                Console.WriteLine(item.Name);
            }
        }
    }

    class Song
    {
        public string TypeList { get; set; }
        public string Name { get; set; }
        public string Time { get; set; }
        public Song(string typeList,string name,string time)
        {
            TypeList = typeList;
            Name = name;
            Time = time;
        }
    }
}
