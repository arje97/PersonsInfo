using Core.Application.Dtos;
using Core.Application.Filters;
using Core.Domain;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.Repositories
{
    public interface IPersonRepository : IRepository<Person> {
        //  Task<int> AddPersonReturnId(Person person);

        Task<Person> GetPersonById(int id);
        Task<IEnumerable<Person>> GetPeopleWithFastSearch(PersonFastFilter personFastFilter);
        Task<IEnumerable<Person>> GetPeopleWithDetailSearch(PersonDetailFilter personDetailFilter);
        Task<bool> CheckPrivateNumber( string PrivateNumber);
        Task  AddRelatedPerson(int personId, int relatedPersonId, ConnectionType connectionType);
        Task AddNewRelatedPerson(int personId, Person relatedPerson, ConnectionType connectionType);
        Task  DeleteRelatedPerson(int personId, int relatedPersonId);


    }
}
