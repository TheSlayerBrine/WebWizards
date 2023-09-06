using WebWizards.Data.Entities;
using WebWizards.Services.ServiceObjects.Likes;
using WebWizards.Services.ServiceObjects.Posts;
using WebWizards.Services.ServiceObjects.Users;

namespace WebWizards.Services.ServiceObjects.Comments
{
    public class CommentDto
    {
        public CommentDto() 
        {
            Likes = new List<LikeDto>();
        }
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public List<LikeDto> Likes { get; set; }
    }
}
