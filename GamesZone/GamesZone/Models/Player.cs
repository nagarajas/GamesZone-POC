using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesZone.Models
{
    public class Player
    {
        [JsonProperty("cfl_central_id")]
        public int CentralId { get; set; }
        [JsonProperty("stats_inc_id")]
        public int StatsIncId { get; set; }
        [JsonProperty("first_name")]
        public string FirstName { get; set; }
        [JsonProperty("middle_name")]
        public string MiddleName { get; set; }
        [JsonProperty("last_name")]
        public string LastName { get; set; }
        [JsonProperty("birth_date")]
        public string BirthDate { get; set; }
        [JsonProperty("birth_place")]
        public string BirthPlace { get; set; }
        [JsonProperty("height")]
        public float Height { get; set; }
        [JsonProperty("weight")]
        public float Weight { get; set; }
        [JsonProperty("rookie_year")]
        public int? RookieYear { get; set; }
        [JsonProperty("foreign_player")]
        public bool ForeignPlayer { get; set; }
        [JsonProperty("image_url")]
        public string ImageURL { get; set; }
        [JsonProperty("school")]
        public School School { get; set; }
        [JsonProperty("position")]
        public Position Position { get; set; }

    }
}
