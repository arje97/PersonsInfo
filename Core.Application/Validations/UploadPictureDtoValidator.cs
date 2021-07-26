using Core.Application.Dtos;
using Core.Application.Interfaces;
using FluentValidation;

namespace Core.Application.Validations
{
    public class UploadPictureDtoValidator : AbstractValidator<UploadPictureDto>
    {
   //     private readonly IUnitOfWork unitOfWork;

        public UploadPictureDtoValidator (IUnitOfWork unitOfWork)
        {
           // this.unitOfWork = unitOfWork;

            RuleFor(x => x.File).NotEmpty().WithMessage("გთხოვთ, ატვირთოთ სურათი ");
            RuleFor(x => x.PersonId).MustAsync(async (id, cancellation) => {
                bool exists = await unitOfWork.PersonRepository.ExistedAsync(id);
                return exists;
            }).WithMessage("მითითებული ფიზიკური პირის Id  არ არსებობს");

        }
    }
}
