using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace GamesZone.Models
{
    [JsonObject]
    public class Game
    {
        [JsonProperty("game_id")]
        public int GameId { get; set; }
        [JsonProperty("date_start")]
        public DateTimeOffset StartDate { get; set; }
        [JsonProperty("game_number")]
        public string GameNumber { get; set; }
        [JsonProperty("week")]
        public string Week { get; set; }
        [JsonProperty("season")]
        public int Season { get; set; }
        [JsonProperty("attendance")]
        public int Attendance { get; set; }
        [JsonProperty("game_duration")]
        public string GameDuration { get; set; }
        [JsonProperty("event_type")]
        public EventType EventType { get; set; }
        [JsonProperty("event_status")]
        public EventStatus EventStatus { get; set; }
        [JsonProperty("venue")]
        public Venue Venue { get; set; }
        [JsonProperty("weather")]
        public Weather Weather { get; set; }
        [JsonProperty("coin_toss")]
        public CoinToss CoinToss { get; set; }
        [JsonProperty("tickets_url")]
        public string TicketsURL { get; set; }
        [JsonProperty("team_1")]
        public Team Team1 { get; set; }
        [JsonProperty("team_2")]
        public Team Team2 { get; set; }
    }
    
}
