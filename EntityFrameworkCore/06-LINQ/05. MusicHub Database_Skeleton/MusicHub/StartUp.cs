namespace MusicHub
{
    using System;
    using System.Globalization;
    using System.Linq;
    using System.Text;
    using Data;
    using Initializer;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            MusicHubDbContext context = 
                new MusicHubDbContext();

            DbInitializer.ResetDatabase(context);

            // string result=ExportAlbumsInfo(context, 9);
            string result = ExportSongsAboveDuration(context,4);
            Console.WriteLine(result);
        }

        public static string ExportAlbumsInfo(MusicHubDbContext context, int producerId)
        {
            var info = context.Albums.ToArray()
                .Where(a => a.ProducerId == producerId)
                .Select(a => new
                {
                    AlbumName = a.Name,
                    ReleaseDate=a.ReleaseDate,
                    ProducerName=a.Producer.Name,
                    Songs=a.Songs
                    .ToArray()
                    .Select(s=>new 
                    {
                        SongName=s.Name,
                        Price=s.Price,
                        Writer=s.Writer.Name
                    })
                    .OrderByDescending(s=>s.SongName)
                    .ThenBy(s=>s.Writer)
                    .ToArray(),
                    TotalAlbumPrice=a.Price
                })
                .OrderByDescending(a=>a.TotalAlbumPrice)
                .ToArray();

            StringBuilder sb = new StringBuilder();
            foreach (var album in info)
            {
                sb.AppendLine($"-AlbumName: {album.AlbumName}");
                sb.AppendLine($"-ReleaseDate: {album.ReleaseDate.ToString("MM/dd/yyyy",CultureInfo.InvariantCulture)}");
                sb.AppendLine($"-ProducerName: {album.ProducerName}");
                sb.AppendLine("-Songs:");
                int i = 0;
                foreach (var song in album.Songs)
                {
                    i++;
                    sb.AppendLine($"---#{i}");
                    sb.AppendLine($"---SongName: {song.SongName}");
                    sb.AppendLine($"---Price: {song.Price:f2}");
                    sb.AppendLine($"---Writer: {song.Writer}");
                }
                sb.AppendLine($"-AlbumPrice: {album.TotalAlbumPrice:f2}");
            }

            return sb.ToString().TrimEnd();

        }

        public static string ExportSongsAboveDuration(MusicHubDbContext context, int duration)
        {
            StringBuilder sb = new StringBuilder();
            var info = context.Songs.ToArray()
                .Where(s => s.Duration.TotalSeconds > duration)
                .Select(s => new
                {
                    SongName=s.Name,
                    Writer=s.Writer.Name,
                    Performer=s.SongPerformers.ToArray()
                              .Select(p=>$"{p.Performer.FirstName} {p.Performer.LastName}").FirstOrDefault(),
                    AlbumProducer=s.Album.Producer.Name,
                    Duration=s.Duration
                })
                .OrderBy(s=>s.SongName)
                .ThenBy(s=>s.Writer)
                .ThenBy(s=>s.Performer)
                .ToArray();

            int i = 0;
            foreach (var song in info)
            {
                i++;
                sb.AppendLine($"-Song #{i}");
                sb.AppendLine($"---SongName: {song.SongName}");
                sb.AppendLine($"---Writer: {song.Writer}");
                sb.AppendLine($"---Performer: {song.Performer}");
                sb.AppendLine($"---AlbumProducer: {song.AlbumProducer}");
                sb.AppendLine($"---Duration: {song.Duration.ToString("c",CultureInfo.InvariantCulture)}");
            }
            return sb.ToString().TrimEnd();
        }
    }
}
