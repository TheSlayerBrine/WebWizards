using WebWizards.Data.Entities;
using WebWizards.Services.ServiceObjects.Comments;
using WebWizards.Services.ServiceObjects.Posts;
using WebWizards.Services.ServiceObjects.Users;

namespace WebWizards.Services.ServiceObjects.Likes
{
    public class LikeDto
    {
        public int Id { get; set; }
        public UserDto User { get; set; }
        public int UserId { get; set; }
        public PostDto Post { get; set; }
        public int? PostId { get; set; }
        public CommentDto Comment { get; set; }
        public int? CommentId { get; set; }
    }
}
