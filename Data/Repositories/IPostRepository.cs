using WebWizards.Data.Repositories.Repository;
using WebWizards.Data.Entities;
namespace WebWizards.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        public IEnumerable<Post> GetAllPostsByUserId(int userId);
        Post GetPostByCommentId(int commentId);

    }
}
