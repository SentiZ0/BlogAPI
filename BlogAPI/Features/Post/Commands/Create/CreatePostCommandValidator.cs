using FluentValidation;

namespace BlogAPI.Features.Post.Commands.Create
{
    public class CreatePostCommandValidator : AbstractValidator<CreatePostCommand>
    {
        public CreatePostCommandValidator()
        {
            RuleFor(x => x.Title).NotNull().Length(1, 50);
            RuleFor(x => x.Description).NotNull().Length(1, 50);
        }
    }
}
