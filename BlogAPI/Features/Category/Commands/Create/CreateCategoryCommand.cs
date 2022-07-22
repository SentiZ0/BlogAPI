using MediatR;

namespace BlogAPI.Features.Category.Commands.Create
{
    public class CreateCategoryCommand : IRequest<CreateCategoryCommandResult>
    {
        public string Name { get; set; }
    }
}
