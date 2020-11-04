using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aijkl.Abema.API.Models
{
    public class Series
    {

        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("displayImageUpdatedAt")]
        public int DisplayImageUpdatedAt { get; set; }

        [JsonProperty("rank")]
        public int Rank { get; set; }

        [JsonProperty("label")]
        public Label Label { get; set; }

        [JsonProperty("thumbComponent")]
        public ThumbComponent ThumbComponent { get; set; }

        [JsonProperty("thumbPortraitComponent")]
        public ThumbPortraitComponent ThumbPortraitComponent { get; set; }
    }
}
