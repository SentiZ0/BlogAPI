using BlogAPI.Models;
using MediatR;

namespace BlogAPI.Features.Post.Commands.Delete
{
    public class DeletePostCommandHandler : IRequestHandler<DeletePostCommand, DeletePostCommandResult>
    {
        private readonly BlogContext _context;

        public DeletePostCommandHandler(BlogContext context)
        {
            _context = context;
        }

        public async Task<DeletePostCommandResult> Handle(DeletePostCommand request, CancellationToken cancellationToken)
        {
            var post = _context.Posts.Where(x => x.Id == request.Id).FirstOrDefault(x => x.Id == request.Id);

            if (post == null)
            {
                return null;
            }

            _context.Posts.Remove(post);

            await _context.SaveChangesAsync();

            return new DeletePostCommandResult();
        }
    }
}
