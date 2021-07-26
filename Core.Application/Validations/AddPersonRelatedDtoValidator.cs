using Core.Application.Dtos;
using Core.Application.Interfaces;
using FluentValidation;

namespace Core.Application.Validations
{
    public class AddPersonRelatedDtoValidator: AbstractValidator<AddPersonRelationDto>
    {

        public AddPersonRelatedDtoValidator(IUnitOfWork unitOfWork)
        {
            RuleFor(x => x.PersonId).MustAsync(async (id, cancellation) =>
            {
                bool exists = await unitOfWork.PersonRepository.ExistedAsync(id);
                return exists;
            }).WithMessage("მითითებული PersonId   არ არსებობს");

            RuleFor(x => x.RelatedPersonId).MustAsync(async (id, cancellation) =>
            {
                bool exists = await unitOfWork.PersonRepository.ExistedAsync(id);
                return exists;
            }).WithMessage("მითითებული RelatedPersonId   არ არსებობს");
        }
    }
}
