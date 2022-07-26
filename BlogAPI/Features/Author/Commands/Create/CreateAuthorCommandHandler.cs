using AutoMapper;
using BlogAPI.Models;
using MediatR;

namespace BlogAPI.Features.Author.Commands.Create
{
    public class CreateAuthorCommandHandler : IRequestHandler<CreateAuthorCommand, CreateAuthorCommandResult>
    {
        private readonly IMapper _mapper;

        private readonly BlogContext _context;

        public CreateAuthorCommandHandler(BlogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateAuthorCommandResult> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            var author = _mapper.Map<Models.Author>(request);

            _context.Authors.Add(author);
            await _context.SaveChangesAsync();

            return new CreateAuthorCommandResult();
        }
    }
}
