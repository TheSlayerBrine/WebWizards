using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebWizards.Data.Entities;

namespace WebWizards.WebApi.Models
{
    public class UserModel 
    {
        public int Id { get; set; } 
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public List<CommentModel> Comments { get; set; }
        public List<PostModel> Posts { get; set; }
        public List<LikeModel> Likes { get; set; }
    }
}
