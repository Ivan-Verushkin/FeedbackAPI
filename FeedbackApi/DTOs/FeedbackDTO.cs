namespace FeedbackApi.DTOs
{
    public class FeedbackDTO
    {
        public string FeedbackMessage { get; set; } = string.Empty;
        public DateTime Created { get; set; }
    }
}
