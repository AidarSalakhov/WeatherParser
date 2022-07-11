using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;

namespace WeatherParser
{
    internal class Weather
    {
        public struct WeatherStruct
        {
            internal string parameter;
            internal string value;
        }

        public static List<WeatherStruct> listOfWeather = new List<WeatherStruct>();

        public static List<WeatherStruct> GetWeatherNow(string url)
        {
            HtmlWeb htmlWeb = new HtmlWeb();

            var htmlDoc = htmlWeb.Load(url);

            //var weatherNow = htmlDoc.DocumentNode.SelectNodes("//dt//span[not(contains(@class, 'min-max-tempCold')) and not(contains(@class, 'min-max-tempHot'))]");
            
            var weatherNow = htmlDoc.DocumentNode.SelectNodes("//div[@id='weather-now-description']//dl");

            foreach (var item in weatherNow)
            {
                WeatherStruct weatherStruct = new WeatherStruct();

                weatherStruct.parameter = item.InnerText;

                Console.WriteLine(weatherStruct.parameter);

                weatherStruct.value = item.GetAttributeValue("span", null);

                Console.WriteLine(weatherStruct.value);

                listOfWeather.Add(weatherStruct);
            }

            return listOfWeather;
        }

    }
}
