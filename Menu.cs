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
            MessagesViewer.WriteLine(Messages.MAIN_MENU_TEXT);

            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.W:
                    Regions.PrintRegions(Regions.ParseRegions("https://world-weather.ru/pogoda/russia/"));
                    MessagesViewer.WriteLine(Messages.ENTER_REGION_NUMBER);
                    Cities.PrintCities(Cities.ParseCities(Regions.GetRegionUrl(Convert.ToInt32(Console.ReadLine()))));
                    MessagesViewer.WriteLine(Messages.ENTER_CITY_NUMBER);
                    string cityUrl = Cities.GetCityUrl(Convert.ToInt32(Console.ReadLine()));
                    Weather.PrintWeather(Weather.GetWeatherNow(cityUrl));
                    ShowWeatherMenu(cityUrl);
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

        public static void ShowWeatherMenu(string cityUrl)
        {
            MessagesViewer.WriteLine(Messages.WEATHER_MENU_TEXT);

            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.A:
                    Console.Clear();
                    Weather.PrintWeather(Weather.GetWeatherNowAdditionalInformation(cityUrl));
                    ShowWeatherMenu(cityUrl);
                    break;

                case ConsoleKey.S:
                    Console.Clear();
                    Weather.PrintWeather(Weather.GetWeatherNowString(cityUrl));
                    ShowWeatherMenu(cityUrl);
                    break;

                case ConsoleKey.D:
                    Console.Clear();
                    Weather.PrintWeather(Weather.GetWeatherWeek(cityUrl));
                    ShowWeatherMenu(cityUrl);
                    break;

                case ConsoleKey.Escape:
                    Process.GetCurrentProcess().Kill();
                    break;

                default:
                    Console.Clear();
                    MessagesViewer.WriteLine(Messages.ERROR_WRONG_BUTTON);
                    break;
            }
        }
    }
}
