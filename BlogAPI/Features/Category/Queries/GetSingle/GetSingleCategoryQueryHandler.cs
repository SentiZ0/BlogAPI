using BlogAPI.Features.Category.Queries.Get;
using BlogAPI.Models;
using MediatR;

namespace BlogAPI.Features.Category.Queries.GetSingle
{
    public class GetSingleCategoryQueryHandler : IRequestHandler<GetSingleCategoryQuery, GetSingleCategoryQueryResult>
    {

        private readonly BlogContext _context;

        public GetSingleCategoryQueryHandler(BlogContext context)
        {
            _context = context;
        }

        public Task<GetSingleCategoryQueryResult> Handle(GetSingleCategoryQuery request, CancellationToken cancellationToken)
        {
            var category = _context.Categories.Where(x => x.Id == request.Id).Select(x => new GetSingleCategoryQueryResult.CategoryDto
            {
                CategoryId = x.Id,
                CategoryName = x.Name,
                Posts = x.Posts.Select(y => new GetSingleCategoryQueryResult.PostDto
                {
                    PostId = y.Id,
                    Title = y.Title,
                    Description = y.Description,
                }).ToList()
            }).FirstOrDefault();

            return Task.FromResult(new GetSingleCategoryQueryResult
            {
                Category = category
            });
        }
    }
}
