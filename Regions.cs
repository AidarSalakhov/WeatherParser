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
                              
        public static List<Regions> ParseRegions(string url)
        {
            HtmlWeb htmlWeb = new HtmlWeb();

            var htmlDoc = htmlWeb.Load(url);

            var node = htmlDoc.DocumentNode.SelectNodes("//ul[@class='cities reg']");

            int regionsCount = node.Count();

            foreach (var item in node)
            {
                Regions region = new Regions();

                region._regionNameFirstLetter = item.SelectSingleNode(".//li[@class='cities-letter']").InnerText;

                    Console.WriteLine(region._regionNameFirstLetter);      

                region._regionName = item.SelectSingleNode(".//li").InnerText;

                Console.WriteLine(region._regionName);

                //region._regionUrl = item.SelectSingleNode(".//li//a[@href='resumeListItem']").InnerText;

                _listOfRegions.Add(region);
            }


            return _listOfRegions;
        }
    }
}
