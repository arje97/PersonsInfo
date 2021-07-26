using Core.Application.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infrastructure.Database.Implementations;
using Microsoft.EntityFrameworkCore;
using Core.Application.Interfaces.Repositories;

namespace Infrastructure.Database

{
    public static class ServiceExtensions
    {

        public static void AddDbLayer(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<PersonDbContext>(x => x.UseSqlServer(configuration.GetConnectionString("PersonDbConnection")));
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped<IPhoneNumberRepository, PhoneNumberRepository>();
            services.AddScoped<IPersonReport, PersonReport>();
            services.AddScoped<ICityRepository, CityRepository>();
        }
    }


}

