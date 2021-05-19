using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RestWithAspNetUdemy.Infra.Context;
using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly SQLContext _context;
        private readonly ILogger<BookRepository> _logger;

        public BookRepository(SQLContext context, ILogger<BookRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task<Book> CreateAsync(Book book, CancellationToken cancellationToken)
        {
            try
            {
                var personCreated = await _context.Books.AddAsync(book, cancellationToken);
                await _context.SaveChangesAsync(cancellationToken);
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
            var book = await _context.Books.FirstOrDefaultAsync(x => x.Id == id);
            _context.Books.Remove(book);
            await _context.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<IEnumerable<Book>> GetAsync(CancellationToken cancellationToken) =>
             await _context.Books.ToListAsync(cancellationToken);

        public async Task<Book> GetByIdAsync(Guid id, CancellationToken cancellationToken) =>
            await _context.Books.SingleOrDefaultAsync(x => x.Id == id, cancellationToken);

        public async Task<Book> UpdateAsync(Book book, CancellationToken cancellationToken)
        {
            try
            {
                if (!Exists(book.Id)) return null;
                var bookToUpdate = await _context.Books.FirstOrDefaultAsync(x => x.Id == book.Id);
                _context.Entry(bookToUpdate).CurrentValues.SetValues(book);
                await _context.SaveChangesAsync(cancellationToken);
                return book;

            }
            catch (Exception ex)
            {
                _logger.LogError($"Error updating person: {ex}");
                return null;
            }
        }

        public bool Exists(Guid id) => _context.Books.Any(x => x.Id == id);
    }
}
