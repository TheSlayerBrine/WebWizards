using WebWizards.Data.Entities;

namespace WebWizards.WebApi.Models
{
    public class LikeModel
    {
        public int Id { get; set; }
        public UserModel User { get; set; }
        public int UserId { get; set; }
        public PostModel Post { get; set; }
        public int? PostId { get; set; }
        public CommentModel Comment { get; set; }
        public int? CommentId { get; set; }
    }
}
