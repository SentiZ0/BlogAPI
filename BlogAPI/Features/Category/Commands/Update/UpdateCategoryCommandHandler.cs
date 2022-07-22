using BlogAPI.Models;
using MediatR;

namespace BlogAPI.Features.Category.Commands.Update
{
    public class UpdateCategoryCommandHandler : IRequestHandler<UpdateCategoryCommand, UpdateCategoryCommandResult>
    {
        private readonly BlogContext _context;

        public UpdateCategoryCommandHandler(BlogContext context)
        {
            _context = context;
        }

        public async Task<UpdateCategoryCommandResult> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = _context.Categories.Where(c => c.Id == request.Id).FirstOrDefault();

            if (category == null)
            {
                return null;
            }

            category.Name = request.Name;

            await _context.SaveChangesAsync();

            return new UpdateCategoryCommandResult();
        }
    }
}
