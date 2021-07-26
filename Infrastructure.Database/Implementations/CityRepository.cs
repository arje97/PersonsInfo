using Core.Application.Interfaces.Repositories;
using Core.Domain;

namespace Infrastructure.Database.Implementations
{
       class CityRepository : Repository<City>, ICityRepository
    {
        public CityRepository(PersonDbContext context) : base(context)
        {

        }

    }
}
