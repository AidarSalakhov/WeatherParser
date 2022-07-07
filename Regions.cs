using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WeatherParser
{
    internal class Regions
    {
        private string _regionName { get; set; }
        private string _regionNameFirstLetter { get; set; }
        private string _regionUrl { get; set; }

        public static List<Regions> _listOfRegions = new List<Regions>();

        public Regions(string regionName, string regionNameFirstLetter, string regionUrl)
        {
            _regionName = regionName;
            _regionNameFirstLetter = regionNameFirstLetter;
            _regionUrl = regionUrl;

        }
              
        public static List<Regions> ParseRegions(string url)
        {
            HtmlWeb htmlWeb = new HtmlWeb();

            var htmlDoc = htmlWeb.Load(url);

            var node = htmlDoc.DocumentNode.SelectNodes("//ul[@class='cities reg']//li//a");

            foreach (HtmlNode line in node)
            {
                string outputText = line.InnerText;

                Console.WriteLine(outputText);
            }

            return _listOfRegions;
        }
    }
}
