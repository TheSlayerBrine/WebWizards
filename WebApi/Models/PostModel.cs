using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebWizards.Data.Entities;

namespace WebWizards.WebApi.Models
{
   
    public class PostModel 
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public UserModel User { get; set; }
        public int UserId { get; set; }
    }
}
