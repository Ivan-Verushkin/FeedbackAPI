namespace FeedbackApi.Models
{
    public class ChatGPTResponse
    {
        public int Id { get; set; }
        public string ResponseMessage { get; set; } = string.Empty;

        public int? FeedbackId { get; set; }

        public Feedback? Feedback { get; set; }
    }
}
