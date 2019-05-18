using ArchitectureRecognition.Services.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace ArchitectureRecognition.Data
{
    public sealed class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(user =>
            {
                user.Property(u => u.FirstName).IsRequired();

                user.Property(u => u.Id)
                    .IsRequired()
                    .ValueGeneratedNever();

                user.Property(u => u.LastName).IsRequired();
            });

            modelBuilder.Entity<RecognitionResult>(recognitionResults =>
            {
                recognitionResults.Property(tl => tl.AuthUserId)
                    .IsRequired();
                recognitionResults.Property(tl => tl.ImagePath)
                    .IsRequired();
                recognitionResults.Property(tl => tl.Style)
                    .IsRequired();

            });

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<RecognitionResult> RecognitionResults { get; set; }

    }
}
