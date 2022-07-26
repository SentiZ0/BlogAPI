namespace BlogAPI.Features.Author.Queries.GetAll
{
    public class GetAllAuthorsQueryResult
    {
        public List<AuthorDto> Authors { get; set; }

        public class AuthorDto
        {
            public int Id { get; set; }
            public string Name { get; set; }

            public int Age { get; set; }
            public string Email { get; set; }

            public string Job { get; set; }
            public string Hobby { get; set; }

            public List<PostDto> AuthorPosts { get; set; }
        }

        public class PostDto
        {
            public int PostId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
        }
    }
}
