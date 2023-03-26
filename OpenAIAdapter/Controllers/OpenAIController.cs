using Microsoft.AspNetCore.Mvc;
using OpenAIAdapter.Dtos.ClientToAdapter;
using OpenAIAdapter.Services;

namespace OpenAIAdapter.Controllers
{
    [ApiController]
    [Route("v1/[controller]")]
    public class OpenAIController : ControllerBase
    {
        private readonly IOpenAIClientService _OpenAIClientService;

        public OpenAIController(IOpenAIClientService openAIClientService)
        {
            _OpenAIClientService = openAIClientService;
        }


        [HttpPost("GenerateImage")]
        public async Task<ActionResult<ImageResponse>> GenerateImage(ImageRequest imageRequest)
        {
            return await _OpenAIClientService.GenerateImage(imageRequest);
        }

    }
}
