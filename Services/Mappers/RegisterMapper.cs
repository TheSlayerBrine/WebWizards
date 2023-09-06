using Microsoft.AspNetCore.Identity;
using WebWizards.Data.Entities;
using WebWizards.Services.ServiceObjects.Auth;

namespace WebWizards.Services.Mappers
{
    public static class RegisterMapper
    {
        public static User ToEntity(this RegisterDto dto)
        {
            if(dto == null)
            {
                return null;
            }
            return new User
            {
                Name = dto.Name,
                Email = dto.Email,
                Password = dto.Password
            };
        }
    }
}
