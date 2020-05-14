using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesZone.Models
{
    public class Meta
    {
        [JsonProperty("copyright")]
        public string Copyright { get; set; }
    }
}
