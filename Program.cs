using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;

namespace WeatherParser
{
    class Program
    {
        static void Main(string[] args)
        {
            //Menu.ShowMainMenu();

            //Regions.ParseRegions("https://world-weather.ru/pogoda/russia/");

            //Cities.ParseCities("https://world-weather.ru/pogoda/russia/tatarstan/");

            Weather.GetWeatherNow("https://world-weather.ru/pogoda/russia/kazan/");
        }
    }
}