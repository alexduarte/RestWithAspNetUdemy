using Microsoft.Extensions.Logging;
using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Repository.Interfaces;
using RestWithAspNetUdemy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.Services
{
    public class BookService : IBookService
    {

        private readonly IBookRepository _bookRepository;
        private readonly ILogger<BookService> _logger;

        public BookService(IBookRepository bookRepository, ILogger<BookService> logger)
        {
            _bookRepository = bookRepository;
            _logger = logger;
        }

        public async Task<Book> CreateAsync(Book book, CancellationToken cancellationToken) => await _bookRepository.CreateAsync(book, cancellationToken);

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken) => await _bookRepository.DeleteAsync(id, cancellationToken);

        public async Task<IEnumerable<Book>> GetAsync(CancellationToken cancellationToken) => await _bookRepository.GetAsync(cancellationToken);

        public async Task<Book> GetByIdAsync(Guid id, CancellationToken cancellationToken) => await _bookRepository.GetByIdAsync(id, cancellationToken);

        public async Task<Book> UpdateAsync(Book book, CancellationToken cancellationToken) => await _bookRepository.UpdateAsync(book, cancellationToken);        
    }
}
