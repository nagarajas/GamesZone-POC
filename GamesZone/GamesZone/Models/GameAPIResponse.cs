using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesZone.Models
{
    [JsonObject]
    public class GameAPIResponse
    {
        [JsonProperty("data")]
        public IList<Game> Data { get; set; }
        [JsonProperty("errors")] 
        public IList<Error> Errors { get; set; }
        [JsonProperty("meta")]
        public Meta Meta { get; set; }
    }
}
