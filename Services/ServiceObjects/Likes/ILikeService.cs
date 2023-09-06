using WebWizards.Services.ServiceObjects.Posts;

namespace WebWizards.Services.ServiceObjects.Likes
{
    public interface ILikeService
    {
        public int CreateLike(int? userId, int? postId, int? commentId);
        public int DeleteLike(int? likeId, int? userId);
    }
}
