using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenAIAdapter.Dtos.AdapterToOpenAI
{
    public class ImageGenerationResponse
    {
        [Required]
        [JsonPropertyName("data")]
        public ICollection<URL>? Data { get; set; }
    }

}
