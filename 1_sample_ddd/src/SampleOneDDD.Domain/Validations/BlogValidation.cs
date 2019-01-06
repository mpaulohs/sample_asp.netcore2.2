using System;
using SampleOneDDD.Domain.Commands;
using FluentValidation;

namespace SampleOneDDD.Domain.Validations
{
    public abstract class BlogValidation<T> : AbstractValidator<T> where T : BlogCommand
    {
        protected void ValidateName()
        {
            RuleFor(c => c.Url)
                .NotEmpty().WithMessage("Please ensure you have entered the Name");
        }     
    }
}