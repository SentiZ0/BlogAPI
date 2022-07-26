using MediatR;

namespace BlogAPI.Features.Author.Commands.Delete
{
    public class DeleteAuthorCommand : IRequest<DeleteAuthorCommandResult>
    {
        public int Id { get; set; }
    }
}
