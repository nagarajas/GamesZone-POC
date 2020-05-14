using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesZone.Models
{
    public class LineScore
    {
        [JsonProperty("quarter")]
        public string Quarter { get; set; }
        [JsonProperty("score")]
        public int Score { get; set; }

    }
}
