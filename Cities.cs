using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherParser
{
    internal class Cities
    {
        private string _region { get; set; }
        private string _regionIdentificationLetter { get; set; }
        private string _city { get; set; }
        private string _weather { get; set; }

        public Cities(string region, string regionIdentificationLetter, string city, string weather)
        {
            _region = region;
            _regionIdentificationLetter = regionIdentificationLetter;
            _city = city;
            _weather = weather;
        }

        public static void GetWeather()
        {

        }
    }
}
