namespace WebWizards.Services.ServiceObjects.Posts
{
    public interface IPostService
    {
        int CreatePost(PostDetailsDto dto, int? userId);
        IEnumerable<PostDto> GetAllPostsOfUser(int? userId);
        PostDto GetDetails(int? postId);
        int ChangeDetails(int? postId, PostDetailsDto dto);
        int DeletePost(int? postId);
    }
}
