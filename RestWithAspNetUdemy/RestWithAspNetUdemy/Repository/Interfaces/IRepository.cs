using RestWithAspNetUdemy.Model.Base;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.Repository.Interfaces
{
    public interface IRepository<T> where T: BaseEntity
    {
        Task<T> CreateAsync(T item, CancellationToken cancellationToken);
        Task<T> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<T> UpdateAsync(T item, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<T>> GetAsync(CancellationToken cancellationToken);
        bool Exists(Guid id);
    }
}
