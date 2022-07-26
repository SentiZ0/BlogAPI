using BlogAPI.Models;
using MediatR;

namespace BlogAPI.Features.Author.Commands.Update
{
    public class UpdateAuthorCommandHandler : IRequestHandler<UpdateAuthorCommand, UpdateAuthorCommandResult>
    {
        private readonly BlogContext _context;

        public UpdateAuthorCommandHandler(BlogContext context)
        {
            _context = context;
        }

        public async Task<UpdateAuthorCommandResult> Handle(UpdateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = _context.Authors.FirstOrDefault(x => x.Id == request.Id);

            if (author == null)
            {
                return null;
            }

            author.Name = request.Name;
            author.Email = request.Email;
            author.Age = request.Age;
            author.Hobby = request.Hobby;
            author.Job = request.Job;

            _context.SaveChanges();

            return new UpdateAuthorCommandResult();
        }
    }
}
