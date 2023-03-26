using Microsoft.AspNetCore.Mvc;
using OpenAIAdapter.Dtos.ClientToAdapter;

namespace OpenAIAdapter.Services
{
    public interface IOpenAIClientService
    {
        Task<ActionResult<ImageResponse>> GenerateImage(ImageRequest imageRequest);
    }
}
