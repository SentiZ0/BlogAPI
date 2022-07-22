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

        public Task<CreateAuthorCommandResult> Handle(CreateAuthorCommand request, CancellationToken cancellationToken)
        {
            
        }
    }
}
