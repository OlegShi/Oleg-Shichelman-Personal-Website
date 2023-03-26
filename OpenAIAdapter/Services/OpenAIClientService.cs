using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using OpenAIAdapter.Dtos.AdapterToOpenAI;
using OpenAIAdapter.Dtos.ClientToAdapter;
using OpenAIAdapter.Settings;
using System.Text;
using System.Text.Json;

namespace OpenAIAdapter.Services
{
    public class OpenAIClientService : IOpenAIClientService
    {
        private readonly IMapper _mapper;
        private readonly OpenAiSettings _settings;
        private readonly HttpClient _httpClient;

        public OpenAIClientService(IMapper mapper, IOptions<OpenAiSettings> settings, HttpClient httpClient)
        {
            _mapper = mapper;

            _settings = settings.Value;

            _httpClient = httpClient;

            _httpClient.BaseAddress = new Uri(_settings.BaseDomain!);

            //move to environment variables
            _httpClient.DefaultRequestHeaders.Add("Authorization", "Bearer [your API key]");
        }

        public async Task<ActionResult<ImageResponse>> GenerateImage(ImageRequest imageRequest)
        {
            var imageGenerationRequest = _mapper.Map<ImageRequest, ImageGenerationRequest>(imageRequest);

            var jsonRequest = JsonSerializer.Serialize(imageGenerationRequest);

            var content = new StringContent(jsonRequest, Encoding.UTF8, "application/json");

            var httpResponseMessage = await _httpClient.PostAsync(_settings.AddressUrl, content);

            httpResponseMessage.EnsureSuccessStatusCode();

            var response = await httpResponseMessage.Content.ReadFromJsonAsync<ImageGenerationResponse>();

            return _mapper.Map<ImageGenerationResponse, ImageResponse>(response!);
        }

    }
}
