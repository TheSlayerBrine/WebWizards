using WebWizards.Data;
using WebWizards.Data.Entities;

namespace WebWizards.Services.ServiceObjects.Likes
{
    public class LikeService : ILikeService
    {
        private readonly IUnitOfWork unitOfWork;
        public LikeService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public int CreateLike(int? userId, int? postId, int? commentId)
        {
            if(!userId.HasValue || (!postId.HasValue && !commentId.HasValue))
            {                
                return (int)StatusCodes.InvalidCredentialError;
            }
            var user = unitOfWork.Users.GetById(userId.Value);
            var post = postId.HasValue ? unitOfWork.Posts.GetById(postId.Value) : null;
            var comment = commentId.HasValue ? unitOfWork.Comments.GetById(commentId.Value) : null;
            if (user == null || (postId.HasValue && post == null) || (commentId.HasValue && comment == null))
            {
                return (int)StatusCodes.NotFoundError;
            }
            var existingLike = unitOfWork.Likes.GetLikeByUserAndContent(userId.Value, postId, commentId);
            if (existingLike != null)
            {
                return (int)StatusCodes.UnauthorizedError;
            }
            var likeToAdd = new Like
            {
                UserId = userId.Value,
                PostId = postId,
                CommentId = commentId,
            };
            likeToAdd.User = user;
            likeToAdd.Comment = comment;
            likeToAdd.Post = post;
            user.Likes.Add(likeToAdd);
            if(postId.HasValue && post == null)
            {
                comment.Likes.Add(likeToAdd);
            }
            if(commentId.HasValue && comment == null)
            {
                post.Likes.Add(likeToAdd);
            }
            unitOfWork.Likes.Add(likeToAdd);
            unitOfWork.SaveChanges();

            return (int)StatusCodes.SuccessOperation;
        }
    
            public int DeleteLike(int? likeId, int? userId)
            {
                if (!likeId.HasValue || !userId.HasValue)
                {                   
                    return (int)StatusCodes.InvalidCredentialError;
            }                
                var likeToDelete = unitOfWork.Likes.GetById(likeId.Value);

                if (likeToDelete == null || likeToDelete.UserId != userId)
                {
                    return (int)StatusCodes.NotFoundError;
                }
                unitOfWork.Likes.Delete(likeToDelete);
                unitOfWork.SaveChanges();

                return (int)StatusCodes.SuccessOperation;
            }
    }
}
