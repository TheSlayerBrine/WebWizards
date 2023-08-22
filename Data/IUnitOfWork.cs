using WebWizards.Data.Repositories;

namespace WebWizards.Data
{
    public interface IUnitOfWork
    {
        public IUserRepository Users { get; }
        public IPostRepository Posts { get; }
        public ICommentRepository Comments { get; }
        public ILikeRepository Likes { get; }
        int SaveChanges();
        void Reload<T>(T entity) where T : class;
        bool IsModified<T>(T entity) where T : class;
        void Dispose();
    }
}
