namespace WebWizards.Data.Entities
{
    public class Post
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public string? Image {get; set; }
        public DateTime CreatedAt { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }     
        public List<Comment> Comments { get; set; }
        public List<Like> Likes { get; set; }

    }
}
