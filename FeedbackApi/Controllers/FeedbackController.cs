using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using FeedbackApi.Models;
using FeedbackApi.Services.IServices;
using FeedbackApi.DTOs;

namespace FeedbackApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IADProductService _productService;
        private readonly IChatGPTResponseService _chatGPTResponseService;
        public FeedbackController(IFeedbackService feedbackService, IADProductService aDProductService, IChatGPTResponseService chatGPTResponseService)
        {
            _feedbackService = feedbackService;
            _productService = aDProductService;
            _chatGPTResponseService = chatGPTResponseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Feedback>>> GetFeedbacks()
        {
            var feedbacks = await _feedbackService.GetAllFeedbacks();

            if (feedbacks == null)
            {
                return NotFound();
            }

            return Ok(feedbacks);
        }

        [HttpPost]
        public async Task<ActionResult<List<Feedback>>> CreateFeedback([FromBody] FeedbackDTO feedbackDto)
        {
            try
            {
                var feedback = new Feedback () { FeedbackMessage = feedbackDto.FeedbackMessage, Created = feedbackDto.Created };

                var feedbacks = await _feedbackService.CreateFeedback(feedback);

                var requestModel = new CustomerRequestModel() { Message = feedback.FeedbackMessage };
                var response = new ADProductResponseModel();
                try 
                { 
                    response = await _productService.GenerateAdContent(requestModel);
                }
                catch (HttpRequestException ex)
                {
                    Console.WriteLine(ex.ToString());
                }

                if(response.ADContent == null)
                {
                    response.ADContent = ["I don`t have a Chat GPT subscription and I`m getting an error because of it. If you have one please update the appsettings.json file with your credentials for testing", $"A response generated for a feedback: {feedbackDto.FeedbackMessage} "];
                }

                var ChatGPTResponse = new ChatGPTResponse() { Feedback = feedback, FeedbackId = feedback.Id, ResponseMessage = string.Join(". ", response.ADContent) };

                var inserted = _chatGPTResponseService.SaveResponse(ChatGPTResponse);

                if (inserted == null)
                {
                    return BadRequest();
                }

                return Ok(feedbacks);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPut]
        public async Task<ActionResult<List<Feedback>>> UpdateFeedback([FromBody] Feedback feedback)
        {
            var feedbacks = await _feedbackService.UpdateFeedback(feedback);

            if (feedbacks == null)
            {
                return NotFound();
            }

            return Ok(feedbacks);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Feedback>>> DeleteFeedback([FromRoute] int id)
        {
            var feedbacks = await _feedbackService.DeleteFeedback(id);

            if (feedbacks == null)
            {
                return NotFound();
            }

            return Ok(feedbacks);
        }
    }
}
