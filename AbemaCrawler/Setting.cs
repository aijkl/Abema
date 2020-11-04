using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace AbemaCrawler
{
    class Setting
    {
        [JsonProperty("bearerToken")]
        public string BearerToken { set; get; }
        public static Setting Load(string path)
        {
            return JsonConvert.DeserializeObject<Setting>(System.IO.File.ReadAllText(path));
        }
    }
}
