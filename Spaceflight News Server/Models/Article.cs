using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Spaceflight_News_Server.Models

{
    public class Article
    {
        public string title { get; set; }
        public string url { get; set; }
        [JsonPropertyName("image_url")]
        public string textURL { get; set; }
        public string summary { get; set; }
        [JsonPropertyName("published_at")]
        public DateTime date { get; set; }
        public Boolean featured { get; set; }

        public IList<Launch>? launches { get; set; }
        public int id { get; set; }
        [Key]
        public int articleNum { get; set; }
    }

    public class Launch
    {
        [Key]
        public int launchNum { get; set; }
        [JsonPropertyName("launch_id")]
        public string? id { get; set; }
        public string? provider { get; set; }
    }
}