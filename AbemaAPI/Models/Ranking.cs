using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aijkl.Abema.API.Models
{
    public class Ranking
    {
        [JsonProperty("series")]
        public List<Series> Series { get; set; }

        [JsonProperty("updatedAt")]
        public int UpdatedAt { get; set; }
    }
}
