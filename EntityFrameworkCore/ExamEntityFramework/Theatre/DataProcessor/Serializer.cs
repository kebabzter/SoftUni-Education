namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.DataProcessor.ExportDto;

    public class Serializer
    {
        public static string ExportTheatres(TheatreContext context, int numbersOfHalls)
        {
            var data = context.Theatres.ToList().Where(t => t.NumberOfHalls >= numbersOfHalls && t.Tickets.Count() >= 20)
                .Select(t => new
                {
                    Name = t.Name,
                    Halls = t.NumberOfHalls,
                    TotalIncome = t.Tickets.Where(x => x.RowNumber >= 1 && x.RowNumber <= 5).Sum(p => p.Price),
                    Tickets = t.Tickets.Where(x => x.RowNumber >= 1 && x.RowNumber <= 5).Select(tk => new
                    {
                        Price = decimal.Parse(tk.Price.ToString("f2")),
                        RowNumber = tk.RowNumber
                    }).ToArray()
                    .OrderByDescending(x => x.Price)
                }).OrderByDescending(th => th.Halls)
                .ThenBy(th => th.Name);

            return JsonConvert.SerializeObject(data,Formatting.Indented);
        }

        public static string ExportPlays(TheatreContext context, double rating)
        {
            StringBuilder sb = new StringBuilder();

            XmlSerializer xmlSerializer = 
                new XmlSerializer(typeof(PlaysXmlExportDto[]), new XmlRootAttribute("Plays"));
            StringWriter sw = new StringWriter(sb);
            XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
            ns.Add("", "");


            var data = context.Plays.ToArray()
                .Where(x => x.Rating <= rating)
                .Select(p => new PlaysXmlExportDto
                {
                    Title = p.Title,
                    Duration = p.Duration.ToString(),
                    Rating = p.Rating.ToString(),
                    Genre = p.Genre.ToString(),
                    Actors = p.Casts.Where(ch => ch.IsMainCharacter == true).Select(x => new ActorXmlExportDto
                    {
                        FullName = x.FullName,
                        MainCharacter = $"Plays main character in '{x.Play.Title}'."
                    }).OrderByDescending(a => a.FullName).ToArray()
                }).OrderBy(p => p.Title)
                .ThenByDescending(p => p.Genre)
                .ToArray();

            foreach (var play in data)
            {
                if (play.Rating == "0")
                {
                    play.Rating = "Premier";
                }
            }

            xmlSerializer.Serialize(sw, data,ns);
            return sb.ToString();
        }
    }
}
