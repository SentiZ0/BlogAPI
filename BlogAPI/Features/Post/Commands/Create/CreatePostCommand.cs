using MediatR;

namespace BlogAPI.Features.Post.Commands.Create
{
    public class CreatePostCommand : IRequest<CreatePostCommandResult>
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostCreationDate { get; set; }

        public int CategoryId { get; set; }

        public List<int> AuthorIds { get; set; }
    }
}
