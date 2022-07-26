using FluentValidation;

namespace BlogAPI.Features.Author.Commands.Create
{
    public class CreateAuthorCommandValidator : AbstractValidator<CreateAuthorCommand>
    {
        public CreateAuthorCommandValidator()
        {
            RuleFor(x => x.Name).NotNull().Length(1, 20);
            RuleFor(x => x.Job).NotNull().Length(1, 50);
            RuleFor(x => x.Age).NotNull().InclusiveBetween(15, 99);
            RuleFor(x => x.Hobby).NotNull().Length(1, 50);
            RuleFor(x => x.Email).NotNull().Length(1, 50);
        }
    }
}
