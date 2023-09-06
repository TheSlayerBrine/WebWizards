using WebWizards.Services.ServiceObjects.Posts;
using WebWizards.WebApi.Models;

namespace WebWizards.WebApi.Mapppers
{
    public static class PostContentMapper
    {
        public static PostDetailsDto ToDto(this PostContentModel model) 
        { 
            if (model == null)
            {
                return null;
            }
            return new PostDetailsDto
            {
                Text = model.Text,
                Image = model.Image,
            };
        }
    }
}
