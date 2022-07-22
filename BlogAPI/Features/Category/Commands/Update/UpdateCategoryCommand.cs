using MediatR;

namespace BlogAPI.Features.Category.Commands.Update
{
    public class UpdateCategoryCommand : IRequest<UpdateCategoryCommandResult>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
