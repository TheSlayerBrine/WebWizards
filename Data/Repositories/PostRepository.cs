using Microsoft.EntityFrameworkCore;
using WebWizards.Data.Entities;
using WebWizards.Data.Repositories.Repository;

namespace WebWizards.Data.Repositories
{
    public class PostRepository : Repository<Post>,IPostRepository
    {
        private readonly IAppDbContext dbContext;
        public PostRepository(IAppDbContext dbContext) : base((AppDbContext)dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(Post entity)
        {
            dbContext.Posts.Add(entity);
        }

        public void Delete(Post entity)
        {           
            dbContext.Posts.Remove(entity);
        }

        public Post Find(int id)
        {
            return dbContext.Posts.Where(x => x.Id == id).FirstOrDefault();
        }
        public Post GetById(int id)
        {
            var post = dbContext.Posts.Include(u => u.Likes).Include(u => u.Comments).FirstOrDefault(x => x.Id == id);
            return post;
        }
        public IEnumerable<Post> GetAll()
        {
            return dbContext.Posts;
        }

        public Post GetByComment(int commentId)
        {
            var comment = dbContext.Comments.Include(c => c.Post).Where(c => c.Id == commentId).FirstOrDefault();
            if (comment == null)
            {
                return null;
            }
            return comment.Post;
        }
        public IEnumerable<Post> GetAllPostsOfUser(int userId)
        {
            return dbContext.Posts.Where(x => x.UserId == userId).ToList();
        }

      
    }
}
