using System;

namespace HTML
{
    class Program
    {
        static void Main(string[] args)
        {
            string title = Console.ReadLine();
            string content = Console.ReadLine();
            Console.WriteLine("<h1>");
            Console.WriteLine($"    {title}");
            Console.WriteLine("</h1>");
            Console.WriteLine("<article>");
            Console.WriteLine($"    {content}");
            Console.WriteLine("</article>");
            while (true)
            {
                string comments = Console.ReadLine();
                if (comments== "end of comments")
                {
                    break;
                }
                Console.WriteLine("<div>");
                Console.WriteLine($"    {comments}");
                Console.WriteLine("</div>");
            }
        }
    }
}
