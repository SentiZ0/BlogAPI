using MediatR;

namespace BlogAPI.Features.Category.Commands.Delete
{
    public class DeleteCategoryCommand : IRequest<DeleteCategoryResult>
    {
        public int CategoryId { get; set; }
    }
}
