using Core.Application.Dtos;
using FluentValidation;

namespace Core.Application.Validations
{
    public class PhoneNumberDtoValidator: AbstractValidator<PhoneNumberDto>
    {
        public PhoneNumberDtoValidator()
        {

            RuleFor(x => x.Number)
            .Length(4, 50).WithMessage("ნომერი  უნდა მოიცავდეს 2დან 50 სიმბოლოს");
            
        }
    }
}
