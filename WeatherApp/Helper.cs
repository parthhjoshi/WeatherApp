using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{
    public class Helper
    {
      

    }
    public class DayWeather
    {
         public long Id { get; set; }
        public string WeatherDate { get; set; }
        public string Temp { get; set; }
        public string Description { get; set; }
        public string Icon { get; set; }
    }
}
