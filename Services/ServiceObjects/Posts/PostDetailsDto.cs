using Microsoft.Extensions.Primitives;

namespace WebWizards.Services.ServiceObjects.Posts
{
    public class PostDetailsDto
    {
        public string Text { get; set; }
        public string? Image { get; set; }
    }
}
