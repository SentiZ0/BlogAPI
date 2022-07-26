using BlogAPI.Models;
using MediatR;

namespace BlogAPI.Features.Post.Queries.GetSingle
{
    public class GetSinglePostQueryHandler : IRequestHandler<GetSinglePostQuery, GetSinglePostQueryResult>
    {
        private readonly BlogContext _context;

        public GetSinglePostQueryHandler(BlogContext context)
        {
            _context = context;
        }

        public Task<GetSinglePostQueryResult> Handle(GetSinglePostQuery request, CancellationToken cancellationToken)
        {
            var post = _context.Posts.Where(x => x.Id == request.Id).Select(x => new GetSinglePostQueryResult.PostDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                PostCreationDate = x.PostCreationDate,
                CategoryName = x.Category.Name
            }).FirstOrDefault();

            if (post == null)
            {
                return null;
            }

            return Task.FromResult(new GetSinglePostQueryResult
            {
                Post = post
            });
        }
    }
}
