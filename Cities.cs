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
        
        private string _region { get; set; }
        private string _regionIdentificationLetter { get; set; }
        private string _city { get; set; }
        private string _weather { get; set; }

        private static List<Cities> _listOfCities = new List<Cities>();

        public Cities(string region, string regionIdentificationLetter, string city, string weather)
        {
            _region = region;
            _regionIdentificationLetter = regionIdentificationLetter;
            _city = city;
            _weather = weather;
        }

        public static Cities GetCity(int index)
        {
            return _listOfCities[index];
        }
        public static void SetCity(Cities city)
        {
            _listOfCities.Add(city);
        }

        public static List<Cities> GetCitiesList(int index)
        {
            return _listOfCities;
        }

        public static void SetCitiesList(List<Cities> listOfCities)
        {
            _listOfCities = listOfCities;
        }

        public static List<Cities> ParseCities()
        {
            List<Cities> listOfCities = new List<Cities>();

            var html = "https://world-weather.ru/pogoda/russia/adygea/";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            var node = htmlDoc.DocumentNode.SelectNodes("//li[@class='city-block']");

            foreach (HtmlNode hn in node)
            {
                string outputText = hn.InnerText;

                Console.WriteLine(outputText);
            }

            return listOfCities;
        }


    }
}
