using BlogAPI.Models;
using MediatR;

namespace BlogAPI.Features.Category.Queries.GetAll
{
    public class GetAllCategoryQueryHandler : IRequestHandler<GetAllCategoryQuery, GetAllCategoryQueryResult>
    {
        private readonly BlogContext _context;

        public GetAllCategoryQueryHandler(BlogContext context)
        {
            _context = context;
        }

        public Task<GetAllCategoryQueryResult> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var categories = _context.Categories.Select(x => new GetAllCategoryQueryResult.CategoryDto
            {
                CategoryId = x.Id,
                CategoryName = x.Name,
                Posts = x.Posts.Select(y => new GetAllCategoryQueryResult.PostDto
                {
                    PostId = y.Id,
                    Title = y.Title,
                    Description = y.Description,
                }).ToList()
            }).ToList();

            return Task.FromResult(new GetAllCategoryQueryResult
            {
                Categories = categories
            });
        }
    }
}
