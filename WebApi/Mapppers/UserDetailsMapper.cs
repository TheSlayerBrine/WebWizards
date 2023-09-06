using WebWizards.Services.ServiceObjects.Users;
using WebWizards.WebApi.Models;

namespace WebWizards.WebApi.Mapppers
{
    public static class UserDetailsMapper
    {
        public static UserDetailsModel ToApiModel(this UserDetailsDto dto)
        {
            if (dto == null)
            {
                return null;
            }
            return new UserDetailsModel
            {
               
                Name = dto.Name,
                Email = dto.Email,
               
            };
        }
        public static UserDetailsDto ToDto(this UserDetailsModel model)
        {
            if (model == null)
            {
                return null;
            }
            return new UserDetailsDto
            {
               
                Name = model.Name,
                Email = model.Email,               
            };
        }
    }
}
