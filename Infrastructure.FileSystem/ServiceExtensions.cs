using Core.Application.Interfaces.File;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure.FileSystem
{
    public static class ServiceExtensions
    {
        public static void AddFileSystemLayer(this IServiceCollection services, IConfiguration configuration)
        {
         
            services.AddScoped<IFileService, FileService>(option => new FileService(configuration["Files:Address"]));
        }
    }
}
