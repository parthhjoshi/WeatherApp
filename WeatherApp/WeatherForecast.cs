using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace WeatherApp
{

    public class WeatherForecast
    {
        public static async Task<RootObjectF> Forecast(double lat, double lon, int cnt)
        {
            var Http = new HttpClient();
            var url = String.Format("http://api.openweathermap.org/data/2.5/forecast/daily?lat={0}&lon={1}&cnt=16&units=metric&APPID=b6d78cab179e00ea622e70a0be6a0dcd", lat, lon);
            var Response = await Http.GetAsync(url);

            var Result = await Response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObjectF));

            var ms = new MemoryStream(Encoding.UTF8.GetBytes(Result));
            var data = (RootObjectF)serializer.ReadObject(ms);
            return data;

        }
        [DataContract]
        public class Coord
        {
            [DataMember]
            public double lon { get; set; }
            [DataMember]
            public double lat { get; set; }
        }

        [DataContract]
        public class City
        {
            [DataMember]
            public int id { get; set; }
            [DataMember]
            public string name { get; set; }
            [DataMember]
            public Coord coord { get; set; }
            [DataMember]
            public string country { get; set; }
        }

        [DataContract]
        public class Temp
        {
            [DataMember]
            public double day { get; set; }
            [DataMember]
            public double min { get; set; }
            [DataMember]
            public double max { get; set; }
            [DataMember]
            public double night { get; set; }
            [DataMember]
            public double eve { get; set; }
            [DataMember]
            public double morn { get; set; }
        }

        [DataContract]
        public class Weather
        {
            [DataMember]
            public int id { get; set; }
            [DataMember]
            public string main { get; set; }
            [DataMember]
            public string description { get; set; }
            [DataMember]
            public string icon { get; set; }
        }

        [DataContract]
        public class List
        {
            [DataMember]
            public int dt { get; set; }
            [DataMember]
            public Temp temp { get; set; }
            [DataMember]
            public double pressure { get; set; }
            [DataMember]
            public int humidity { get; set; }
            [DataMember]
            public List<Weather> weather { get; set; }
        }

        [DataContract]
        public class RootObjectF
        {
            [DataMember]
            public string cod { get; set; }
            [DataMember]
            public double message { get; set; }
            [DataMember]
            public City city { get; set; }
            [DataMember]
            public int cnt { get; set; }
            [DataMember]
            public List<List> list { get; set; }
        }
    }     

    
}
