using AutoMapper;
using OpenAIAdapter.Dtos.AdapterToOpenAI;
using OpenAIAdapter.Dtos.ClientToAdapter;

namespace OpenAIAdapter.Mappers
{
    public class ImageRequestToImageGenerationRequestMapper : IMappingAction<ImageRequest, ImageGenerationRequest>
    {
        public void Process(ImageRequest source, ImageGenerationRequest destination, ResolutionContext context)
        {
            destination.Prompt = source.ImageDescription;

            destination.NumOfImages = 1;

            destination.SizeOfImages = "512x512";
        }
    }
}
