using System;
using System.Collections.Generic;

namespace HandsOfCards
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, List<string>> handsCards = new Dictionary<string, List<string>>();
            while (true)
            {
                string input = Console.ReadLine();
                if (input == "JOKER")
                {
                    break;
                }
                string[] inputArr = input.Split(": ",StringSplitOptions.RemoveEmptyEntries);
                string name = inputArr[0];
                string[] cards = inputArr[1].Split(", ",StringSplitOptions.RemoveEmptyEntries);
                if (!handsCards.ContainsKey(name))
                {
                    handsCards.Add(name, new List<string>());
                }
                for (int i = 0; i < cards.Length; i++)
                {
                    if (!handsCards[name].Contains(cards[i]))
                    {
                        handsCards[name].Add(cards[i]);
                    }
                }
            }
            foreach (var item in handsCards)
            {
                Console.WriteLine($"{item.Key}: {SumCards(item.Value)}");
            }
        }
        static int SumCards(List<string> cards)
        {
            int sum = 0;
            int power = 0;
            int type = 0;
            for (int i = 0; i < cards.Count; i++)
            {
                if (cards[i].Length==3)
                {
                    power = 10;
                }
                else if (cards[i].Substring(0,1)=="J")
                {
                    power = 11;
                }
                else if (cards[i].Substring(0, 1) == "Q")
                {
                    power = 12;
                }
                else if (cards[i].Substring(0, 1) == "K")
                {
                    power = 13;
                }
                else if (cards[i].Substring(0, 1) == "A")
                {
                    power = 14;
                }
                else
                {
                    power = int.Parse(cards[i].Substring(0, 1));
                }

                string symbolType = cards[i].Substring(cards[i].Length-1);
                if (symbolType=="C")
                {
                    type = 1;
                }
                else if (symbolType == "D")
                {
                    type = 2;
                }
                else if (symbolType == "H")
                {
                    type = 3;
                }
                else if (symbolType == "S")
                {
                    type = 4;
                }
                sum += power * type;
            }
            return sum;
        }
    }
}
