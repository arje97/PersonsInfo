using Core.Application.Dtos;
using Core.Application.Interfaces;
using FluentValidation;
using System;
using System.Text.RegularExpressions;


namespace Core.Application.Validations
{
    public class AddPersonDtoValidator : AbstractValidator<AddPersonDto>
    {
        public AddPersonDtoValidator(IUnitOfWork unitOfWork)
        {

            RuleFor(x => x.FirstName).NotEmpty().WithMessage("აუცილებელი ველი")
            .Length(2, 50).WithMessage("ტექსტი უნდა მოიცავდეს 2დან 50 სიმბოლოს")
            .Must(CheckText).WithMessage("უნდა მოიცავდეს მხოლოდ ქართულ ან მხოლოდ ლათინურ ასოებს");



            RuleFor(x => x.LastName).NotEmpty().WithMessage("აუცილებელი ველი")
            .Length(2, 50).WithMessage("ტექსტი უნდა მოიცავდეს 2დან 50 სიმბოლოს")
            .Must(CheckText).WithMessage("უნდა მოიცავდეს მხოლოდ ქართულ ან მხოლოდ ლათინურ ასოებს");

            RuleFor(x => x.CityId).MustAsync(async (id, cancellation) =>
            {
                bool exists = await unitOfWork.PersonRepository.ExistedAsync(id);
                return exists;
            }).WithMessage("მითითებული ქალაქის Id   არ არსებობს");


            RuleFor(x => x.PrivateNumber).Length(0, 11).WithMessage("პირადი ნომერი უდან შეიცავდეს 11 სიმბოლოს").MustAsync(async (pn, cancellation) =>
            {
                bool exists = await unitOfWork.PersonRepository.CheckPrivateNumber(pn);
                return !exists;
            }).WithMessage("მითითებული პირადი ნომერი  უკვე არსებობს");

            RuleFor(x => x.BirthDate)
           .NotEmpty().WithMessage("აუცილებელი ველი")
           .Must(CheckBirthDate).WithMessage("ასაკი უნდა აღემატებოდეს 18 წელს");

        }
        private bool CheckBirthDate(DateTime birthDate)
        {
            return birthDate.AddYears(18) < DateTime.Now;
        }


        private bool CheckText(string text)
        {
            Regex r = new Regex("^[ა-ჰ]*$|^[a-zA-Z]*$");
            return r.IsMatch(text);


        }
    }



}
