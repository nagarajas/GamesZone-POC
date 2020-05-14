using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesZone.Models
{
    public class PlayerAPIResponse
    {
        [JsonProperty("data")]
        public IList<Player> Data { get; set; }
        [JsonProperty("errors")]
        public IList<Error> Errors { get; set; }
        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
