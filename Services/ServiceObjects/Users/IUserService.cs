namespace WebWizards.Services.ServiceObjects.Users
{
    public interface IUserService
    {
        UserDto GetName(int userId);
        void ChangeName(int userId, UserDto userDto);
    }
}
