using Microsoft.Extensions.Logging;
using RestWithAspNetUdemy.Infra.Context;
using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Repository.Base;
using RestWithAspNetUdemy.Repository.Interfaces;

namespace RestWithAspNetUdemy.Repository
{
    public class PersonRepository : BaseRepository<Person>, IPersonRepository
    {
        public PersonRepository(SQLContext context, ILogger<Person> logger) : base(context, logger)
        {
        }
    }
}
