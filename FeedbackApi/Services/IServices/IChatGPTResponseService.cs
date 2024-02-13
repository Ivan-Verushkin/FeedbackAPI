using FeedbackApi.Models;

namespace FeedbackApi.Services.IServices
{
    public interface IChatGPTResponseService
    {
        Task<List<ChatGPTResponse>> GetAllResponses();

        Task<bool> SaveResponse(ChatGPTResponse response);
    }
}
