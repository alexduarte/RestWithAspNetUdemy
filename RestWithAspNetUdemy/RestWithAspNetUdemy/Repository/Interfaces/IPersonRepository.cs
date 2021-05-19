using RestWithAspNetUdemy.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.Repository.Interfaces
{
    public interface IPersonRepository
    {
        Task<Person> CreateAsync(Person person, CancellationToken cancellationToken);
        Task<Person> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Person> UpdateAsync(Person person, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Person>> GetAsync(CancellationToken cancellationToken);
        bool Exists(Guid id);

    }
}

