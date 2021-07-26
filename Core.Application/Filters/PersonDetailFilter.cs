using System;

namespace Core.Application.Filters
{
    public  class PersonDetailFilter:PersonFastFilter
    {
        public string Gender { get; set; }

        public DateTime BirthDate { get; set; }
        public string City { get; set; }
        public string PhoneNumber { get; set; }
        public  string RelatedPeopleFullName { get; set; }
        public  string RelatedPeoplePrivateNumber { get; set; }
        public int CurrentPage { get; set; }
        public int ItemsPerPage { get; set; }
        


    }
}
