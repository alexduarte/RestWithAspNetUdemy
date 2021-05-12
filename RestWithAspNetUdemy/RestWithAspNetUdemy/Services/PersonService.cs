using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
        private readonly ILogger<PersonService> _logger;

        public PersonService(SQLContext context, ILogger<PersonService> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Person> CreateAsync(Person person, CancellationToken cancellationToken)
        {
            try
            {
                var personCreated = await _context.Persons.AddAsync(person);
                await _context.SaveChangesAsync();
                return personCreated.Entity;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error creating person: {ex}");
                return null;                
            }
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            if (!Exists(id)) return false;
            var person = await _context.Persons.FirstOrDefaultAsync(x => x.Id == id);            
            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<Person>> GetAsync(CancellationToken cancellationToken) =>
             await _context.Persons.ToListAsync();

        public async Task<Person> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
            await _context.Persons.SingleOrDefaultAsync(x => x.Id == id);

        public async Task<Person> UpdateAsync(Person person, CancellationToken cancellationToken)
        {
            try
            {
                if (!Exists(person.Id)) return null;
                var personToUpdate = await _context.Persons.FirstOrDefaultAsync(x => x.Id == person.Id);
                _context.Entry(personToUpdate).CurrentValues.SetValues(person);
                await _context.SaveChangesAsync();
                return person;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating person: {ex}");
                return null;
            }                        
        }

        private bool Exists(Guid id) => _context.Persons.Any(x => x.Id == id);
    }
}
