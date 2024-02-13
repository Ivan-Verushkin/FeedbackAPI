using System.ComponentModel.DataAnnotations;

namespace FeedbackApi.Models
{
    public class Feedback
    {
        [Key]
        public int Id { get; set; }
        public string FeedbackMessage { get; set; } = string.Empty;
        public DateTime Created { get; set; }
    }
}
