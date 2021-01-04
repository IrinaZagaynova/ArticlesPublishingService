using ArticlesService.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace ArticlesService.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Article> Articles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ArticleCategory> ArticleCategories { get; set; }
        public DbSet<ArticleImage> ArticleImages { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {                        
            modelBuilder.Entity<Article>()
                        .HasOne(a => a.User)
                        .WithMany(u => u.Articles)
                        .HasForeignKey(a => a.UserId)
                        .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.Login)
                .IsUnique(true);

            modelBuilder.Entity<User>()
                .HasIndex(u => u.EMail)
                .IsUnique(true);
        }
    }
}
