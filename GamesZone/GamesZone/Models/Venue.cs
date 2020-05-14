using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesZone.Models
{
    public class Venue
    {
        [JsonProperty("venue_id")]
        public int VenueId { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
