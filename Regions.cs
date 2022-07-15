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
        private string? _regionName { get; set; }
        private string? _regionUrl { get; set; }

        public static List<Regions> listOfRegions = new List<Regions>();

        public static List<Regions> ParseRegions(string url)
        {
            HtmlWeb htmlWeb = new HtmlWeb();

            var htmlDoc = htmlWeb.Load(url);

            var citiesReg = htmlDoc.DocumentNode.SelectNodes("//ul[@class='cities reg']//li[not(contains(@class,'cities-letter'))]//a[@href]");

            foreach (var item in citiesReg)
            {
                Regions region = new Regions();

                region._regionName = item.InnerText;

                region._regionUrl = item.GetAttributeValue("href", null);

                listOfRegions.Add(region);
            }

            return listOfRegions;
        }

        public static void PrintRegions(List<Regions> regions)
        {
            Console.Clear();

            int index = 1;

            for (int i = 0; i <= regions.Count / 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (index > regions.Count)
                    {
                        continue;
                    }

                    MessagesViewer.Write("[{0,2}] {1,-32}", index, regions[index - 1]._regionName);

                    index++;
                }

                MessagesViewer.WriteLine("");
            };
        }

        public static string GetRegionUrl(int regionNumber)
        {
            Regions region = new Regions();

            region = listOfRegions[regionNumber - 1];

            string url = region._regionUrl ?? string.Empty;

            return url;
        }
    }
}



