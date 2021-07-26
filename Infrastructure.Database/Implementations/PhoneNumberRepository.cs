using Core.Application.Interfaces.Repositories;
using Core.Domain;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Database.Implementations
{
    class PhoneNumberRepository : Repository<PhoneNumber>, IPhoneNumberRepository
    {
        public PhoneNumberRepository(PersonDbContext context) : base(context)
        {
           
        }
        public async Task DeletePhoneNumbersByPersonId(int personId)
        {
            var phoneNumbers = context.PhoneNumbers.Where(x => x.PersonId == personId).ToList();
            foreach (var item in phoneNumbers)
            {
                await DeleteAsync(item.Id);
            }
        }
    }
}
