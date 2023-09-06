using Microsoft.AspNetCore.Mvc;
using WebWizards.Services.ServiceObjects.Comments;
using WebWizards.WebApi.Mapppers;
using WebWizards.WebApi.Models;

namespace WebWizards.WebApi.Controllers
{
    [Route("api/comments")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService commentService;
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }
        [HttpGet("GET")]
        public ActionResult<CommentModel> GetCommentDetails(int? commentId)
        {
            if(commentId == null)
            {
                return NotFound();
            }
            var commnentDto = commentService.GetDetails(commentId);
            if( commnentDto == null)
            {
                return NotFound();
            }
            return Ok(commnentDto.ToApiModel());
        }
        [HttpPost("CREATE")]
        public ActionResult<int> CreateComment(CreateCommentModel model, int? userId, int? postId)
        {
            var comment = model.ToDto();
            var statusCode = commentService.CreateComment(comment, userId, postId);
            return StatusCode(statusCode);
        }
        [HttpDelete("DELETE")]
        public ActionResult<int> DeleteComment(int? commentId)
        {
            var statusCode = commentService.DeleteComment(commentId);
            return StatusCode(statusCode);
        }
        [HttpPatch("UPDATE")]
        public ActionResult<int> ChangeComment( int? commentId, CreateCommentModel model)
        {
            var comment = model.ToDto();
            var statusCode = commentService.ChangeText(commentId, comment);
            return StatusCode(statusCode);
        }
    }
}
