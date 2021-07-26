using Core.Domain;
using System;
using System.Collections.Generic;

namespace Core.Application.Dtos
{
    public  class GetPersonDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public string PrivateNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public string PicturePath { get; set; }
        public string City { get; set; }
        public List<PhoneNumberDto> PhoneNumbers { get; set; }
        public List<PersonRilationDto> RelatedPeople { get; set; }
    }
}
