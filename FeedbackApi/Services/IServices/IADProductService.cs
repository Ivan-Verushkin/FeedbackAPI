using FeedbackApi.Models;

namespace FeedbackApi.Services.IServices
{
    public interface IADProductService
    {
        Task<ADProductResponseModel> GenerateAdContent(CustomerRequestModel aDGenerateRequestModel);
    }
}
