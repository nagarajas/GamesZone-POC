using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesZone.Models
{
    public class Error
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("code")]
        public int Code { get; set; }
        [JsonProperty("detail")]
        public string Detail { get; set; }
    }
}
