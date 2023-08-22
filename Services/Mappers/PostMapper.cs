using WebWizards.Data.Entities;
using WebWizards.Services.ServiceObjects.Posts;

namespace WebWizards.Services.Mappers
{
    public static class PostMapper
    {
        public static PostDto ToDto(this Post entity)
        {
            if (entity is null)
            {
                return null;
            }
            return new PostDto
            {
                Id = entity.Id,
                Text = entity.Text,
                Image = entity.Image,
                CreatedAt = entity.CreatedAt,
                UserId = entity.UserId,
                User = entity.User.ToDto(),
            };
        }
        public static Post ToEntity(this PostDto dto)
        {
            if (dto is null)
            {
                return null;
            }

            return new Post
            {
                Id = dto.Id,
                Text = dto.Text,
                Image = dto.Image,
                CreatedAt = dto.CreatedAt,
                UserId = dto.UserId,
                User = dto.User.ToEntity()
            };
        }
    }
}
