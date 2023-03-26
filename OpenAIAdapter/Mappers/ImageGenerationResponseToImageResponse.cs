using AutoMapper;
using OpenAIAdapter.Dtos.AdapterToOpenAI;
using OpenAIAdapter.Dtos.ClientToAdapter;

namespace OpenAIAdapter.Mappers
{
    public class ImageGenerationResponseToImageResponse : IMappingAction<ImageGenerationResponse, ImageResponse>
    {
        public void Process(ImageGenerationResponse source, ImageResponse destination, ResolutionContext context)
        {
            destination.ImageUrl = source?.Data?.First().Url;
        }
    }
}