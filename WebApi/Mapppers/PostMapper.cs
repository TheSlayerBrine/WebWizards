using Humanizer;
using WebWizards.Services.ServiceObjects.Auth;
using WebWizards.Services.ServiceObjects.Posts;
using WebWizards.WebApi.Models;
using WebWizards.WebApi.Models.Auth;

namespace WebWizards.WebApi.Mapppers
{
    public static class PostMapper
    {
        public static PostDto ToDto(this PostModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new PostDto
            {
                Id = model.Id,
                Image = model.Image,
                Text = model.Text,
                CreatedAt = model.CreatedAt,
                UserId = model.UserId,
                Comments = model.Comments.Select(c => c.ToDto()).ToList(),
                Likes = model.Likes.Select(l => l.ToDto()).ToList()
            };
        }
        public static PostModel ToApiModel(this PostDto dto)
        {
            if (dto == null)
            {
                return null;
            }
            return new PostModel
            {
                Id = dto.Id,
                Image = dto.Image,
                Text = dto.Text,
                CreatedAt = dto.CreatedAt,
                UserId = dto.UserId,
                Comments = dto.Comments.Select(x => x.ToApiModel()).ToList(),
                Likes = dto.Likes.Select(l => l.ToApiModel()).ToList(),
            };
        }
    }
}
