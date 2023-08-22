namespace WebWizards.Services.ServiceObjects.Comments
{
    public class CommentDto
    {
        public int Id { get; set; } 
        public string Text { get; set; }
        public int PostId { get; set; }
        public int UserId { get; set; }
    }
}
