using Microsoft.EntityFrameworkCore;
using FeedbackApi.Models;

namespace FeedbackApi.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Feedback> Feedbacks => Set<Feedback>();

        public DbSet<ChatGPTResponse> ChatGPTResponses => Set<ChatGPTResponse>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feedback>()
                .HasOne(f => f.ChatGPTResponse)
                .WithOne(chr => chr.Feedback)
                .HasForeignKey<Feedback>(fb => fb.ResponseId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }
    }
}
