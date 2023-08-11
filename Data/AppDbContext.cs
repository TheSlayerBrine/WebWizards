using Microsoft.EntityFrameworkCore;
using WebWizards.Data.Entities;

namespace WebWizards.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (optionsBuilder != null)
            {
                optionsBuilder.UseSqlServer("Data Source=DESKTOP-NFKHDAA\\SQLEXPRESS01;Initial Catalog=dotNFT;Integrated Security=True;TrustServerCertificate=True");
            }

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
               .HasKey(u => u.Id);
            modelBuilder.Entity<User>()
               .HasMany(u => u.Comments)
               .WithOne(c => c.User)
               .HasForeignKey(c => c.User.Id);
            modelBuilder.Entity<User>()
               .HasMany(u => u.Posts)
               .WithOne(p => p.User)
               .HasForeignKey(p => p.User.Id);
            modelBuilder.Entity<User>()
               .HasMany(u => u.Likes)
               .WithOne(l => l.User)
               .HasForeignKey(l => l.User.Id);


            modelBuilder.Entity<Post>()
               .HasKey(p => p.Id);
            modelBuilder.Entity<Post>()
               .HasMany(p => p.Comments)
               .WithOne(c => c.Post)
               .HasForeignKey(c => c.Post.Id);
            modelBuilder.Entity<Post>()
               .HasMany(p => p.Likes)
               .WithOne(l => l.Post)
               .HasForeignKey(l => l.Post.Id);

            modelBuilder.Entity<Comment>()
               .HasKey(c => c.Id);
            modelBuilder.Entity<Comment>()
               .HasMany(c => c.Likes)
               .WithOne(l => l.Comment)
               .HasForeignKey(l => l.Comment.Id);

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
