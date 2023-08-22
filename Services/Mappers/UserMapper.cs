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
            return new UserDto
            {
                Id = entity.Id,
                Name = entity.Name,
                Email = entity.Email,
                Password = entity.Password,
                CreatedAt = entity.CreatedAt
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
                CreatedAt = dto.CreatedAt
            };
        }
    }
}
