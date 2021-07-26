using Core.Application.Interfaces.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Database.Implementations
{
    class Repository<T> : IRepository<T> where T : class
    {
        protected PersonDbContext context;
        public Repository(PersonDbContext context)
        {
            this.context = context;
        }
        public async Task AddAsync(T entity)
        {

            await context.Set<T>().AddAsync(entity);
            await context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await context.Set<T>().FindAsync(id);
            if (entity != null)
            {
                context.Set<T>().Remove(entity);
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> ExistedAsync(int id)
        {
            var result = await context.Set<T>().FindAsync(id);
            if (result != null)
                return true;
            else
                return false;
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return context.Set<T>();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await context.Set<T>().FindAsync(id);

        }
        public async Task UpdateAsync(int id, T entity)
        {
            var existing = await context.Set<T>().FindAsync(id);
            context.Entry(existing).CurrentValues.SetValues(entity);
            await context.SaveChangesAsync();
        }
    }
}
