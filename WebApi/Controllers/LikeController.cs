using Microsoft.AspNetCore.Mvc;
using WebWizards.Services.ServiceObjects.Likes;
using WebWizards.WebApi.Models;

namespace WebWizards.WebApi.Controllers
{
    [Route("api/likes")]
    public class LikeController : ControllerBase
    {
        private readonly ILikeService likeService;

        public LikeController(ILikeService likeService)
        {
            this.likeService = likeService;
        }
        [HttpPost("CREATE")]
        public IActionResult CreateLike([FromBody] LikeModel model)
        {
            int statusCode = likeService.CreateLike(model.UserId, model.PostId, model.CommentId);
            return StatusCode(statusCode);
        }
        [HttpDelete("DELETE")]
        public IActionResult DeleteLike(int? likeId, int? userId)
        {
            int statusCode = likeService.DeleteLike(likeId, userId);
            return StatusCode(statusCode);
        }
    }
}
