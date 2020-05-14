using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesZone.Models
{
    public class Team
    {
        [JsonProperty("team_id")]
        public int TeamId { get; set; }
        [JsonProperty("location")]
        public string Location { get; set;}
        [JsonProperty("nickname")]
        public string Nickname { get; set; }
        [JsonProperty("abbreviation")]
        public string Abbreviation { get; set; }
        [JsonProperty("score")]
        public int Score { get; set; }
        [JsonProperty("venue_id")]
        public int VenueId { get; set; }
        [JsonProperty("linescores")]
        public List<LineScore> LineScores { get; set; }
        [JsonProperty("is_at_home")]
        public bool IsAtHome { get; set; }
        [JsonProperty("is_winner")]
        public bool? IsWinner { get; set; }
    }
}
