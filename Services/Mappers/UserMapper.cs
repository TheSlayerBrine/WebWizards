using System.Xml;
using WebWizards.Data.Entities;
using WebWizards.Services.ServiceObjects.Users;

namespace WebWizards.Services.Mappers
{
    public static class UserMapper
    {
        public static UserDto ToDto(this User entity)
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
            if (entity.Posts is null)
            {
                entity.Posts = new List<Post>();
            }
            return new UserDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Password = entity.Password,
                CreatedAt = entity.CreatedAt,
                Comments = entity.Comments.Select(c => c.ToDto()).ToList(),
                Posts = entity.Posts.Select(p => p.ToDto()).ToList(),
                Likes = entity.Likes.Select(l => l.ToDto()).ToList()
            };
        }
        public static User ToEntity(this UserDto dto)
        {
            if (dto is null)
            {
                return null;
            }

            return new User
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password,
                CreatedAt = dto.CreatedAt,
                Comments = dto.Comments.Select(c => c.ToEntity()).ToList(),
                Posts = dto.Posts.Select(p => p.ToEntity()).ToList(),
                Likes = dto.Likes.Select(l => l.ToEntity()).ToList()
            };
        }
    }
}
