using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aijkl.Abema.API.Models
{
    public class Label
    {

        [JsonProperty("free")]
        public bool Free { get; set; }

        [JsonProperty("someFree")]
        public bool? SomeFree { get; set; }

        [JsonProperty("newest")]
        public bool? Newest { get; set; }
    }
}
