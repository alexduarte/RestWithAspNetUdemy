using RestWithAspNetUdemy.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.Services.Interfaces
{
    public interface IBookService
    {
        Task<Book> CreateAsync(Book book, CancellationToken cancellationToken);
        Task<Book> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<Book> UpdateAsync(Book book, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<Book>> GetAsync(CancellationToken cancellationToken);
    }
}
