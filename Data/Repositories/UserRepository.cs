using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using System.Linq;
using WebWizards.Data.Entities;
using WebWizards.Data.Repositories.Repository;

namespace WebWizards.Data.Repositories
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly IAppDbContext dbContext;
        public UserRepository(IAppDbContext dbContext): base((AppDbContext)dbContext)
        {
            this.dbContext = dbContext;
        }
        public void Add(User entity)
        {
            dbContext.Users.Add(entity);
        }

        public void Delete(User entity)
        {
            if (entity.Comments != null)
            {
                entity = dbContext.Users.OrderBy(e => e.Name).Include(e => e.Comments).First();
            }

            if (entity.Posts != null)
            {
                entity = dbContext.Users.OrderBy(e => e.Name).Include(e => e.Posts).First();
            }

            if (entity.Likes != null)
            {
                entity = dbContext.Users.OrderBy(e => e.Name).Include(e => e.Likes).First();
            }
            dbContext.Users.Remove(entity);
        }

        public User Find(int id)
        {
            return dbContext.Users.Where(x => x.Id == id).FirstOrDefault();
        }
        public User GetById(int id)
        {
            var user = dbContext.Users.Include(u => u.Posts).Include(u => u.Likes).Include(u => u.Comments).FirstOrDefault(x => x.Id == id);
            return user;
        }
        public IEnumerable<User> GetAll()
        {
            return dbContext.Users;
        }

        public User GetByComment(int commentId)
        {
            var comment = dbContext.Comments.Include(c => c.User).Where(c => c.Id == commentId).FirstOrDefault();
            if (comment == null)
            { 
                return null;
            }
            return comment.User;
        }
        public User GetByPost(int postId)
        {
            var post = dbContext.Posts.Include(p => p.User).Where(p => p.Id == postId).FirstOrDefault();
            if (post == null)
            {
                return null;
            }
            return post.User;
        }

        public User GetByEmail(string email)
        {
            return dbContext.Users.Where(x => x.Email == email).FirstOrDefault();
        }

        public User GetByName(string name)
        {
            return dbContext.Users.Where(x => x.Name == name).FirstOrDefault();
        }
    }
}
