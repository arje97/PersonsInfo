using Core.Domain;
using System;
using System.Collections.Generic;

namespace Core.Application.Dtos
{
    public class PersonRilationDto : AddPersonRelationDto
    {

       
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string PrivateNumber { get; set; }
  
        public DateTime BirthDate { get; set; }
        public Gender Gender { get; set; }
        public IEnumerable<PhoneNumberDto> PhoneNumbers { get; set; }

        public int CityId { get; set; }
       // public string City { get; set; }

        public string PicturePath { get; set; }


    }
}
