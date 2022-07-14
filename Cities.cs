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

                city._cityUrl = item.GetAttributeValue("href", null);

                _listOfCities.Add(city);
            }

            return _listOfCities;
        }

        public static void PrintCities(List<Cities> cities)
        {
            Console.Clear();

            for (int i = 0; i < cities.Count; i++)
            {
                MessagesViewer.WriteLine($"[{i + 1}] {cities[i]._cityName}");
            }
        }

        public static string GetCityUrl(int cityNumber)
        {
            Cities city = new Cities();

            city = _listOfCities[cityNumber - 1];

            string url = $"https:{city._cityUrl}" ?? string.Empty;

            return url;
        }
    }
}
