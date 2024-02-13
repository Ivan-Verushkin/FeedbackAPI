using FeedbackApi.Models;
using FeedbackApi.Services.IServices;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FeedbackApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatGPTController : ControllerBase
    {
        private readonly IChatGPTResponseService _responseService;

        public ChatGPTController(IChatGPTResponseService chatGPTResponseService)
        {
            _responseService = chatGPTResponseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<ChatGPTResponse>>> GetResponses()
        {
            var responses = await _responseService.GetAllResponses();

            if(responses == null)
            {
                return NotFound();
            }

            return Ok(responses);
        }
    }
}
