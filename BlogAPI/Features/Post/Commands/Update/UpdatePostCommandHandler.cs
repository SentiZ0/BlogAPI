using BlogAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Features.Post.Commands.Update
{
    public class UpdatePostCommandHandler : IRequestHandler<UpdatePostCommand, UpdatePostCommandResult>
    {
        private readonly BlogContext _context;

        public UpdatePostCommandHandler(BlogContext context)
        {
            _context = context;
        }

        public async Task<UpdatePostCommandResult> Handle(UpdatePostCommand request, CancellationToken cancellationToken)
        {
            var authors = _context.Authors.AsNoTracking().Where(x => request.AuthorIds.Contains(x.Id)).Select(x => x.Id).ToList();
            if (authors.Count != request.AuthorIds.Count)
            {
                return null;
            }

            var category = _context.Categories.AsNoTracking().FirstOrDefault(x => x.Id == request.CategoryId);
            if (category == null)
            {
                return null;
            }

            var post = _context.Posts.Where(x => x.Id == request.Id).Include(a => a.Author_Posts).FirstOrDefault(x => x.Id == request.Id);

            post.Title = request.Title;
            post.Description = request.Description;
            post.CategoryId = request.CategoryId;

            post.Author_Posts.Clear();

            post.Author_Posts = authors.Select(x => new Author_Post
            {
                AuthorId = x
            }).ToList();

            _context.SaveChanges();

            return new UpdatePostCommandResult();
        }
    }
}
