using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenAIAdapter.Dtos.ClientToAdapter
{
    public class ImageResponse
    {
        [Required]
        [JsonPropertyName("ImageUrl")]
        public string? ImageUrl { get; set; }
    }
}
