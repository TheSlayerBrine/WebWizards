using WebWizards.Data.Repositories.Repository;
using WebWizards.Data.Entities;
namespace WebWizards.Data.Repositories
{
    public interface IPostRepository : IRepository<Post>
    {
        Post GetByComment(int commentId);
        Post GetById (int id);

    }
}
