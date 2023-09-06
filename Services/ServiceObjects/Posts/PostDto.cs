using WebWizards.Data.Entities;
using WebWizards.Services.ServiceObjects.Comments;
using WebWizards.Services.ServiceObjects.Likes;
using WebWizards.Services.ServiceObjects.Users;

namespace WebWizards.Services.ServiceObjects.Posts
{
    public class PostDto
    {
        public PostDto() 
        {
            Comments = new List<CommentDto>();
            Likes = new List<LikeDto>();
        }    
        public int Id { get; set; }
        public string Text { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public List<CommentDto> Comments { get; set; }
        public List<LikeDto> Likes { get; set; }
    }
}
