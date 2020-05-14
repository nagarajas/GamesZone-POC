using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesZone.Models
{
    public class Weather
    {
        [JsonProperty("temperature")]
        public float Temperature { get; set; }
        [JsonProperty("sky")]
        public string Sky { get; set; }
        [JsonProperty("wind_speed")]
        public string WindSpeed { get; set; }
        [JsonProperty("wind_direction")]
        public string WindDirection { get; set; }
        [JsonProperty("field_conditions")]
        public string FieldConditions { get; set; }
    }
}
