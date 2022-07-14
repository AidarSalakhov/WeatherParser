using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherParser
{
    internal class Messages
    {
        public const string MAIN_MENU_TEXT = "---Погода в России---\n" +
            "\nТочный прогноз погоды в России по большинству городов на сегодня и на неделю." +
            "\nПодробные данные по температуре, осадкам, ветре и давлении.\n" +
            "\nВыберите действие: " +
            "\n[W] - Выбрать регион России" +
            "\n[Escepe] - Выйти из программы";

        public const string WEATHER_MENU_TEXT = "Выберите действие: " +
            "\n[A] - Погода сегодня" +
            "\n[S] - Погода сегодня в развёрнутом виде" +
            "\n[D] - Погода на неделю" +
            "\n[Escepe] - Выйти из программы";

        public const string ENTER_REGION_NUMBER = "\nВведите номер региона, указанный в квадратных скобках: ";

        public const string ENTER_CITY_NUMBER = "\nВведите номер города, указанный в квадратных скобках: ";


        public const string ERROR_WRONG_BUTTON = "Ошибка! Вы ввели неверный символ";
    }
}
