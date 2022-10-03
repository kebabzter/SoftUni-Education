using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Weather
{
    class Program
    {
        static void Main(string[] args)
        {
            List<DataWeather> listData = new List<DataWeather>();
            string pattern = @".*([A-Z]{2})([0-5][0-9]?.[0-9]{0,2})([A-z]+)[|]";
            Regex regex = new Regex(pattern);
            while (true)
            {
                string data = Console.ReadLine();
                if (data=="end")
                {
                    break;
                }
                if (regex.IsMatch(data))
                {
                    var match = regex.Match(data);
                    string city = match.Groups[1].Value;
                    double temperature = double.Parse(match.Groups[2].Value);
                    string type = match.Groups[3].Value;
                    DataWeather info = new DataWeather(city,temperature,type);
                    if (!listData.Select(x=>x.City).Contains(city))
                    {
                        listData.Add(info);
                    }
                    else
                    {
                        if (!listData.Where(x=>x.City==city).Select(x=>x.Temperature).Contains(temperature))
                        {
                            listData.First(x => x.City == city).Temperature=temperature;
                            listData.First(x => x.City == city).Type = type;
                        }
                        else
                        {
                            if (!listData.Where(x => x.City == city).Select(x => x.Type).Contains(type))
                            {
                                listData.First(x => x.City == city).Type = type;
                            }
                        }
                    }
                   
                }
            }
            foreach (var item in listData.OrderBy(x=>x.Temperature))
            {
                Console.WriteLine($"{item.City} => {item.Temperature:f2} => {item.Type}");
            }
        }
    }
    class DataWeather
    {
        public string City { get; set; }
        public double Temperature { get; set; }
        public string Type { get; set; }
        public DataWeather(string city,double temperature,string type)
        {
            City = city;
            Temperature = temperature;
            Type = type;
        }
    }
}
