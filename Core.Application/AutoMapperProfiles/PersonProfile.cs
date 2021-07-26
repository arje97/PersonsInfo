using AutoMapper;
using Core.Application.Dtos;
using Core.Domain;
namespace Core.Application.AutoMapperProfiles
{
    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<AddPersonDto, Person>();
            //   CreateMap<AddPersonDto, PhoneNumber> ();
            CreateMap<PhoneNumberDto, PhoneNumber>();
            CreateMap<UpdatePersonDto, Person>();
            CreateMap<PhoneNumber, PhoneNumberDto>();
            CreateMap<PersonRelation, PersonRilationDto>()
                 .ForMember(des => des.FirstName, opt => opt.MapFrom(src => src.RelatedPerson.FirstName))
                 .ForMember(des => des.LastName, opt => opt.MapFrom(src => src.RelatedPerson.LastName))
                 .ForMember(des => des.PrivateNumber, opt => opt.MapFrom(src => src.RelatedPerson.PrivateNumber))
                 .ForMember(des => des.PersonId, opt => opt.MapFrom(src => src.RelatedPerson.Id))
                 .ForMember(des => des.FirstName, opt => opt.MapFrom(opt => opt.RelatedPerson.FirstName))
                 .ForMember(des => des.LastName, opt => opt.MapFrom(opt => opt.RelatedPerson.LastName))
                 .ForMember(des => des.Gender, opt => opt.MapFrom(opt => opt.RelatedPerson.Gender))
                 .ForMember(des => des.BirthDate, opt => opt.MapFrom(opt => opt.RelatedPerson.BirthDate))
                 .ForMember(des => des.CityId, opt => opt.MapFrom(opt => opt.RelatedPerson.CityId))
               //  .ForMember(des => des.City, opt => opt.MapFrom(opt => opt.RelatedPerson.City.Name))
                 .ForMember(des => des.PicturePath, opt => opt.MapFrom(opt => opt.RelatedPerson.PicturePath))
                 .ForMember(des => des.PhoneNumbers, opt => opt.MapFrom(opt => opt.RelatedPerson.PhoneNumbers)); ;
            ;

            CreateMap<Person, GetPersonDto>()
                .ForMember(des => des.City, opt => opt.MapFrom(src => src.City.Name));

            CreateMap<PersonRelation, ReportDto>();
            //.ForMember(des => des.City, opt => opt.MapFrom(src => src.City.Name));

        }
    }
}
