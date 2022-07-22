using BlogAPI.Models.ModelsDTO.Category;

namespace BlogAPI.Models.ModelsDTO.PostDTO
{
    public class GetPostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }
}
