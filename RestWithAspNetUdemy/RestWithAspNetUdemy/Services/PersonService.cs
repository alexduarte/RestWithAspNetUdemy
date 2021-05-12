using RestWithAspNetUdemy.Infra.Context;
using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.Services
{
    public class PersonService : IPersonService
    {
        private readonly SQLContext _context;

        public PersonService(SQLContext context)
        {
            _context = context;
        }

        public Task<Person> CreateAsync(Person person, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(Guid id, CancellationToken cancellationToken)
        {            
            throw new NotImplementedException();
        }

        public IEnumerable<Person> Get(CancellationToken cancellationToken) =>
             _context.Persons.ToList();

        public Task<Person> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<Person> UpdateAsync(Person person, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
