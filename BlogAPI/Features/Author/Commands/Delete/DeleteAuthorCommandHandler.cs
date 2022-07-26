using BlogAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Features.Author.Commands.Delete
{
    public class DeleteAuthorCommandHandler : IRequestHandler<DeleteAuthorCommand, DeleteAuthorCommandResult>
    {
        private readonly BlogContext _context;

        public DeleteAuthorCommandHandler(BlogContext context)
        {
            _context = context;
        }

        public async Task<DeleteAuthorCommandResult> Handle(DeleteAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = await _context.Authors.Where(x => x.Id == request.Id).Include(x => x.Author_Posts).FirstOrDefaultAsync(x => x.Id == request.Id);

            if(author == null)
            {
                return null;
            }


            var postIds = author.Author_Posts;

            foreach (var postId in postIds)
            {
                var post = _context.Posts.Include(x => x.Author_Posts).FirstOrDefault(x => x.Id == postId.PostId);

                if (post.Author_Posts.Count == 1)
                {
                    _context.Posts.Remove(post);
                }
            }

            _context.Authors.Remove(author);

            await _context.SaveChangesAsync();

            return new DeleteAuthorCommandResult();
        }
    }
}
