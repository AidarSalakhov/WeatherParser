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

            foreach (var region in regions)
            {
                MessagesViewer.WriteLine($"[{regions.IndexOf(region) + 1}] {region._regionName}");
            }


            //double s = regions.Count / 3;

            //int arrayRowsLength = (int)Math.Round(s / 10) * 10;

            //int arrayColumns = 3;

            //Regions[,] regionsArray = new Regions[arrayRowsLength, arrayColumns];

            //int k = 0;

            //for (int j = 0; j < arrayColumns; j++)
            //{
            //    if (j == 2)
            //    {
            //        arrayRowsLength = (arrayRowsLength * 3) - regions.Count;
            //    }

            //    for (int i = 0; i < arrayRowsLength; i++)
            //    {
            //        k++;
            //        regionsArray[i, j] = regions[k - 1];
            //    }
            //}

            //k = 0;

            //for (int i = 0; i < arrayRowsLength; i++)
            //{
            //    for (int j = 0; j < arrayColumns; j++)
            //    {
            //        k++;
            //        Console.Write(string.Format("{{0, -{0}}}", 38), $"[{k}] {regionsArray[i, j]._regionName}");
            //    }
            //    Console.WriteLine();
            //}

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



