using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestWithAspNetUdemy.Infra.Context;
using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Repository.Interfaces;
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
        private readonly IPersonRepository _repository;
        private readonly ILogger<PersonService> _logger;

        public PersonService(IPersonRepository repository, ILogger<PersonService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public async Task<Person> CreateAsync(Person person, CancellationToken cancellationToken) => await _repository.CreateAsync(person, cancellationToken);

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken) => await _repository.DeleteAsync(id, cancellationToken);        

        public async Task<IEnumerable<Person>> GetAsync(CancellationToken cancellationToken) =>
             await _repository.GetAsync(cancellationToken);

        public async Task<Person> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
            await _repository.GetByIdAsync(id, cancellationToken);

        public async Task<Person> UpdateAsync(Person person, CancellationToken cancellationToken) => await _repository.UpdateAsync(person, cancellationToken);        
        
    }
}
