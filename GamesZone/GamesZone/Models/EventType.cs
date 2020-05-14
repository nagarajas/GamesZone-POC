using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesZone.Models
{
    public class EventType
    {
        [JsonProperty("event_type_id")]
        public int EventTypeId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("title")]
        public string Title { get; set; }
    }
}
