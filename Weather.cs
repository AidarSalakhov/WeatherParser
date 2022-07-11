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

            var parametersNodes = htmlDoc.DocumentNode.SelectNodes("//dt//span[not(contains(@class, 'min-max-tempCold')) and not(contains(@class, 'min-max-tempHot'))]");

            var valueNodes = htmlDoc.DocumentNode.SelectNodes("//div[@id='weather-now-description']//dl//dd");
            

            for (int i = 0; i < parametersNodes.Count; i++)
            {
                WeatherStruct weatherStruct = new WeatherStruct();

                weatherStruct.parameter = parametersNodes[i].InnerText;
                
                Console.WriteLine(weatherStruct.parameter);

                weatherStruct.value = valueNodes[i].InnerText;

                Console.WriteLine(weatherStruct.value);

                listOfWeather.Add(weatherStruct);
            }

            return listOfWeather;
        }

    }
}
