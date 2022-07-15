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

        public static List<WeatherStruct> GetWeatherNow(string url)
        {
            List<WeatherStruct> listOfWeather = new List<WeatherStruct>();

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
            List<WeatherStruct> listOfWeather = new List<WeatherStruct>();

            HtmlWeb htmlWeb = new HtmlWeb();

            var htmlDoc = htmlWeb.Load(url);

            var parametersNodes = htmlDoc.DocumentNode.SelectNodes("//dt//span[not(contains(@class, 'min-max-tempCold')) and not(contains(@class, 'min-max-tempHot'))]");

            var valueNodes = htmlDoc.DocumentNode.SelectNodes("//div[@id='weather-now-description']//dl//dd");

            for (int i = 0; i < parametersNodes.Count; i++)
            {
                WeatherStruct weatherStruct = new WeatherStruct();

                weatherStruct.parameter = parametersNodes[i].InnerText;

                weatherStruct.value = valueNodes[i].InnerText;

                listOfWeather.Add(weatherStruct);
            }

            return listOfWeather;
        }

        public static string GetWeatherNowString(string url)
        {
            HtmlWeb htmlWeb = new HtmlWeb();

            var htmlDoc = htmlWeb.Load(url);

            string weatherInfo = htmlDoc.DocumentNode.SelectSingleNode("//span[@class='dw-into']").InnerText;

            weatherInfo = weatherInfo.Replace("Скрыть", "");

            weatherInfo = weatherInfo.Replace("Подробнее", "");

            weatherInfo = weatherInfo.Replace("   ", " ");

            weatherInfo = weatherInfo.Replace("  ", " ");

            return weatherInfo;
        }

        public static List<WeatherStruct> GetWeatherWeek(string url)
        {
            List<WeatherStruct> listOfWeather = new List<WeatherStruct>();

            HtmlWeb htmlWeb = new HtmlWeb();

            var htmlDoc = htmlWeb.Load(url);

            var nameDayOfWeekNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='day-week']");

            var dayOfMonthNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='numbers-month']");

            var nameOfMonthNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='month']");

            var weatherNodes = htmlDoc.DocumentNode.SelectNodes("//li//span/@title");

            var dayTemperatureNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='day-temperature']");

            var nightTemperatureNodes = htmlDoc.DocumentNode.SelectNodes("//div[@class='night-temperature']");

            for (int i = 0; i < nameDayOfWeekNodes.Count; i++)
            {
                WeatherStruct weatherStruct = new WeatherStruct();

                weatherStruct.parameter = $"{nameDayOfWeekNodes[i].InnerText} {dayOfMonthNodes[i].InnerText} {nameOfMonthNodes[i].InnerText}";

                weatherStruct.value = $"{weatherNodes[i].GetAttributeValue("title", null)}, днём {dayTemperatureNodes[i].InnerText}, ночью {nightTemperatureNodes[i].InnerText}";

                listOfWeather.Add(weatherStruct);
            }

            return listOfWeather;
        }

        public static void PrintWeather(List<WeatherStruct> weatherStruct)
        {
            Console.Clear();

            foreach (WeatherStruct weather in weatherStruct)
            {
                MessagesViewer.WriteLine($"{weather.parameter} {weather.value}");
            }
        }

        public static void PrintWeather(string weatherInfo)
        {
            Console.Clear();

            MessagesViewer.WriteLine(weatherInfo);
        }

        public static void ShowWeather()
        {
            Regions.listOfRegions.Clear();

            Cities.listOfCities.Clear();

            Regions.PrintRegions(Regions.ParseRegions("https://world-weather.ru/pogoda/russia/"));

            MessagesViewer.WriteLine(Messages.ENTER_REGION_NUMBER);

            try
            {
                Cities.PrintCities(Cities.ParseCities(Regions.GetRegionUrl(Convert.ToInt32(Console.ReadLine())))); 
            }
            catch (Exception)
            {
                Menu.ShowError();
            }

            MessagesViewer.WriteLine(Messages.ENTER_CITY_NUMBER);

            try
            {
                int cityNumber = Convert.ToInt32(Console.ReadLine());

                string cityUrl = Cities.GetCityUrl(cityNumber);

                string cityName = Cities.GetCityName(cityNumber);

                Console.Clear();

                Menu.ShowWeatherMenu(cityName, cityUrl);
            }
            catch (Exception)
            {
                Menu.ShowError();
            }
        }
    }
}
