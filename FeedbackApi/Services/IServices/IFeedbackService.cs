using FeedbackApi.Models;

namespace FeedbackApi.Services.IServices
{
    public interface IFeedbackService
    {
        Task<List<Feedback>> GetAllFeedbacks();

        Task<List<Feedback>> CreateFeedback(Feedback feedback);

        Task<List<Feedback>> UpdateFeedback(Feedback feedback);

        Task<List<Feedback>> DeleteFeedback(int id);
    }
}
