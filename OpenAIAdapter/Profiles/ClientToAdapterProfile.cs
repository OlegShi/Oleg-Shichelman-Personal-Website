using AutoMapper;
using OpenAIAdapter.Dtos.AdapterToOpenAI;
using OpenAIAdapter.Dtos.ClientToAdapter;
using OpenAIAdapter.Mappers;

namespace OpenAIAdapter.Profiles
{
    public class ClientToAdapterProfile : Profile
    {
        public ClientToAdapterProfile()
        {
            CreateMap<ImageRequest, ImageGenerationRequest>()
                .AfterMap<ImageRequestToImageGenerationRequestMapper>()
                    .ForAllMembers(opt => opt.Ignore());

            CreateMap<ImageGenerationResponse, ImageResponse>()
                .AfterMap<ImageGenerationResponseToImageResponse>()
                    .ForAllMembers(opt => opt.Ignore());
        }
    }
    
}
