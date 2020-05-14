using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesZone.Models
{
    public class CoinToss
    {
        [JsonProperty("coin_toss_winner")]
        public string CoinTossWinner { get; set; }
        [JsonProperty("coin_toss_winner_election")]
        public string CoinTossElection { get; set; }
    }
}
