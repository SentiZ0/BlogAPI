namespace BlogAPI.Models
{
    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Hobby { get; set; }

        public int Age { get; set; }

        public string Job { get; set; }

        public List<Author_Post> Author_Posts { get; set; }
    }
}
