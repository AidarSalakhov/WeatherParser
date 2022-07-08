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
        private string _regionUrl { get; set; }

        public static List<Regions> _listOfRegions = new List<Regions>();

        public static List<Regions> ParseRegions(string url)
        {
            HtmlWeb htmlWeb = new HtmlWeb();

            var htmlDoc = htmlWeb.Load(url);

            var citiesReg = htmlDoc.DocumentNode.SelectNodes("//ul[@class='cities reg']//li [not(contains(@class,'cities-letter'))]");

            foreach (var item in citiesReg)
            {
                Regions region = new Regions();

                region._regionName = item.InnerText;

                Console.WriteLine(region._regionName);
                                
            }
            return _listOfRegions;
        }
    }
}
