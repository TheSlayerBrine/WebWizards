using Microsoft.AspNetCore.Mvc;
using WebWizards.Services.ServiceObjects.Posts;
using WebWizards.WebApi.Mapppers;
using WebWizards.WebApi.Models;

namespace WebWizards.WebApi.Controllers
{
    [Route("api/posts")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;
        public PostController(IPostService postService)
        {
            this.postService = postService;
        }
        [HttpGet("GET")]
        public ActionResult<PostModel> GetPostDetails(int? postId)
        {
            if(postId == null)
            {
                return NotFound();
            }
            var postDto = postService.GetDetails(postId);
            if(postDto == null)
            {
                return BadRequest();
            }
            return Ok(postDto.ToApiModel());
        }
        [HttpPost("CREATE")]
        public ActionResult<int> CreatePost ([FromBody] PostContentModel model, int? userId)
        {
            var post = model.ToDto();
            var statusCode = postService.CreatePost(post, userId);
            return StatusCode(statusCode);
        }
        [HttpDelete("DELETE")]
        public ActionResult<int> DeletePost(int? postId) 
        {
            var statusCode = postService.DeletePost(postId);
            return StatusCode(statusCode);
        }
        [HttpPatch("UPDATE")]
        public ActionResult<int> ChangePostContent(int? postId, [FromBody] PostContentModel model)
        {
            var statusCode = postService.ChangeDetails(postId, model.ToDto());
            return StatusCode(statusCode);
        }
    }
}
