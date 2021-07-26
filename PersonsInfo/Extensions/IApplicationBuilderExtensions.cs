using Microsoft.AspNetCore.Builder;

using Presentation.PersonsInfoApi.Middlewares;

namespace Presentation.PersonsInfoApi.Extensions
{
    public static class IApplicationBuilderExtensions
    {
        public static void UsePersonExceptionHandler(this IApplicationBuilder app)
        {
            app.UseMiddleware<ExceptionHandler>();
        }
    }
}
