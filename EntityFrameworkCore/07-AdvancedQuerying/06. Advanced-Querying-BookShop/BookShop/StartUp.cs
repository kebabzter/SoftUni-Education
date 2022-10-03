namespace BookShop
{
    using BookShop.Models.Enums;
    using Data;
    using Initializer;
    using System;
    using System.Linq;
    using System.Text;

    public class StartUp
    {
        public static void Main()
        {
            using var db = new BookShopContext();
            DbInitializer.ResetDatabase(db);

            //2. Age Restriction
            //  string ar = Console.ReadLine();
            //  string result = GetBooksByAgeRestriction(db, ar);
            //  Console.WriteLine(result);

            //3. Golden Books
            // string result = GetGoldenBooks(db);
            // Console.WriteLine(result);

            //4. Books by Price
            //string result = GetBooksByPrice(db);
            // Console.WriteLine(result);

            //5. Not Released In
            //int year = int.Parse(Console.ReadLine());
            //string result = GetBooksNotReleasedIn(db,year);
            //Console.WriteLine(result);

            //6. Book Titles by Category
            //string categories = Console.ReadLine();
            //string result = GetBooksByCategory(db, categories);
            //Console.WriteLine(result);

            //7.Released Before Date
            //string date = Console.ReadLine();
            //string result = GetBooksReleasedBefore(db, date);
            //Console.WriteLine(result);

            //8. Author Search
            //string str = Console.ReadLine();
            //string result = GetAuthorNamesEndingIn(db, str);
            //Console.WriteLine(result);

            //9. Book Search
            //string str = Console.ReadLine();
            //string result = GetBookTitlesContaining(db, str);
            //Console.WriteLine(result);

            //10. Book Search by Author
            //string str = Console.ReadLine();
            //string result = GetBooksByAuthor(db, str);
            //Console.WriteLine(result);

            //11. Count Books
            //int lenth = int.Parse(Console.ReadLine());
            //int result = CountBooks(db,lenth);
            //Console.WriteLine(result);

            //12. Total Book Copies
            //string result = CountCopiesByAuthor(db);
            //Console.WriteLine(result);

            //13. Profit by Category
            //string result = GetTotalProfitByCategory(db);
            //Console.WriteLine(result);

            //14. Most Recent Books
            //string result = GetMostRecentBooks(db);
            //Console.WriteLine(result);

            //15. Increase Prices
            //IncreasePrices(db);

            //16. Remove Books
            int result =RemoveBooks(db);
            Console.WriteLine(result);
        }

        //16. Remove Books
        public static int RemoveBooks(BookShopContext context)
        {
            var booksForDelete = context.Books
                .Where(c => c.Copies < 4200)
                .ToArray();

            context.RemoveRange(booksForDelete);
            context.SaveChanges();

            return booksForDelete.Count();
        }

        //15. Increase Prices
        public static void IncreasePrices(BookShopContext context)
        {
            var booksBefore2010 = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year < 2010);

            foreach (var book in booksBefore2010)
            {
                book.Price += 5;
            }

            context.SaveChanges();
        }

        //14. Most Recent Books
        public static string GetMostRecentBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context.Categories
                .Select(c => new
                {
                    CategorieName = c.Name,
                    MostRecentBooks = c.CategoryBooks
                                     .Select(b => b.Book)
                                     .OrderByDescending(b=>b.ReleaseDate)
                                     .Select(b=>new 
                                     {
                                         bookTitle=b.Title,
                                         releaseYear=b.ReleaseDate.Value.Year,
                                     })
                                     .Take(3)
                                     .ToArray()
                })
                .OrderBy(c => c.CategorieName)
                .ToArray();

            foreach (var categorie in categories)
            {
                sb.AppendLine($"--{categorie.CategorieName}");
                foreach (var book in categorie.MostRecentBooks)
                {
                    sb.AppendLine($"{book.bookTitle} ({book.releaseYear})");
                }
            }

            return sb.ToString().TrimEnd();
        }

        //13. Profit by Category
        public static string GetTotalProfitByCategory(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var categories = context.Categories
                .Select(c => new
                {
                    CategorieName = c.Name,
                    Profit = c.CategoryBooks.Sum(b=>b.Book.Copies*b.Book.Price)
                })
                .OrderByDescending(c=>c.Profit)
                .ThenBy(c=>c.CategorieName)
                .ToArray();

            foreach (var categorie in categories)
            {
                sb.AppendLine($"{categorie.CategorieName} ${categorie.Profit:F2}");
            }

            return sb.ToString().TrimEnd();
        }

        //12. Total Book Copies
        public static string CountCopiesByAuthor(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors
                .Select(a => new
                {
                    FullName = $"{a.FirstName} {a.LastName}",
                    Copies=a.Books.Sum(c=>c.Copies)
                })
                .OrderByDescending(c=>c.Copies)
                .ToArray();

            foreach (var author in authors)
            {
                sb.AppendLine($"{author.FullName} - {author.Copies}");
            }

            return sb.ToString().TrimEnd();
        }

        //11. Count Books
        public static int CountBooks(BookShopContext context, int lengthCheck)
        {
            var countBooks = context.Books
               .Where(b => b.Title.Length > lengthCheck)
               .Count();
               
            return countBooks;
        }

        //10. Book Search by Author
        public static string GetBooksByAuthor(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books
                .Where(b => b.Author.LastName.ToLower().StartsWith(input.ToLower()))
                .OrderBy(b => b.BookId)
                .Select(b => new 
                {
                    Title=b.Title,
                    Author=$"{b.Author.FirstName} {b.Author.LastName}"
                })
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} ({book.Author})");
            }

            return sb.ToString().TrimEnd();
        }

        //9. Book Search
        public static string GetBookTitlesContaining(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var books = context.Books.ToArray()
                .Where(b => b.Title.ToLower().Contains(input.ToLower()))
                .Select(b => b.Title)
                .OrderBy(b => b)
                .ToArray();

            foreach (var book in books)
            {
                sb.AppendLine(book);
            }

            return sb.ToString().TrimEnd();
        }

        //8. Author Search
        public static string GetAuthorNamesEndingIn(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            var authors = context.Authors.ToArray()
                .Where(fn=>fn.FirstName.ToLower().EndsWith(input.ToLower()))
                .Select(fn=>$"{fn.FirstName} {fn.LastName}")
                .OrderBy(b => b)
                .ToArray();

            foreach (var author in authors)
            {
                sb.AppendLine(author);
            }

            return sb.ToString().TrimEnd();
        }

        //7. Released Before Date
        public static string GetBooksReleasedBefore(BookShopContext context, string date)
        {
            var dateParts = date.Split("-", StringSplitOptions.RemoveEmptyEntries);

            int day = int.Parse(dateParts[0]);
            int month = int.Parse(dateParts[1]);
            int year = int.Parse(dateParts[2]);

            var dateTime = new DateTime(year, month, day);

            var books = context.Books
                .Where(x => x.ReleaseDate < dateTime)
                .OrderByDescending(x => x.ReleaseDate)
                .Select(x => new
                {
                    x.Title,
                    x.Price,
                    x.EditionType,
                })
                .ToList();

            var sb = new StringBuilder();

            foreach (var book in books)
            {
                sb.AppendLine($"{book.Title} - {book.EditionType} - ${book.Price:f2}");
            }

            return sb.ToString().TrimEnd();
        }

        //6. Book Titles by Category
        public static string GetBooksByCategory(BookShopContext context, string input)
        {
            StringBuilder sb = new StringBuilder();

            string[] categories = input
               .Split(" ", StringSplitOptions.RemoveEmptyEntries)
               .Select(x => x.ToLower())
               .ToArray();

            var booksTitle = context.Books
                .Where(c=>c.BookCategories.Any(c => categories.Contains(c.Category.Name.ToLower())))
                .Select(b => b.Title)
                .OrderBy(b=>b)
                .ToArray();

            return string.Join(Environment.NewLine, booksTitle);
        }

        //5. Not Released In
        public static string GetBooksNotReleasedIn(BookShopContext context, int year)
        {
            StringBuilder sb = new StringBuilder();
            var booksTitle = context.Books
                .Where(b => b.ReleaseDate.HasValue && b.ReleaseDate.Value.Year!=year)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            foreach (var book in booksTitle)
            {
                sb.AppendLine(book);
            }
            return sb.ToString().TrimEnd();
        }

        //4. Books by Price
        public static string GetBooksByPrice(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var booksTitle = context.Books
                .Where(b => b.Price > 40)
                .OrderByDescending(b => b.Price)
                .Select(b => new
                {
                    Title = b.Title,
                    Price=b.Price
                })
                .ToArray();

            foreach (var book in booksTitle)
            {
                sb.AppendLine($"{book.Title} - ${book.Price:f2}");
            }
            return sb.ToString().TrimEnd();
        }


        //3. Golden Books
        public static string GetGoldenBooks(BookShopContext context)
        {
            StringBuilder sb = new StringBuilder();
            var booksTitle = context.Books
                .Where(b => b.EditionType==EditionType.Gold && b.Copies < 5000)
                .OrderBy(b => b.BookId)
                .Select(b => b.Title)
                .ToArray();

            foreach (var title in booksTitle)
            {
                sb.AppendLine(title);
            }
            return sb.ToString().TrimEnd();
        }

        //2. Age Restriction
        public static string GetBooksByAgeRestriction(BookShopContext context, string command)
        {
            StringBuilder sb = new StringBuilder();
            AgeRestriction ar=Enum.Parse<AgeRestriction>(command,true);
            var booksTitle = context.Books
                .Where(b => b.AgeRestriction == ar)
                .OrderBy(b => b.Title)
                .Select(b => b.Title)
                .ToArray();

            foreach (var title in booksTitle)
            {
                sb.AppendLine(title);
            }
            return sb.ToString().TrimEnd();
        }
    }
}
