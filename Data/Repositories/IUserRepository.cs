using WebWizards.Data.Repositories.Repository;
using WebWizards.Data.Entities;
namespace WebWizards.Data.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetById(int id);
        User GetByUserName(string userName);
        User GetByComment(int  commentId);
        User GetByPost(int postId);
    }
}
