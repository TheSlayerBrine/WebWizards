using WebWizards.Services.ServiceObjects.Posts;

namespace WebWizards.Services.ServiceObjects.Comments
{
    public interface ICommentService
    {
        CommentDto GetDetails(int? commentId);
        int ChangeText(int? commentId, CreateCommentDto commentDto);
        int CreateComment(CreateCommentDto commentDto, int? postId, int? userId);
        int DeleteComment(int? commentId);  
    }
}
