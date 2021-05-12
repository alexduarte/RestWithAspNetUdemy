using RestWithAspNetUdemy.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.Services.Interfaces
{
    public interface IPersonService
    {
        Task<Person> CreateAsync(Person person, CancellationToken cancellationToken);
        Task<Person> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Person> UpdateAsync(Person person, CancellationToken cancellationToken);
        Task DeleteAsync(Guid id, CancellationToken cancellationToken);
        IEnumerable<Person> Get(CancellationToken cancellationToken);

    }
}

