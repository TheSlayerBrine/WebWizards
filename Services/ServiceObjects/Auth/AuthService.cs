using System.ComponentModel.DataAnnotations;
using WebWizards.Data;

namespace WebWizards.Services.ServiceObjects.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly AppDbContext dbContext;
        public AuthService (IUnitOfWork unitOfWork, AppDbContext dbContext)
        {
            this.unitOfWork = unitOfWork;
            this.dbContext = dbContext;
        }
       
        public void RegisterUser(RegisterDto dto)
        {
            if(!IsValidEmail(dto.Email))
            {
                throw new SystemException("Invalid Email Address");
            }
            var existingUser = unitOfWork.Users.GetByEmail(dto.Name);
            if(existingUser == null)
            {
                throw new SystemException("Username already in use");
            }
        }
        public bool IsValidEmail(string email)
        {
            return new EmailAddressAttribute().IsValid(email);
        }
    }
}
