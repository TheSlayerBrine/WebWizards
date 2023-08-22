using WebWizards.Data.Entities;
using WebWizards.Data.Repositories.Repository;

namespace WebWizards.Data.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly AppDbContext dbContext;

        public CommentRepository(AppDbContext context) : base(context)
        {
            this.dbContext = context;
        }
       public IEnumerable<Comment> GetAllCommentsOfPost(int postId)
        {
            return dbContext.Comments.Where(c => c.PostId == postId).ToList();
               
        }
       public IEnumerable<Comment> GetAllCommentsOfUser(int userId)
        {
            return dbContext.Comments.Where(c => c.UserId == userId).ToList();
        }
    }
}
