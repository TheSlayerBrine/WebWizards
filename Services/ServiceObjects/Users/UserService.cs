using WebWizards.Data;
using WebWizards.Data.Entities;

namespace WebWizards.Services.ServiceObjects.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void ChangeName(int userId, UserDto userDto)
        {
            throw new NotImplementedException();
        }

       
public UserDto GetName(int? userId)
        {
            if (!userId.HasValue)
            {
                throw new SystemException("You're not logged in");
            }
            var user = unitOfWork.Users.GetById(userId.Value);

            if (user is null)
            {
                throw new EntityNotFoundException(userId.Value, typeof(User));
            }

            return user.ToDto();
        }
    }
}
