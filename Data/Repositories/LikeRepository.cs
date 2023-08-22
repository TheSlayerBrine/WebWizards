using WebWizards.Data.Entities;
using WebWizards.Data.Repositories.Repository;

namespace WebWizards.Data.Repositories
{
    public class LikeRepository : Repository<Like> , ILikeRepository
    {
        private readonly AppDbContext dbContext;

        public LikeRepository(AppDbContext context) : base(context)
        {
            this.dbContext = context;
        }

        public IEnumerable<Like> GetAllLikesOfComment(int commentId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Like> GetAllLikesOfPost(int postId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Like> GetAllLikesOfUser(int userId)
        {
            throw new NotImplementedException();
        }
    }
}
