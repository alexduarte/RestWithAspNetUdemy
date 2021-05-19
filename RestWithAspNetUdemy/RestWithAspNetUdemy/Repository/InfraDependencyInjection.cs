using Microsoft.Extensions.DependencyInjection;
using RestWithAspNetUdemy.Repository.Base;
using RestWithAspNetUdemy.Repository.Interfaces;

namespace RestWithAspNetUdemy.Repository
{
    public static class InfraDependencyInjection
    {
        public static void AddInfra(this IServiceCollection services)
        {           
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
            services.AddScoped(typeof(IRepository<>), typeof(BaseRepository<>));
        }
    }
}
