using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace WeatherParser
{
    internal class Menu
    {
        public static void ShowMainMenu()
        {
            MessagesViewer.WriteLine(Messages.MENU_TEXT);

            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.W:
                    Regions.PrintRegions(Regions.ParseRegions("https://world-weather.ru/pogoda/russia/"));
                    MessagesViewer.WriteLine(Messages.ENTER_REGION_NUMBER);
                    Cities.PrintCities(Cities.ParseCities(Regions.GetRegionUrl(Convert.ToInt32(Console.ReadLine()))));
                    MessagesViewer.WriteLine(Messages.ENTER_CITY_NUMBER);
                    Weather.GetWeatherNow($"https:{Cities.GetCityUrl(Convert.ToInt32(Console.ReadLine()))}");

                    break;

                case ConsoleKey.Escape:
                    Process.GetCurrentProcess().Kill();
                    break;

                default:
                    Console.Clear();
                    MessagesViewer.WriteLine(Messages.ERROR_WRONG_BUTTON);
                    break;
            }
            ShowMainMenu();
        }
    }
}
