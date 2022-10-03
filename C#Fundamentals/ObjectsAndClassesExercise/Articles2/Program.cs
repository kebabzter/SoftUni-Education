using System;
using System.Collections.Generic;
using System.Linq;

namespace Articles2
{
    class Program
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            List<Article> listArticle = new List<Article>();
            for (int i = 0; i < n; i++)
            {
                string[] currentArticle = Console.ReadLine()
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);
                Article article = new Article(currentArticle[0], currentArticle[1], currentArticle[2]);
                listArticle.Add(article);
            }
            string criteriaSort = Console.ReadLine();
            List<Article> sortList = new List<Article>();
            if (criteriaSort=="title")
            {
                sortList = listArticle.OrderBy(x => x.Title).ToList();
            }
            else if (criteriaSort == "content")
            {
                sortList = listArticle.OrderBy(x => x.Content).ToList();
            }
            else
            {
                sortList = listArticle.OrderBy(x => x.Author).ToList();
            }
            foreach (var item in sortList)
            {
                Console.WriteLine(item);
            }
        }
    }

    class Article
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public string Author { get; set; }
        public Article(string title, string content, string author)
        {
            Title = title;
            Content = content;
            Author = author;
        }

        public override string ToString()
        {
            return $"{Title} - {Content}: {Author}";
        }
    }
}
