using System.ComponentModel.DataAnnotations;

namespace FeedbackApi.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        public string FeedbackMessage { get; set; } = string.Empty;
        public int? ResponseId { get; set; }
        public ChatGPTResponse? ChatGPTResponse { get; set; }
        public DateTime Created { get; set; }
    }
}
