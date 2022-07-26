using BlogAPI.Models;
using MediatR;

namespace BlogAPI.Features.Author.Queries.GetSingle
{
    public class GetSingleAuthorQueryHandler : IRequestHandler<GetSingleAuthorQuery, GetSingleAuthorQueryResult>
    {
        private readonly BlogContext _context;

        public GetSingleAuthorQueryHandler(BlogContext context)
        {
            _context = context;
        }

        public Task<GetSingleAuthorQueryResult> Handle(GetSingleAuthorQuery request, CancellationToken cancellationToken)
        {
            var author = _context.Authors.Where(x => x.Id == request.Id).Select(x => new GetSingleAuthorQueryResult.AuthorDto
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Age = x.Age,
                Hobby = x.Hobby,
                Job = x.Job,
                AuthorPosts = x.Author_Posts.Select(y => new GetSingleAuthorQueryResult.PostDto
                {
                    PostId = y.PostId,
                    Title = y.Post.Title,
                    Description = y.Post.Description,
                }).ToList(),
            }).FirstOrDefault();

            if(author == null)
            {
                return null;
            }

            return Task.FromResult(new GetSingleAuthorQueryResult
            {
                Author = author
            });
        }
    }
}
