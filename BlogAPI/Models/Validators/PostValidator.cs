using FluentValidation;

namespace BlogAPI.Models.Validators
{
    public class PostValidator : AbstractValidator<Post>
    {
        public PostValidator()
        {
            RuleFor(x => x.Title).NotNull().Length(1, 99);
            RuleFor(x => x.PostCreationDate).NotNull();
            RuleFor(x => x.Description).NotNull().Length(1, 300);
        }
    }
}
