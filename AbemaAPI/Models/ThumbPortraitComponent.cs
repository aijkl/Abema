using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aijkl.Abema.API.Models
{
    public class ThumbPortraitComponent : Thumb
    {
        [JsonProperty("query")]
        public string Query { get; set; }
    }
}
