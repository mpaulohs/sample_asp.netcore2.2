using demo.Application.Commands;
using FluentValidation;

namespace demo.Application.Validators
{
    public class CreateBlogCommndValidator : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogCommndValidator()
        {
            RuleFor(a => a.Url)
                .NotEmpty()
                .WithMessage("O Url é obrigatório");
        }
    }
}
