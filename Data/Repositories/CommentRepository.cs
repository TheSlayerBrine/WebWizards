using Microsoft.EntityFrameworkCore;
using WebWizards.Data.Entities;
using WebWizards.Data.Repositories.Repository;

namespace WebWizards.Data.Repositories
{
    public class CommentRepository : Repository<Comment>, ICommentRepository
    {
        private readonly IAppDbContext dbContext;

        public CommentRepository(IAppDbContext dbContext) : base((AppDbContext)dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(Comment entity)
        {
            dbContext.Comments.Add(entity);
        }

        public void Delete(Comment entity)
        {

            if (entity.Likes != null)
            {
                entity = dbContext.Comments.OrderBy(e => e.Id).Include(e => e.Likes).First();
            }
            dbContext.Comments.Remove(entity);
        }

        public Comment Find(int id)
        {
            return dbContext.Comments.Where(x => x.Id == id).FirstOrDefault();
        }
        public Comment GetById(int id)
        {
            var comment = dbContext.Comments.Include(u => u.Likes).FirstOrDefault(x => x.Id == id);
            return comment;
        }
        public IEnumerable<Comment> GetAll()
        {
            return dbContext.Comments;
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
