using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesZone.Models
{
    public class EventStatus
    {
        [JsonProperty("event_status_id")]
        public int? EventStatusId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("is_active")]
        public bool IsActive { get; set; }
        [JsonProperty("quarter")]
        public int? Quarter { get; set; }
        [JsonProperty("minutes")]
        public int? Minutes { get; set; }
        [JsonProperty("seconds")]
        public int? Seconds{get;set;}
        [JsonProperty("down")]
        public string Down { get; set; }
        [JsonProperty("yards_to_go")]
        public string YardsToGo { get; set; }
    }
}
