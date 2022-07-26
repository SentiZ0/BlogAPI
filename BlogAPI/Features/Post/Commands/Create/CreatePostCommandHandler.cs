using AutoMapper;
using BlogAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Features.Post.Commands.Create
{
    public class CreatePostCommandHandler : IRequestHandler<CreatePostCommand, CreatePostCommandResult>
    {
        private readonly IMapper _mapper;
        private readonly BlogContext _context;

        public CreatePostCommandHandler(BlogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreatePostCommandResult> Handle(CreatePostCommand request, CancellationToken cancellationToken)
        {
            var authors = await _context.Authors.AsNoTracking().Where(x => request.AuthorIds.Contains(x.Id)).Select(x => x.Id).ToListAsync();

            if (authors.Count != request.AuthorIds.Count)
            {
                return null;
            }

            var category = await _context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == request.CategoryId);

            if (category == null)
            {
                return null;
            }

            var post = _mapper.Map<Models.Post>(request);

            post.Author_Posts = authors.Select(x => new Author_Post
            {
                AuthorId = x
            }).ToList();

            _context.Add(post);

            _context.SaveChanges();

            return new CreatePostCommandResult();
        }
    }
}
