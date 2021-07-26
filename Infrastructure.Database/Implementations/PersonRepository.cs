using Core.Application.Filters;
using Core.Application.Interfaces.Repositories;
using Core.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Infrastructure.Database.Implementations
{
    class PersonRepository : Repository<Person>, IPersonRepository
    {
        public PersonRepository(PersonDbContext context) : base(context)
        {

        }

        public async Task AddRelatedPerson(int personId, int relatedPersonId, ConnectionType connectionType)
        {
            var personRelation = new PersonRelation { PersonId = personId, RelatedPersonId = relatedPersonId, ConnectionType = connectionType };
            context.PersonRelations.Add(personRelation);
           await context.SaveChangesAsync();
        }

        public async Task AddNewRelatedPerson(int personId, Person relatedPerson, ConnectionType connectionType)
        {
            var personRelation = new PersonRelation { PersonId = personId, RelatedPerson = relatedPerson, ConnectionType = connectionType };
            context.PersonRelations.Add(personRelation);
           await context.SaveChangesAsync();
        }

        public async Task<bool> CheckPrivateNumber(string PrivateNumber)
        {
            if (await context.People.AnyAsync(x => x.PrivateNumber == PrivateNumber))
                return true;
            else
                return false;
        }

        public async Task DeleteRelatedPerson(int personId, int relatedPersonId)
        {
            var personRelation = context.PersonRelations.FirstOrDefault(x => x.PersonId == personId && x.RelatedPersonId == relatedPersonId);
            if (personRelation != null)
            {
                context.PersonRelations.Remove(personRelation);
              await  context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Person>> GetPeopleWithDetailSearch(PersonDetailFilter personDetailFilter)
        {

            var result = context.People.Include(x => x.PhoneNumbers).
                    Include(x => x.City).
                    Include(x => x.RelatedPeople).ToList().
                    Where(x =>
                    (personDetailFilter.FirstName == null || x.FirstName.Contains(personDetailFilter.FirstName))
                    && (personDetailFilter.LastName == null || x.LastName.Contains(personDetailFilter.LastName))
                    && (personDetailFilter.LastName == null || x.PrivateNumber.Contains(personDetailFilter.PrivateNumber))
                    && (personDetailFilter.Gender == null || x.Gender.ToString().Contains(personDetailFilter.Gender))
                    && (personDetailFilter.BirthDate == DateTime.MinValue || x.BirthDate.Date == personDetailFilter.BirthDate.Date)
                    && (personDetailFilter.PhoneNumber == null || x.PhoneNumbers.Any(x => x.Number.Contains(personDetailFilter.PhoneNumber))))
                    .Skip((personDetailFilter.CurrentPage - 1) * personDetailFilter.ItemsPerPage)
                .Take(personDetailFilter.ItemsPerPage).ToList();

            return result.ToList();
        }

        public async Task<IEnumerable<Person>> GetPeopleWithFastSearch(PersonFastFilter personFastFilter)
        {
            var result = context.People.Include(x => x.PhoneNumbers).
                 Include(x => x.City).
                 Include(x => x.RelatedPeople).ToList().
                 Where(x => (personFastFilter.FirstName == null || x.FirstName.Contains(personFastFilter.FirstName))
                 && (personFastFilter.LastName == null || x.LastName.Contains(personFastFilter.LastName))
                 && (personFastFilter.LastName == null || x.PrivateNumber.Contains(personFastFilter.PrivateNumber)));

            return result;
        }

        public async Task<Person> GetPersonById(int id)
        {
            var result = context.People.Include(x => x.PhoneNumbers).
                Include(x => x.City).
                Include(x => x.RelatedPeople).ToList().FirstOrDefault
                (x => x.Id == id);

            return result;
        }


        //public async Task<int> AddPersonReturnId(Person person)
        //{
        //    int returnedPersaonId = 0;
        //    await AddAsync(person);
        //    returnedPersaonId = context.People.OrderByDescending(x => x.Id).FirstOrDefault().Id;
        //    return returnedPersaonId;
        //}
    }
}
