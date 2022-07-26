namespace BlogAPI.Features.Post.Queries.GetAll
{
    public class GetAllPostsQueryResult
    {
        public List<PostDto> Posts { get; set; }

        public class PostDto
        {
            public int Id { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
            public DateTime PostCreationDate { get; set; }

            public string CategoryName { get; set; }
        }
    }
}
