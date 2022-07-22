using AutoMapper;
using BlogAPI.Models;
using MediatR;

namespace BlogAPI.Features.Category.Commands.Create
{
    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, CreateCategoryCommandResult>
    {
        private readonly BlogContext _context;
        private readonly IMapper _mapper;

        public CreateCategoryCommandHandler(BlogContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<CreateCategoryCommandResult> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _mapper.Map<Models.Category>(request);

            _context.Categories.Add(category);
            await _context.SaveChangesAsync();

            return new CreateCategoryCommandResult();
        }
    }
}
