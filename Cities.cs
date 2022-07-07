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

        private static List<Cities> _listOfCities = new List<Cities>();

        public Cities(string region, string regionIdentificationLetter, string city, string weather)
        {
            _region = region;
            _regionIdentificationLetter = regionIdentificationLetter;
            _city = city;
            _weather = weather;
        }

        public static Cities GetCity(int index)
        {
            return _listOfCities[index];
        }
        public static void SetCity(Cities city)
        {
            _listOfCities.Add(city);
        }

        public static List<Cities> GetCitiesList(int index)
        {
            return _listOfCities;
        }

        public static void SetCitiesList(List<Cities> listOfCities)
        {
            _listOfCities = listOfCities;
        }

        
    }
}
