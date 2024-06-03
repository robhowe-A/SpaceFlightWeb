using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Spaceflight_News_Server.Models
{
    public class Result
    {
        [JsonPropertyName("results")]

        public IList<Article>? articles { get; set; }

    }
}
