using Microsoft.AspNetCore.Mvc;
using WebWizards.Data;
using WebWizards.Data.Entities;
using WebWizards.Services.Mappers;

namespace WebWizards.Services.ServiceObjects.Comments
{
    public class CommentService : ICommentService
    {
        private readonly IUnitOfWork unitOfWork;
        public CommentService(IUnitOfWork unitOfWork) 
        {  
            this.unitOfWork = unitOfWork;
        }

        public int ChangeText(int? commentId, CreateCommentDto commentDto)
        {
            if(commentId == null )
            {
                return (int)StatusCodes.NotFoundError;
            }
            if (commentDto == null)
            {
                return (int)StatusCodes.InvalidCredentialError;
            }
            var comment = unitOfWork.Comments.GetById(commentId.Value);
            if(!string.IsNullOrEmpty(comment.Text) )
            {
                comment.Text = commentDto.Text;   
            }
            unitOfWork.Comments.Update(comment);
            unitOfWork.SaveChanges();
            return (int)StatusCodes.SuccessOperation;
        }

        public int CreateComment(CreateCommentDto commentDto, int? userId, int? postId)
        {
            if(commentDto is null)
            {
                return (int)StatusCodes.InvalidCredentialError;
            }
            var user = unitOfWork.Users.GetById(userId.Value);
            var post = unitOfWork.Posts.GetById(postId.Value);
            if(user is not null && post is not null)
            {
                var commentToAdd = new Comment
                {
                    UserId = user.Id,
                    PostId = post.Id,
                    Text = commentDto.Text,
                    CreatedAt = DateTime.UtcNow,
                };
                commentToAdd.User = user;
                commentToAdd.Post = post;
                if(user.Comments is null)
                {
                    user.Comments = new List<Comment>();
                }
                if(post.Comments is null)
                {
                    post.Comments = new List<Comment>();
                }
                user.Comments.Add(commentToAdd);
                post.Comments.Add(commentToAdd);
                unitOfWork.Comments.Add(commentToAdd);
                unitOfWork.SaveChanges();
                return (int)StatusCodes.SuccessOperation;
            }
            return (int)StatusCodes.BadRequestError;
        }

        public int DeleteComment(int? commentId)
        {
            if(!commentId.HasValue)
            {
                return (int)StatusCodes.NotFoundError;
            }
            var comment = unitOfWork.Comments.GetById(commentId.Value);
            if(comment is null)
            {
                return (int)StatusCodes.NotFoundError;
            }
            unitOfWork.Comments.Delete(comment);
            unitOfWork.SaveChanges();
            return (int)StatusCodes.SuccessOperation;
        }
        public CommentDto GetDetails(int? commentId)
        {
            var comment = unitOfWork.Comments.GetById(commentId.Value);
            return comment.ToDto();
        }
    }
}
