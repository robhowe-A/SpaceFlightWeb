using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace Spaceflight_News_Server.Models
{
    public class APOD
    {
        [JsonPropertyName("title")]
        public string apodtitle { get; set; }
        public string date { get; set; }

        [JsonPropertyName("url")]
        public string hdurl { get; set; }

        [JsonPropertyName("explanation")]
        public string description { get; set; }

        [JsonPropertyName("media_type")]
        public string media { get; set; }
        [Key]
        public int id { get; set; }
    }
}
