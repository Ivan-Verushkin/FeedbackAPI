using Microsoft.EntityFrameworkCore;
using FeedbackApi.Data;
using FeedbackApi.Models;
using FeedbackApi.Services.IServices;

namespace FeedbackApi.Services
{
    public class FeedbackService : IFeedbackService
    {
        private readonly DataContext _dataContext;
        public FeedbackService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public async Task<List<Feedback>> GetAllFeedbacks()
        {
            return await _dataContext.Feedbacks.ToListAsync();
        }

        public async Task<List<Feedback>> CreateFeedback(Feedback feedback)
        {
            await _dataContext.Feedbacks.AddAsync(feedback);
            await _dataContext.SaveChangesAsync();

            return await _dataContext.Feedbacks.ToListAsync();
        }

        public async Task<List<Feedback>> UpdateFeedback(Feedback feedback)
        {
            var updatedFeedback = await _dataContext.Feedbacks.FirstOrDefaultAsync(f => f.Id == feedback.Id);

            if (updatedFeedback == null) { return null; }

            updatedFeedback.FeedbackMessage = feedback.FeedbackMessage;

            await _dataContext.SaveChangesAsync();

            return await _dataContext.Feedbacks.ToListAsync();
        }

        public async Task<List<Feedback>> DeleteFeedback(int id)
        {
            var feedback = await _dataContext.Feedbacks.FirstOrDefaultAsync(f => f.Id == id);

            if(feedback == null)
            {
                return null;
            }

            _dataContext.Feedbacks.Remove(feedback);

            await _dataContext.SaveChangesAsync();

            return await _dataContext.Feedbacks.ToListAsync();
        }
    }
}
