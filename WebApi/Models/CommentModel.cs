using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebWizards.Data.Entities;

namespace WebWizards.WebApi.Models
{
    public class CommentModel 
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public int PostId { get; set; }
        public List<LikeModel> Likes { get; set; }
    }
}
