using FluentValidation;

namespace BlogAPI.Features.Category.Commands.Create
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().Length(1, 50);
        }
    }
}
