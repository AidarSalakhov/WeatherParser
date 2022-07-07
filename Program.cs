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
            Regions.ParseRegions("https://world-weather.ru/pogoda/russia/");

            //Menu.ShowMainMenu();
        }
    }
}