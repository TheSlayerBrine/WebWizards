using Microsoft.EntityFrameworkCore;
using WebWizards.Data.Entities;

namespace WebWizards.Data
{
    public class AppDbContext : DbContext, IAppDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
               .HasMany(u => u.Comments)
               .WithOne(c => c.User)
               .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
               .HasMany(u => u.Posts)
               .WithOne(p => p.User)
               .OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>()
               .HasMany(u => u.Likes)
               .WithOne(l => l.User)
               .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Post>()
               .HasKey(p => p.Id);
            modelBuilder.Entity<Post>()
               .HasMany(p => p.Comments)
               .WithOne(c => c.Post)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Post>()
               .HasMany(p => p.Likes)
               .WithOne(l => l.Post)
               .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Comment>()
               .HasKey(c => c.Id);
            modelBuilder.Entity<Comment>()
               .HasMany(c => c.Likes)
               .WithOne(l => l.Comment)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Comment>()
                .HasOne(c => c.User)
                .WithMany(u => u.Comments);

            modelBuilder.Entity<Like>()
               .HasKey(l => l.Id);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}
