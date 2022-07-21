using FluentValidation;

namespace BlogAPI.Models.Validators
{
    public class AuthorValidator : AbstractValidator<Author>
    {
        public AuthorValidator()
        {
            RuleFor(x => x.Name).NotNull().Length(1, 50);
            RuleFor(x => x.Email).NotNull().Length(1, 50);
            RuleFor(x => x.Age).NotNull().InclusiveBetween(15, 99);
        }
    }
}
