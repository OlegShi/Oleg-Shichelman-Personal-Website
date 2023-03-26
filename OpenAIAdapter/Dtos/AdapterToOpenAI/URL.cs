using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenAIAdapter.Dtos.AdapterToOpenAI
{
    public class URL
    {
        [Required]
        [JsonPropertyName("url")]
        public string? Url { get; set; }
    }
}
