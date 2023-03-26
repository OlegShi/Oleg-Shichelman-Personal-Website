using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenAIAdapter.Dtos.AdapterToOpenAI
{
    [Serializable]
    public class ImageGenerationRequest
    {
        [Required]
        [JsonPropertyName("prompt")]
        public string? Prompt { get; set; }

        [Required]
        [JsonPropertyName("n")]
        public int? NumOfImages { get; set; }

        [Required]
        [JsonPropertyName("size")]
        public string? SizeOfImages { get; set; }
    }
}
