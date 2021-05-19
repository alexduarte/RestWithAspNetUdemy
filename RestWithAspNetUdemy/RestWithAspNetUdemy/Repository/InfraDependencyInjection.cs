using Microsoft.Extensions.DependencyInjection;
using RestWithAspNetUdemy.Repository;
using RestWithAspNetUdemy.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.Repository
{
    public static class InfraDependencyInjection
    {
        public static void AddInfra(this IServiceCollection services)
        {
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IPersonRepository, PersonRepository>();
        }
    }
}
