using MediatR;

namespace BlogAPI.Features.Post.Commands.Update
{
    public class UpdatePostCommand : IRequest<UpdatePostCommandResult>
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime PostCreationDate { get; set; }

        public int CategoryId { get; set; }

        public List<int> AuthorIds { get; set; }
    }
}
