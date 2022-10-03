using System;
using System.Linq;

namespace RectanglePosition
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] r1 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            int[] r2 = Console.ReadLine().Split(" ", StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            Rectangle rect1 = new Rectangle(r1[0],r1[1],r1[2],r1[3]);
            Rectangle rect2 = new Rectangle(r2[0], r2[1], r2[2], r2[3]);
            if ((rect1.Left>=rect2.Left)&&(rect1.Right<=rect2.Right)&&(rect1.Top>=rect2.Top)&&(rect1.Bottom<=rect2.Bottom))
            {
                Console.WriteLine("Inside");
            }
            else
            {
                Console.WriteLine("Not inside");
            }
        }
    }
    class Rectangle
    {
        public int Top { get; set; }
        public int Left { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public decimal Right
        {
            get
            {
                return Top+Width;
            }
        }
        public decimal Bottom
        {
            get
            {
                return Left + Height;
            }
        }
        public Rectangle(int top,int left, int width, int height)
        {
            Top = top;
            Left = left;
            Width = width;
            Height = height;
        }
    }
}
