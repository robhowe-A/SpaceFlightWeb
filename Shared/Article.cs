using System.Text.Json.Serialization;

namespace SpaceFlightWeb.Shared
{
    public class Article
    {
        public string title { get; set; }
        public string url { get; set; }
        [JsonPropertyName("imageUrl")]
        public string textURL { get; set; }
        public string summary { get; set; }
        [JsonPropertyName("publishedAt")]
        public DateTime date { get; set; }
        public Boolean featured { get; set; }

        public IList<Launch>? launches { get; set; }
    }

    public class Launch
    {
        public string? id { get; set; }
        public string? provider { get; set; }
    }
}