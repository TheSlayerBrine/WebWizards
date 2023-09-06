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
            if (entity.Likes is null)
            {
                entity.Likes = new List<Like>();
            }
            if (entity.Comments is null)
            {
                entity.Comments = new List<Comment>();
            }
            return new PostDto
            {
                Id = entity.Id,
                Text = entity.Text,
                Image = entity.Image,
                CreatedAt = entity.CreatedAt,
                UserId = entity.UserId,
                Comments = entity.Comments.Select(c => c.ToDto()).ToList(),
                Likes = entity.Likes.Select(l => l.ToDto()).ToList()
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
                Comments = dto.Comments.Select(c => c.ToEntity()).ToList(),
                Likes = dto.Likes.Select(l => l.ToEntity()).ToList()
            };
        }
    }
}
