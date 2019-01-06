using SampleOneDDD.Domain.Commands;

namespace SampleOneDDD.Domain.Validations
{
    public class RegisterNewBlogCommandValidation : BlogValidation<RegisterNewBlogCommand>
    {
        public RegisterNewBlogCommandValidation()
        {
             ValidateName();            
        }
    }
}