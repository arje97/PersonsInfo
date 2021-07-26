using Core.Domain;
using System.Threading.Tasks;

namespace Core.Application.Interfaces.Repositories
{
    public interface IPhoneNumberRepository : IRepository<PhoneNumber>
    {
        Task DeletePhoneNumbersByPersonId(int personId);
    }
}
