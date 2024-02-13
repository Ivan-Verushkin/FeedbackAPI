using FeedbackApi.Data;
using FeedbackApi.Models;
using FeedbackApi.Services.IServices;
using Microsoft.EntityFrameworkCore;

namespace FeedbackApi.Services
{
    public class ChatGPTResponseService : IChatGPTResponseService
    {
        private readonly DataContext _dataContext;

        public ChatGPTResponseService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task<List<ChatGPTResponse>> GetAllResponses()
        {
            return await _dataContext.ChatGPTResponses.ToListAsync();
        }

        public async Task<bool> SaveResponse(ChatGPTResponse response)
        {
            try { 
                await _dataContext.ChatGPTResponses.AddAsync(response);
                await _dataContext.SaveChangesAsync();

                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            
        }
    }
}
