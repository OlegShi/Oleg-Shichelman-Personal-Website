using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace OpenAIAdapter.Dtos.ClientToAdapter
{
    public class ImageRequest
    {
        [Required]
        [JsonPropertyName("ImageDescription")]
        public string? ImageDescription { get; set; }       
    }
}
