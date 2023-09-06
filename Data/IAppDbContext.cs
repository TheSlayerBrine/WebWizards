using Microsoft.EntityFrameworkCore;
using WebWizards.Data.Entities;

namespace WebWizards.Data
{
    public interface IAppDbContext : IEntityFrameworkContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Like> Likes { get; set; }
    }
}
