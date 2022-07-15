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
                    Weather.ShowCityWeather();
                    break;

                case ConsoleKey.Escape:
                    Process.GetCurrentProcess().Kill();
                    break;

                default:
                    ShowMenuError();
                    break;
            }

            ShowMainMenu();
        }

        public static void ShowWeatherMenu(string cityName, string cityUrl)
        {
            MessagesViewer.WriteLine($"\n{cityName}");

            MessagesViewer.WriteLine(Messages.WEATHER_MENU_TEXT);

            ConsoleKey key = Console.ReadKey(true).Key;

            switch (key)
            {
                case ConsoleKey.A:
                    Weather.PrintWeather(Weather.GetWeatherNowStruct(cityUrl));
                    break;

                case ConsoleKey.S:
                    Weather.PrintWeather(Weather.GetWeatherNowString(cityUrl));
                    break;

                case ConsoleKey.D:
                    Weather.PrintWeather(Weather.GetWeatherWeekStruct(cityUrl));
                    break;

                case ConsoleKey.Backspace:
                    Console.Clear();
                    ShowMainMenu();
                    break;

                case ConsoleKey.Escape:
                    Process.GetCurrentProcess().Kill();
                    break;

                default:
                    ShowMenuError();
                    break;
            }

            ShowWeatherMenu(cityName, cityUrl);
        }

        public static void ShowMenuError()
        {
            Console.Clear();
            MessagesViewer.WriteLine(Messages.ERROR_WRONG_BUTTON);
        }
    }
}
