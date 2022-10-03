using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace BookLibraryModification
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Library> libraryList = new List<Library>();
            List<Book> books = new List<Book>();
            for (int i = 0; i < n; i++)
            {
                string[] input = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries);
                DateTime date = DateTime.ParseExact(input[3], "dd.MM.yyyy", CultureInfo.InvariantCulture);
                Book book = new Book(input[0], input[1], input[2], date, input[4], double.Parse(input[5]));
                books.Add(book);
                Library library = new Library(input[1], books);
                libraryList.Add(library);
            }
            DateTime afterDate = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy", CultureInfo.InvariantCulture);
            foreach (var item in books.Where(x => x.ReleaseDate > afterDate).OrderBy(x => x.ReleaseDate).ThenBy(x=>x.Title).ToList())
            {
                Console.WriteLine($"{item.Title} -> {item.ReleaseDate:dd.MM.yyyy}");
            }

        }
    }
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public DateTime ReleaseDate { get; set; }
        public string ISBNnumber { get; set; }
        public double Price { get; set; }

        public Book(string title, string author, string publisher, DateTime date, string number, double price)
        {
            Title = title;
            Author = author;
            Publisher = publisher;
            ReleaseDate = date;
            ISBNnumber = number;
            Price = price;
        }
    }
    class Library
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
        public Library(string name, List<Book> book)
        {
            Name = name;
            Books = new List<Book>();
        }
    }
}
