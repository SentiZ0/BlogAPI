namespace BlogAPI.Models.ModelsDTO.PostDTO
{
    public class UpdatePostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public List<int> AuthorIds { get; set; }
    }
}
