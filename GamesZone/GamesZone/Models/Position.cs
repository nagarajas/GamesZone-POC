using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesZone.Models
{
    public class Position
    {
        [JsonProperty("position_id")]
        public int PositionId { get; set; }
        [JsonProperty("offence_defence_or_special")]
        public string OffenceDefenceSpecial { get; set; }
        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }
        [JsonProperty("description")]
        public string Description { get; set; }
    }
}
