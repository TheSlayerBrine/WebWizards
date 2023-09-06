using WebWizards.Services.ServiceObjects.Comments;
using WebWizards.Services.ServiceObjects.Likes;
using WebWizards.Services.ServiceObjects.Posts;
using WebWizards.Services.ServiceObjects.Users;
using WebWizards.WebApi.Models;

namespace WebWizards.WebApi.Mapppers
{
    public static class UserMapper
    {
        public static UserModel ToApiModel(this UserDto dto)
        {
            if(dto == null)
            {
                return null;
            }
            return new UserModel
            {
                Id = dto.Id,
                Name = dto.Name,
                Email = dto.Email,
                CreatedAt = dto.CreatedAt,
                Comments = dto.Comments.Select(x => x.ToApiModel()).ToList(),
                Posts = dto.Posts.Select(p => p.ToApiModel()).ToList(),
                Likes = dto.Likes.Select(l => l.ToApiModel()).ToList(),
            };
        }
        public static UserDto ToDto(this UserModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new UserDto
            {
                Id = model.Id,
                Name = model.Name,
                Email = model.Email,
                CreatedAt = model.CreatedAt,
             Comments = model.Comments.Select(c => c.ToDto()).ToList(),
                Posts = model.Posts.Select(p => p.ToDto()).ToList(),
                Likes = model.Likes.Select(l => l.ToDto()).ToList()
            };
        }
       
    }
}
