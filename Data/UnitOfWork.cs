using Microsoft.EntityFrameworkCore;
using WebWizards.Data.Repositories;

namespace WebWizards.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dBContext;
        public UnitOfWork(
            AppDbContext dBContext,
            IUserRepository userRepository,
            IPostRepository postRepository,
            ICommentRepository commentRepository,
            ILikeRepository likeRepository)
        {
            this.dBContext = dBContext;
            this.Users = userRepository;
            this.Comments = commentRepository;
            this.Posts = postRepository;
            this.Likes = likeRepository;
        }
        #region Repositories
        public IUserRepository Users { get; private set; }
        public IPostRepository Posts { get; private set; }
        public ICommentRepository Comments { get; private set; }
        public ILikeRepository Likes { get; private set; }
        #endregion

        public int SaveChanges()
        {
            return dBContext.SaveChanges();
        }
        public void Dispose()
        {
            dBContext.Dispose();
        }
        public void Reload<T>(T entity) where T : class
        {
            dBContext.Entry(entity).Reload();
        }
        public bool IsModified<T>(T entity) where T : class
        {
            return dBContext.Entry(entity).State == EntityState.Modified;
        }
    }
}
