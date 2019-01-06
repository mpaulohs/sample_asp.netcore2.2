using SampleOneDDD.Domain.Validations;

namespace SampleOneDDD.Domain.Commands
{
    public class RegisterNewBlogCommand : BlogCommand
    {
        public RegisterNewBlogCommand(string url)
        {
            Url = url;            
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewBlogCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}