using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Aijkl.Abema.API.Models
{
    public abstract class Thumb
    {
        [JsonProperty("urlPrefix")]
        public string UrlPrefix { get; set; }

        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("extension")]
        public string Extension { get; set; }
    }
}
