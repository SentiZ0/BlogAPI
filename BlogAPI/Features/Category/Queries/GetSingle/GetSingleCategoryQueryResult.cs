namespace BlogAPI.Features.Category.Queries.GetSingle
{
    public class GetSingleCategoryQueryResult
    {
        public CategoryDto Category { get; set; }

        public class CategoryDto
        {
            public int CategoryId { get; set; }

            public string CategoryName { get; set; }

            public List<PostDto> Posts { get; set; }
        }

        public class PostDto
        {
            public int PostId { get; set; }
            public string Title { get; set; }
            public string Description { get; set; }
        }
    }
}
