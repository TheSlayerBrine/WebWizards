using Microsoft.EntityFrameworkCore.Query;
using WebWizards.Services.ServiceObjects.Auth;

namespace WebWizards.Services.ServiceObjects.Users
{
    public interface IUserService
    {
        UserDto GetDetails(int? userId);
        int ChangeDetails(int? userId, UserDetailsDto userDto);
        int DeleteUser(int? userId);
        int CreateUser(RegisterDto userdto);
    }
}
