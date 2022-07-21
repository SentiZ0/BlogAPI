namespace BlogAPI.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostCreationDate { get; set; }
        
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public List<Author_Post> Author_Posts { get; set; }
    }
}
