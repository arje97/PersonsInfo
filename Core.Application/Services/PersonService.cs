using AutoMapper;
using Core.Application.Dtos;
using Core.Application.Filters;
using Core.Application.Interfaces;
using Core.Application.Interfaces.File;
using Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Application.Services
{
    public class PersonService
    {
        private readonly IFileService fileService;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public PersonService(IFileService fileService, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.fileService = fileService;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task Add(AddPersonDto addPersonDto)
        {
            var person = mapper.Map<Person>(addPersonDto);
            person.PhoneNumbers = mapper.Map<List<PhoneNumber>>(addPersonDto.PhoneNumbers);
            await unitOfWork.PersonRepository.AddAsync(person);
    

        }

        public async Task Update(int id, UpdatePersonDto updatePersonDto)
        {
            var person = mapper.Map<Person>(updatePersonDto);
            person.PhoneNumbers = mapper.Map<List<PhoneNumber>>(updatePersonDto.PhoneNumbers);
            await unitOfWork.PersonRepository.UpdateAsync(id, person);
     

        }

        public async Task<GetPersonDto> GetPersonById(int id)
        {
            var res = await unitOfWork.PersonRepository.GetPersonById(id);
            var result = mapper.Map<GetPersonDto>(res);
            return result;
        }
        public async Task<List<GetPersonDto>> GetPeopleWithFastSearch(PersonFastFilter personFastFilter)
        {
            var res = await unitOfWork.PersonRepository.GetPeopleWithFastSearch(personFastFilter);

            var result = mapper.Map<List<GetPersonDto>>(res);
            return result;
        }
        public async Task<List<GetPersonDto>> GetPeopleWithDetailSearch(PersonDetailFilter personDetailFilter)
        {
            var res = await unitOfWork.PersonRepository.GetPeopleWithDetailSearch(personDetailFilter);

            var result = mapper.Map<List<GetPersonDto>>(res);
            return result;
        }


        public async Task UploadPicture(UploadPictureDto uploadPictureDto)
        {
            Person person = await unitOfWork.PersonRepository.GetByIdAsync(uploadPictureDto.PersonId);

            fileService.DeleteFile(person.PicturePath);
            string filePath = await fileService.SaveFile(uploadPictureDto.File);
            person.PicturePath = filePath;

            await unitOfWork.PersonRepository.UpdateAsync(uploadPictureDto.PersonId, person);

        }
        public async Task AddRelatedPerson(AddPersonRelationDto addPersonRelationDto)
        {
            await unitOfWork.PersonRepository.AddRelatedPerson(addPersonRelationDto.PersonId, addPersonRelationDto.RelatedPersonId, addPersonRelationDto.ConnectionType);

        }
        public async Task AddNewRelatedPerson(PersonRilationDto addPersonRelationDto)
        {

            var person = mapper.Map<Person>(addPersonRelationDto);
            await unitOfWork.PersonRepository.AddNewRelatedPerson(addPersonRelationDto.PersonId, person, addPersonRelationDto.ConnectionType);

        }
        

        public async Task Delete(int id)
        {

            await unitOfWork.PhoneNumberRepository.DeletePhoneNumbersByPersonId(id);
            await unitOfWork.PersonRepository.DeleteAsync(id);
        }


        public IEnumerable<ReportDto> Report()
        {
            var res = unitOfWork.PersonReport.Report();
            return res;

        }

        public async Task  DeleteRelatedPerson( int personId, int relatedPersonId)
        {
            await unitOfWork.PersonRepository.DeleteRelatedPerson(personId, relatedPersonId);
           
        }



    }
}

