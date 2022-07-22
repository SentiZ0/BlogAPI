using BlogAPI.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace BlogAPI.Features.Category.Commands.Delete
{
    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand, DeleteCategoryResult>
    {
        private readonly BlogContext _context;

        public DeleteCategoryCommandHandler(BlogContext context)
        {
            _context = context;
        }

        public async Task<DeleteCategoryResult> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = await _context.Categories.Where(x => x.Id == request.CategoryId).FirstOrDefaultAsync(x => x.Id == request.CategoryId);

            if (category == null)
            {
                return null;
            }

            _context.Categories.Remove(category);
            await _context.SaveChangesAsync();

            return new DeleteCategoryResult();
        }
    }
}
