using MediatR;

namespace BlogAPI.Features.Post.Commands.Delete
{
    public class DeletePostCommand: IRequest<DeletePostCommandResult>
    {
        public int Id { get; set; }
    }
}
