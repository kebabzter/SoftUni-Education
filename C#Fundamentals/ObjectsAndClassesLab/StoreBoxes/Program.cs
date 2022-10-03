using System;
using System.Collections.Generic;
using System.Linq;

namespace StoreBoxes
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Box> listBox = new List<Box>();
            while (true)
            {
                string input = Console.ReadLine();
                
                if (input=="end")
                {
                    break;
                }

                string[] currentBox = input.Split(" ", StringSplitOptions.RemoveEmptyEntries);
                string serialNumber = currentBox[0];
                string itemName = currentBox[1];
                int itemQuantity = int.Parse(currentBox[2]);
                decimal itemPrice = decimal.Parse(currentBox[3]);
                decimal priceBox = itemQuantity * itemPrice;
                Box box = new Box();
                box.SerialNumber = serialNumber;
                box.Item.Name = itemName;
                box.Item.Price = itemPrice;
                box.Quantity = itemQuantity;
                box.PriceBox = priceBox;
                listBox.Add(box);
            }

            List<Box> listSort = listBox.OrderByDescending(x => x.PriceBox).ToList();
            foreach (var sortBox in listSort)
            {
                Console.WriteLine(sortBox.SerialNumber);
                Console.WriteLine($"-- {sortBox.Item.Name} - ${sortBox.Item.Price:f2}: {sortBox.Quantity}");
                Console.WriteLine($"-- ${sortBox.PriceBox:f2}");
            }
        }
    }

    class Item
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
    }

    class Box
    {
        public Box()
        {
            Item = new Item();
        }
        public string SerialNumber { get; set; }
        public Item Item { get; set; }
        public int Quantity { get; set; }
        public decimal PriceBox { get; set; }
    }
}
