using BlogAPI.Models;
using MediatR;

namespace BlogAPI.Features.Author.Queries.GetAll
{
    public class GetAllAuthorsQueryHandler : IRequestHandler<GetAllAuthorsQuery, GetAllAuthorsQueryResult>
    {
        private readonly BlogContext _context;

        public GetAllAuthorsQueryHandler(BlogContext context)
        {
            _context = context;
        }

        public Task<GetAllAuthorsQueryResult> Handle(GetAllAuthorsQuery request, CancellationToken cancellationToken)
        {
            var authors = _context.Authors.Select(x => new GetAllAuthorsQueryResult.AuthorDto
            {
                Id = x.Id,
                Name = x.Name,
                Email = x.Email,
                Age = x.Age,
                Hobby = x.Hobby,
                Job = x.Job,
                AuthorPosts = x.Author_Posts.Select(y => new GetAllAuthorsQueryResult.PostDto
                {
                    PostId = y.PostId,
                    Title = y.Post.Title,
                    Description = y.Post.Description,
                }).ToList(),
            }).ToList();

            return Task.FromResult(new GetAllAuthorsQueryResult
            {
                Authors = authors
            });
        }
    }
}
