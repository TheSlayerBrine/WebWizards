using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using WebWizards.Data;
using WebWizards.Data.Entities;
using WebWizards.Services.Mappers;
using WebWizards.Services.ServiceObjects.Users;

namespace WebWizards.Services.ServiceObjects.Posts
{
    public class PostService : IPostService
    {
        private readonly IUnitOfWork unitOfWork;
        public PostService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public int ChangeDetails(int? postId, PostDetailsDto postDto)
        {
            if (!postId.HasValue)
            {
                return (int)StatusCodes.NotFoundError;
            }

            if (postDto is null)
            {
                return (int)StatusCodes.InvalidCredentialError;
            }
            var post = unitOfWork.Posts.GetById(postId.Value);
            if (!string.IsNullOrEmpty(post.Text))
            {
                post.Text = postDto.Text;
            }
            if (!string.IsNullOrEmpty(post.Text))
            {
                post.Image = postDto.Image;
            }
            unitOfWork.Posts.Update(post);
            unitOfWork.SaveChanges();
            return (int)StatusCodes.SuccessOperation;
        }

        public int CreatePost(PostDetailsDto postDto, int? userId)
        {
            if (postDto == null || string.IsNullOrEmpty(postDto.Text))
            {
                return (int)StatusCodes.InvalidCredentialError;
            }
           
                var user = unitOfWork.Users.GetById(userId.Value);
            if (user is not null)
            {
                var postToAdd = new Post
                {
                    UserId = user.Id,
                    Text = postDto.Text,
                    CreatedAt = DateTime.Now,
                    Image = postDto.Image,

                };
                postToAdd.User = user;
                if(user.Posts is null)
                {
                    user.Posts = new List<Post>();
                }
                user.Posts.Add(postToAdd);
                unitOfWork.Posts.Add(postToAdd);
                unitOfWork.SaveChanges();
                return (int)StatusCodes.SuccessOperation;
            }
            return (int)StatusCodes.BadRequestError;           
        }

        public int DeletePost(int? postId)
        {
            if (!postId.HasValue)
            {
                return (int)StatusCodes.NotFoundError;
            }
            var post = unitOfWork.Posts.GetById(postId.Value);
            if (post is null)
            {
                return (int)StatusCodes.NotFoundError;
            }
            unitOfWork.Posts.Delete(post);
            unitOfWork.SaveChanges();
            return (int)StatusCodes.SuccessOperation;
        }

        public IEnumerable<PostDto> GetAllPostsOfUser(int? userId)
        {
            var user = unitOfWork.Users.GetById(userId.Value);
            return (IEnumerable<PostDto>)user.Posts;
        }

        public PostDto GetDetails(int? postId)
        {
            var post = unitOfWork.Posts.GetById(postId.Value);
            return post.ToDto();
        }
    }
}
