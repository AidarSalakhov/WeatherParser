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
                case ConsoleKey.O:
                    Console.Clear();
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
