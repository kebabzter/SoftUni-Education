namespace BookShop.DataProcessor
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Globalization;
    using System.IO;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;
    using BookShop.Data.Models;
    using BookShop.Data.Models.Enums;
    using BookShop.DataProcessor.ImportDto;
    using Data;
    using Newtonsoft.Json;
    using ValidationContext = System.ComponentModel.DataAnnotations.ValidationContext;

    public class Deserializer
    {
        private const string ErrorMessage = "Invalid data!";

        private const string SuccessfullyImportedBook
            = "Successfully imported book {0} for {1:F2}.";

        private const string SuccessfullyImportedAuthor
            = "Successfully imported author - {0} with {1} books.";

        public static string ImportBooks(BookShopContext context, string xmlString)
        {
            var output = new StringBuilder();
            var xmlSerializer = new XmlSerializer(typeof(BookXmlInputModel[]), new XmlRootAttribute("Books"));
            var books = (BookXmlInputModel[])xmlSerializer.Deserialize(new StringReader(xmlString));

            foreach (var xmlBook in books)
            {
                if (!IsValid(xmlBook))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                //object genreObj;
                //bool isGenreObjValid = Enum.TryParse(typeof(Genre), xmlBook.Genre, out genreObj);

                //if (!isGenreObjValid)
                //{
                //    output.AppendLine(ErrorMessage);
                //    continue;
                //}

                DateTime publishedOn;

                var isPublishedOnValid = DateTime.TryParseExact(xmlBook.PublishedOn, "MM/dd/yyyy",
                    CultureInfo.InvariantCulture, DateTimeStyles.None, out publishedOn);

                if (!isPublishedOnValid)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var book = new Book
                {
                    Name = xmlBook.Name,
                    Genre = (Genre)xmlBook.Genre,
                    Price = xmlBook.Price,
                    Pages = xmlBook.Pages,
                    PublishedOn = publishedOn
                };

                context.Books.Add(book);
                output.AppendLine(String.Format(SuccessfullyImportedBook, book.Name, book.Price));
            }

            context.SaveChanges();
            return output.ToString();
        }

        public static string ImportAuthors(BookShopContext context, string jsonString)
        {
            
            var output = new StringBuilder();
            var authors = JsonConvert
                .DeserializeObject<IEnumerable<AuthorJsonInputModel>>(jsonString);

            foreach (var jsonAuthor in authors)
            {
                if (!IsValid(jsonAuthor))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                if (context.Authors.Any(a => a.Email == jsonAuthor.Email))
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }

                var author = new Author()
                {
                    FirstName = jsonAuthor.FirstName,
                    LastName = jsonAuthor.LastName,
                    Phone = jsonAuthor.Phone,
                    Email = jsonAuthor.Email,
                    
                   
                };

                foreach (var book in jsonAuthor.Books)
                {
                    var bookDb = context.Books.FirstOrDefault(x => book.Id == x.Id);
                    if (bookDb != null)
                    {
                        continue;
                    }

                    author.AuthorsBooks.Add(new AuthorBook
                    {
                        Author = author,
                        Book = bookDb,
                    });
                    
                }

                if (author.AuthorsBooks.Count == 0)
                {
                    output.AppendLine(ErrorMessage);
                    continue;
                }
                context.Authors.Add(author);
                output.AppendLine(string.Format(SuccessfullyImportedAuthor, (author.FirstName + " " + author.LastName), author.AuthorsBooks.Count));
            }

            context.SaveChanges();
            return output.ToString();
        }

        private static bool IsValid(object dto)
        {
            var validationContext = new ValidationContext(dto);
            var validationResult = new List<ValidationResult>();

            return Validator.TryValidateObject(dto, validationContext, validationResult, true);
        }
    }
}