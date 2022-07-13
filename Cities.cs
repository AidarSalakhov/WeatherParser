using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WeatherParser
{
    internal class Cities
    {
        private string? _cityName;

        private string? _cityUrl;

        public static List<Cities> _listOfCities = new List<Cities>();

        public static List<Cities> ParseCities(string url)
        {
            HtmlWeb htmlWeb = new HtmlWeb();

            var htmlDoc = htmlWeb.Load(url);

            var cityBlock = htmlDoc.DocumentNode.SelectNodes("//li[@class='city-block']//a[@href]");

            foreach (var item in cityBlock)
            {
                Cities city = new Cities();

                city._cityName = item.InnerText;

                Console.WriteLine(city._cityName);

                city._cityUrl = item.GetAttributeValue("href", null);

                Console.WriteLine(city._cityUrl);

                _listOfCities.Add(city);
            }

            return _listOfCities;
        }
    }
}
