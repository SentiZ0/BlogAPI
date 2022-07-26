namespace BlogAPI.Features.Post.Queries.GetSingle
{
    public class GetSinglePostQueryResult
    {
        public PostDto Post { get; set; }

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
