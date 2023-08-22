using WebWizards.Data.Repositories.Repository;
using WebWizards.Data.Entities;
namespace WebWizards.Data.Repositories
{
    public interface ILikeRepository : IRepository<Like>
    {
        public IEnumerable<Like> GetAllLikesOfUser(int userId);
        public IEnumerable<Like> GetAllLikesOfComment(int commentId);
        public IEnumerable<Like> GetAllLikesOfPost(int postId);

    }
}
