using RestWithAspNetUdemy.DataComunication;
using RestWithAspNetUdemy.Model;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.Services.Interfaces
{
    public interface IBookService
    {
        Task<BookDto> CreateAsync(BookDto book, CancellationToken cancellationToken);
        Task<BookDto> GetByIdAsync(Guid id, CancellationToken cancellationToken);
        Task<BookDto> UpdateAsync(BookDto book, CancellationToken cancellationToken);
        Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken);
        Task<IEnumerable<BookDto>> GetAsync(CancellationToken cancellationToken);
    }
}
