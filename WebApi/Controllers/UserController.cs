    using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebWizards.Data.Entities;
using WebWizards.Services.ServiceObjects.Users;
using WebWizards.WebApi.Mapppers;
using WebWizards.WebApi.Models;
using WebWizards.WebApi.Models.Auth;

namespace WebWizards.WebApi.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }
        [HttpGet("GET")]
        public ActionResult<UserModel> GetUserDetails(int? userId)
        {
            if(userId == null)
            {
                return NotFound();
            }
           
            var userDto = userService.GetDetails(userId);
            if (userDto is null)
            {
                return NotFound();
            }
            return Ok(userDto.ToApiModel());
        }
        [HttpPatch("UPDATE")]
        public ActionResult<int> ChangeUserDetails(int? userId, [FromBody] UserDetailsModel userModel)
        {
           var statusCode = userService.ChangeDetails(userId, userModel.ToDto());
           return StatusCode(statusCode);
        }
        [HttpDelete("DELETE")]
        public ActionResult<int> DeleteUser(int? userId) 
        {
            var statusCode = userService.DeleteUser(userId);
            return StatusCode(statusCode);
        }
        [HttpPost("CREATE")]
        public ActionResult<int> CreateUser([FromBody] RegisterRequest request)
        {
            var user = request.ToDto();
            var statusCode = userService.CreateUser(user);
            return StatusCode(statusCode);

        }
    }
}
