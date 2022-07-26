using BlogAPI.Models;
using MediatR;

namespace BlogAPI.Features.Post.Queries.GetAll
{
    public class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, GetAllPostsQueryResult>
    {
        private readonly BlogContext _context;

        public GetAllPostsQueryHandler(BlogContext context)
        {
            _context = context;
        }

        public Task<GetAllPostsQueryResult> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = _context.Posts.Select(x => new GetAllPostsQueryResult.PostDto
            {
                Id = x.Id,
                Title = x.Title,
                Description = x.Description,
                PostCreationDate = x.PostCreationDate,
                CategoryName = x.Category.Name
            }).ToList();

            if (posts == null)
            {
                return null;
            }

            return Task.FromResult(new GetAllPostsQueryResult
            {
                Posts = posts
            });
        }
    }
}
