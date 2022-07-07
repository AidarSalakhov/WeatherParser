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
        public static ParseCities()
        {

        }
        var html = @"http://html-agility-pack.net/";

        HtmlWeb web = new HtmlWeb();

        var htmlDoc = web.Load(html);

        var node = htmlDoc.DocumentNode.SelectSingleNode("//head/title");

        Console.WriteLine("Node Name: " + node.Name + "\n" + node.OuterHtml);
    }
}
