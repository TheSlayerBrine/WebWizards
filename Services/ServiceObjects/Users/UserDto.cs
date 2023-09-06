using WebWizards.Services.ServiceObjects.Comments;
using WebWizards.Services.ServiceObjects.Likes;
using WebWizards.Services.ServiceObjects.Posts;

namespace WebWizards.Services.ServiceObjects.Users
{
    public class UserDto
    {
           public UserDto() 
        {
            Comments = new List<CommentDto>();
            Likes = new List<LikeDto>();
            Posts = new List<PostDto>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<CommentDto> Comments { get; set; }
        public List<LikeDto> Likes { get; set; }
        public List<PostDto> Posts { get; set; }
        
    }
}
