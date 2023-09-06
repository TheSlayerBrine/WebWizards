using Humanizer;
using System.ComponentModel.DataAnnotations;
using WebWizards.Data;
using WebWizards.Data.Entities;
using WebWizards.Services.Mappers;
using WebWizards.Services.ServiceObjects.Auth;
using WebWizards.Services.ServiceObjects.Comments;
using WebWizards.Services.ServiceObjects.Likes;
using WebWizards.Services.ServiceObjects.Posts;

namespace WebWizards.Services.ServiceObjects.Users
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork unitOfWork;
        public UserService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public UserDto GetDetails(int? userId)
        {

            var user = unitOfWork.Users.GetById(userId.Value);
            return user.ToDto();
        }
        public int ChangeDetails(int? userId, UserDetailsDto userDto)
        {
            if (!userId.HasValue)
            {
                return (int)StatusCodes.NotFoundError;
            }

            if (userDto is null)
            {
                return (int)StatusCodes.InvalidCredentialError;
            }
            var user = unitOfWork.Users.GetById(userId.Value);
            var existingUser = unitOfWork.Users.GetByEmail(userDto.Name);
            if (existingUser is not null)
            {
                return (int)StatusCodes.ExistingInstanceWithSaidDetailsError;
            }
            if (!string.IsNullOrEmpty(userDto.Name))
            {
                user.Name = userDto.Name;
            }

            if (!string.IsNullOrEmpty(userDto.Email))
            {
                if (!IsValidEmail(userDto.Email))
                {
                    return (int)StatusCodes.InvalidCredentialError;
                }
                user.Email = userDto.Email;
            }
            unitOfWork.Users.Update(user);
            unitOfWork.SaveChanges();
            return (int)StatusCodes.SuccessOperation;
        }
        private bool IsValidEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }

        public int DeleteUser(int? userId)
        {
            if (!userId.HasValue)
            {
                return (int)StatusCodes.NotFoundError;
            }
            var user = unitOfWork.Users.GetById(userId.Value);
                if(user is null )
            {
                return (int)StatusCodes.NotFoundError;
            }
           
            unitOfWork.Users.Delete(user);
            unitOfWork.SaveChanges();
            return (int)StatusCodes.SuccessOperation;
        }
        public int CreateUser(RegisterDto userDto)
        {
            if (userDto == null || string.IsNullOrEmpty(userDto.Name) || string.IsNullOrEmpty(userDto.Email) || string.IsNullOrEmpty(userDto.Password))
            {
                return (int)StatusCodes.InvalidCredentialError;
            }
            var existingUserName = unitOfWork.Users.GetByName(userDto.Name);
            var existingUserEmail = unitOfWork.Users.GetByEmail(userDto.Email);
            if (existingUserName is not null || existingUserEmail is not null)
            {
                return (int)StatusCodes.ExistingInstanceWithSaidDetailsError;
            }
            var userToAdd = new User()
            {
                Name = userDto.Name,
                Email = userDto.Email,
                Password = userDto.Password,
                CreatedAt = DateTime.UtcNow,
            };           
            unitOfWork.Users.Add(userToAdd);
            unitOfWork.SaveChanges();
            return (int)StatusCodes.SuccessOperation;
        }
    }
}

