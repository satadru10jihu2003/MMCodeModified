using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MeetingManagerAPI.Models
{
    public class LUISModel
    {
        [JsonProperty("query")]
        public string Query { get; set; }

        [JsonProperty("topScoringIntent")]
        public Intent TopScoringIntent { get; set; }


        [JsonProperty("intents")]
        public Intent[] Intents { get; set; }

        [JsonProperty("entities")]
        public Entity[] Entities { get; set; }

    }

    public class Intent
    {
        [JsonProperty("intent")]
        public string IntentName { get; set; }

        [JsonProperty("score")]
        public double Score { get; set; }
    }

    public class Entity
    {
        [JsonProperty("entity")]
        public string EntityName { get; set; }
        [JsonProperty("type")]
        public string Type { get; set; }
        [JsonProperty("startIndex")]
        public string StartIndex { get; set; }
        [JsonProperty("endIndex")]
        public string EndIndex { get; set; }
    }
}
