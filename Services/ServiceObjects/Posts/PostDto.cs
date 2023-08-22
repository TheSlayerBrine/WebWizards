using WebWizards.Services.ServiceObjects.Users;

namespace WebWizards.Services.ServiceObjects.Posts
{
    public class PostDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string? Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public int UserId { get; set; }
        public UserDto User { get; set; }
    }
}
