using System;
using System.Collections.Generic;

namespace Core.Domain
{
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
    
        public string LastName { get; set; }
        public Gender Gender { get; set; }
      
        public string PrivateNumber { get; set; }
    
        public DateTime BirthDate { get; set; }
        public City City { get; set; }
        public int CityId { get; set; }
        public List<PhoneNumber> PhoneNumbers { get; set; }
     
        public string PicturePath { get; set; } 
        public List<PersonRelation> RelatedPeople { get; set; }

    }
}


