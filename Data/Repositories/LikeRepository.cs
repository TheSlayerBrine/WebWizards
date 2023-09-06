using Microsoft.EntityFrameworkCore;
using System.ComponentModel.Design;
using WebWizards.Data.Entities;
using WebWizards.Data.Repositories.Repository;

namespace WebWizards.Data.Repositories
{
    public class LikeRepository : Repository<Like> , ILikeRepository
    {
        private readonly IAppDbContext dbContext;

        public LikeRepository(IAppDbContext dbContext) : base((AppDbContext)dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Like> GetAllLikesOfComment(int commentId)
        {
            return dbContext.Likes.Where(c => c.CommentId == commentId).ToList();
        }

        public IEnumerable<Like> GetAllLikesOfPost(int postId)
        {
            return dbContext.Likes.Where(c => c.PostId == postId).ToList();
        }

        public IEnumerable<Like> GetAllLikesOfUser(int userId)
        {
            return dbContext.Likes.Where(c => c.UserId == userId).ToList();
        }

        public Like GetById(int id)
        {
            return dbContext.Likes.FirstOrDefault(l => l.Id == id);
        }

        public Like GetLikeByUserAndContent(int userId, int? postId, int? commentId)
        {
            var like = dbContext.Likes.FirstOrDefault(l => l.UserId == userId && (l.PostId == postId || l.CommentId == commentId));

            return like;
        }
        public void Add(Like entity)
        {
            dbContext.Likes.Add(entity);
        }
        public void Delete(Like entity)
        {
            
            dbContext.Likes.Remove(entity);
        }
    }
}
