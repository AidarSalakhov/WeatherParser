using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WeatherParser
{
    internal class CitiesParser
    {
        public static List<Cities> ParseCities()
        {
            List<Cities> listOfCities = new List<Cities>();

            var html = @"https://world-weather.ru/pogoda/russia/adygea/";

            HtmlWeb web = new HtmlWeb();

            var htmlDoc = web.Load(html);

            var node = htmlDoc.DocumentNode.SelectNodes("//li[@class='city-block']");

            foreach (HtmlNode hn in node)
            {
                string outputText = hn.InnerText.Trim();

                Console.WriteLine(outputText);
            }

            return listOfCities;
        }
        
    }
}
