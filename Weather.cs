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

            var weatherNowNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='weather-now-info']");

            WeatherStruct weatherStruct = new WeatherStruct();

            weatherStruct.parameter = $"{htmlDoc.DocumentNode.SelectSingleNode("//h1").InnerText} " +
                $"{htmlDoc.DocumentNode.SelectSingleNode("//div[@class='weather-now-info']//p//span[not(contains(text(), '°'))]").InnerText.ToLower()}";

            weatherStruct.value = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='weather-now-info']//b[contains(text(), ':')]").InnerText;

            listOfWeather.Add(weatherStruct);

            weatherStruct.parameter = htmlDoc.DocumentNode.SelectSingleNode("//div[@class='weather-now-info']//span/@title").GetAttributeValue("title", null);

            weatherStruct.value = $"{htmlDoc.DocumentNode.SelectSingleNode("//div[@id='weather-now-number']").InnerText}";

            listOfWeather.Add(weatherStruct);

            return listOfWeather;
        }

        public static List<WeatherStruct> GetWeatherNowAdditionalInformation(string url)
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

        public static string GetWeatherNowTextStyle(string url)
        {
            
            HtmlWeb htmlWeb = new HtmlWeb();

            var htmlDoc = htmlWeb.Load(url);

            string weatherInfo = htmlDoc.DocumentNode.SelectSingleNode("//span[@class='dw-into' and .//span[not(id='open-desc-weather')]]").InnerText;

            //span[contains (class,'dw-into') and not(contains(@id, 'open-desc-weather')) and not(contains(@id,'close-desc-weather'))]

            //span[@class='dw-into' and.//span[not(@id='open-desc-weather') and .//span[not(@id='close-desc-weather')]

            //span[@class='dw-into' and .//span[not(id='open-desc-weather')]]  

            Console.WriteLine(weatherInfo);

            return weatherInfo;
        }

    }
}
