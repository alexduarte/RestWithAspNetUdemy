using Microsoft.Extensions.DependencyInjection;
using RestWithAspNetUdemy.Services.Interfaces;

namespace RestWithAspNetUdemy.Services
{
    public static class ServicesDependencyInjection
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<IPersonService, PersonService>();
            services.AddScoped<IBookService, BookService>();
        }
    }
}
