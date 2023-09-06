using WebWizards.Data.Entities;

namespace WebWizards.WebApi.Models
{
    public class LikeModel
    {
        public int Id { get; set; }
 
        public int UserId { get; set; }
        public int? PostId { get; set; }
   
        public int? CommentId { get; set; }
    }
}
