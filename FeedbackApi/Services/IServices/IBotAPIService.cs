using FeedbackApi.Models;

namespace FeedbackApi.Services.IServices
{
    public interface IBotAPIService
    {
        Task<List<string>> GenerateContent(ADGenerateRequestModelDTO generateRequestModel);
    }
}
