using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SmartAgriculture.Application.Weather.Models
{
    

    public class WeatherApiResponse
    {
        [JsonProperty("main")]
        public MainData Main { get; set; }

        [JsonProperty("wind")]
        public WindData Wind { get; set; }

        [JsonProperty("rain")]
        public RainData? Rain { get; set; }
    }

    public class MainData
    {
        [JsonProperty("temp")]
        public double Temp { get; set; }

        [JsonProperty("humidity")]
        public double Humidity { get; set; }
    }

    public class WindData
    {
        [JsonProperty("speed")]
        public double Speed { get; set; }
    }

    public class RainData
    {
        [JsonProperty("1h")]
        public double? OneHour { get; set; }
    }

}
