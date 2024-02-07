using Cardcraft.Data.Models;
using System.Text;
using System.Text.Json;

namespace Cardcraft.Data.Services
{
    public class OpenAIService : IAIService
    {
        private readonly HttpClient _httpClient;
        private readonly ApiKeyService _apiKeyService;

        public OpenAIService(HttpClient httpClient, ApiKeyService apiKeyService)
        {
            _httpClient = httpClient;
            _apiKeyService = apiKeyService;
        }

        public async Task<Result<string>> GenerateImageAsync(string prompt)
        {
            if(string.IsNullOrEmpty(_apiKeyService.ApiKey))
            {
                return Result<string>.Failure("No API key set. To generate images please provide an OpenAI API key on the settings section.");
            }

            var requestBody = new
            {
                prompt = prompt,
                model = "dall-e-3"
            };
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.openai.com/v1/images/generations")
            {
                Content = new StringContent(JsonSerializer.Serialize(requestBody), Encoding.UTF8, "application/json")
            };
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            
            request.Headers.Add("Authorization", $"Bearer {_apiKeyService.ApiKey}");

            var response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                try
                {
                    var responseContent = await response.Content.ReadAsStringAsync();
                    var openAIResponse = JsonSerializer.Deserialize<OpenAIResponse>(responseContent, options);
                    return Result<string>.Success(openAIResponse?.Data.FirstOrDefault()?.Url);
                }
                catch (Exception e)
                {
                    return Result<string>.Failure(e.Message);
                }
            }
            else
            {
                var errorContent = await response.Content.ReadAsStringAsync();
                var errorObj = JsonSerializer.Deserialize<JsonElement>(errorContent);

                if (errorObj.TryGetProperty("error", out var errorElement) && errorElement.TryGetProperty("message", out var messageElement))
                {
                    string errorMessage = messageElement.GetString();
                    return Result<string>.Failure("API error: " + errorMessage);
                }
                else
                {
                    return Result<string>.Failure("Error parsing error message from API.");
                }
            }
        }
    }

}
