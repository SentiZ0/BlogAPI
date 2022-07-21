namespace BlogAPI.Models.ModelsDTO.PostDTO
{
    public class CreatePostDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostCreationDate { get; set; }

        public List<int> AuthorIds { get; set; }

        public int CategoryId { get; set; }
    }
}
