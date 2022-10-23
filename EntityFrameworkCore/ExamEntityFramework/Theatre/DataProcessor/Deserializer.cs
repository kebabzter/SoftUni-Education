namespace Theatre.DataProcessor
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using Theatre.Data;
    using Theatre.Data.Models;
    using Theatre.Data.Models.Enums;
    using Theatre.DataProcessor.ImportDto;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfulImportPlay
            = "Successfully imported {0} with genre {1} and a rating of {2}!";

        private const string SuccessfulImportActor
            = "Successfully imported actor {0} as a {1} character!";

        private const string SuccessfulImportTheatre
            = "Successfully imported theatre {0} with #{1} tickets!";

        public static string ImportPlays(TheatreContext context, string xmlString)
        {
            var output = new StringBuilder();
            var xmlSerializer = new XmlSerializer
                (typeof(PlaysXmlImportDto[]),
                new XmlRootAttribute("Plays"));

            var plays = (PlaysXmlImportDto[])xmlSerializer.Deserialize
                (new StringReader(xmlString));

            foreach (var xmlPlay in plays)
            {
                if (!IsValid(xmlPlay))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }




                TimeSpan timeSpan;
                bool isTimeSpanValid = TimeSpan.TryParse(xmlPlay.Duration,
                     out timeSpan);

                //if (!isTimeSpanValid)
                //{
                //    output.AppendLine(ErrorMessage);
                //    continue;
                //}

                if (timeSpan.TotalMinutes < 60)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                object genreObj;
                bool isGenreObjValid = Enum.TryParse(typeof(Genre), xmlPlay.Genre, out genreObj);
                if (!isGenreObjValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var play = new Play()
                {
                    Title = xmlPlay.Title,
                    Duration = timeSpan,
                    Rating = xmlPlay.Rating,
                    Genre = (Genre)genreObj,
                    Description = xmlPlay.Description,
                    Screenwriter = xmlPlay.Screenwriter,
                };

                context.Plays.Add(play);
                output.AppendLine(String.Format(SuccessfulImportPlay, play.Title, play.Genre, play.Rating));
            }


            context.SaveChanges();
            return output.ToString();
        }

        public static string ImportCasts(TheatreContext context, string xmlString)
        {
            var output = new StringBuilder();

            var xmlSerializer = new XmlSerializer
                (typeof(CastsXmlImportDto[]),
                new XmlRootAttribute("Casts"));

            var casts = (CastsXmlImportDto[])xmlSerializer.Deserialize
                (new StringReader(xmlString));

            foreach (var xmlCast in casts)
            {
                if (!IsValid(xmlCast))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var cast = new Cast()
                {
                    FullName = xmlCast.FullName,
                    IsMainCharacter = xmlCast.IsMainCharacter,
                    PhoneNumber = xmlCast.PhoneNumber,
                    PlayId = xmlCast.PlayId,
                };

                string lesserOrMain = "";
                if (xmlCast.IsMainCharacter)
                {
                    lesserOrMain = "main";
                }
                else
                {
                    lesserOrMain = "lesser";
                }

                context.Casts.Add(cast);
                output.AppendLine(String.Format(SuccessfulImportActor, cast.FullName, lesserOrMain));
            }    

            context.SaveChanges();
            return output.ToString();
        }

        public static string ImportTtheatersTickets(TheatreContext context, string jsonString)
        {
            var output = new StringBuilder();
            var theatres = JsonConvert
                .DeserializeObject<IEnumerable<TheatresTicketsJsonImportDto>>(jsonString);

            foreach (var jsonTheatre in theatres)
            {
                if (!IsValid(jsonTheatre))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var theatre = new Theatre()
                {
                    Name = jsonTheatre.Name,
                    NumberOfHalls = jsonTheatre.NumberOfHalls,
                    Director = jsonTheatre.Director,
                    
                };

                foreach (var ticket in jsonTheatre.Tickets)
                {

                    if (!IsValid(ticket))
                    {
                        output.AppendLine(ErrorMessage);
                        continue;
                    }

                    theatre.Tickets.Add(new Ticket
                    {
                        Price = ticket.Price,
                        RowNumber = ticket.RowNumber,
                        PlayId = ticket.PlayId
                    });
                }

                context.Theatres.Add(theatre);
                output.AppendLine(String.Format(SuccessfulImportTheatre, theatre.Name, theatre.Tickets.Count()));

            }

            context.SaveChanges();
            return output.ToString();
        }


        private static bool IsValid(object obj)
        {
            var validator = new ValidationContext(obj);
            var validationRes = new List<ValidationResult>();

            var result = Validator.TryValidateObject(obj, validator, validationRes, true);
            return result;
        }
    }
}
