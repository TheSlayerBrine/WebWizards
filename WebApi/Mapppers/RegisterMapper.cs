using WebWizards.Services.ServiceObjects.Auth;
using WebWizards.WebApi.Models.Auth;

namespace WebWizards.WebApi.Mapppers
{
    public static class RegisterMapper
    {
        public static RegisterDto ToDto(this RegisterRequest model)
        {
            if(model == null)
            {
                return null;
            }
            return new RegisterDto
            {
                Name = model.Username,
                Email = model.Email,
                Password = model.Password,

            };
        }
    }
}
