using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Threading.Tasks;

namespace InfoteriaWeatherApp
{
    class WeatherAppHelper
    {
        public async static Task<RootObject> GetWeather( string name)
        {
            var appid = "252cbd7ed4f9f881f35be648d13cdc11";
            var http = new HttpClient();
            var url = String.Format("http://api.openweathermap.org/data/2.5/forecast/daily?q={0}&units=metric&cnt=16&appid={1}", name, appid);
            var response = await http.GetAsync(url);
            var result = await response.Content.ReadAsStringAsync();
            var serializer = new DataContractJsonSerializer(typeof(RootObject));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(result));
            var data = (RootObject)serializer.ReadObject(ms);

            return data;
        }
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

        [DataMember]
        public int population { get; set; }
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

        [DataMember]
        public double speed { get; set; }

        [DataMember]
        public int deg { get; set; }

        [DataMember]
        public int clouds { get; set; }

        [DataMember]
        public double? rain { get; set; }
    }

    [DataContract]
    public class RootObject
    {
        [DataMember]
        public City city { get; set; }

        [DataMember]
        public string cod { get; set; }

        [DataMember]
        public double message { get; set; }

        [DataMember]
        public int cnt { get; set; }

        [DataMember]
        public List<List> list { get; set; }
    }
}
