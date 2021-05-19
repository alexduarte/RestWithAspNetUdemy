using RestWithAspNetUdemy.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.Repository.Interfaces
{
    public interface IBookRepository
    {
        Task<Book> CreateAsync(Book book, CancellationToken cancellationToken);
        Task<Book> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Book> UpdateAsync(Book book, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Book>> GetAsync(CancellationToken cancellationToken);
        bool Exists(Guid id);
    }
}
