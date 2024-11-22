using EnerGenius.Services.Interfaces;
using EnerGenius.Settings;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.Extensions.Options;
using OpenAI;
using OpenAI_API;
using OpenAI_API.Chat;

namespace EnerGenius.Services
{
    public class GenerativeAIService : IGenerativeAIService
    {
        
        private readonly OpenAIAPI openAiApi;

        public GenerativeAIService(IOptions<IASettings> openAISettings)
        {
            openAiApi = new OpenAIAPI(openAISettings.Value.Abacaxi);
        }

        public async Task<string> GenerateText(string prompt)
        {
            
            var response = await openAiApi.Completions.CreateCompletionAsync(
            new OpenAI_API.Completions.CompletionRequest
            {
                Prompt = prompt,
                MaxTokens = 100
            });

            var resposta = response.Completions[0].Text;

            return resposta;
        }
    }
}
