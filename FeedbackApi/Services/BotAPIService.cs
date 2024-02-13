using FeedbackApi.Models;
using FeedbackApi.Services.IServices;
using OpenAI_API;
using OpenAI_API.Models;

namespace FeedbackApi.Services
{
    public class BotAPIService : IBotAPIService
    {
        private readonly IConfiguration _configuration;

        public BotAPIService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<List<string>> GenerateContent(ADGenerateRequestModelDTO generateRequestModel)
        {
            var apiKey = _configuration.GetSection("ChatGPT:GChatAPIKEY").Value;
            var apiModel = _configuration.GetSection("ChatGPT:Model").Value;
            List<string> rq = new List<string>();
            string rs = "";
            OpenAIAPI api = new OpenAIAPI(new APIAuthentication(apiKey));
            var completionRequest = new OpenAI_API.Completions.CompletionRequest()
            {
                Prompt = generateRequestModel.prompt,
                Model = apiModel,
                Temperature = 0.5,
                MaxTokens = 100,
                TopP = 1.0,
                FrequencyPenalty = 0.0,
                PresencePenalty = 0.0,

            };
            var result = await api.Completions.CreateCompletionsAsync(completionRequest);
            foreach (var choice in result.Completions)
            {
                rs = choice.Text;
                rq.Add(choice.Text);
            }
            return rq;
        }
    }
}
