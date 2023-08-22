using WebWizards.Data.Repositories.Repository;
using WebWizards.Data.Entities;
namespace WebWizards.Data.Repositories
{
    public interface ICommentRepository : IRepository<Comment>
    {
        public IEnumerable<Comment> GetAllCommentsOfPost(int postId);
        public IEnumerable<Comment> GetAllCommentsOfUser(int userId);

    }
}
