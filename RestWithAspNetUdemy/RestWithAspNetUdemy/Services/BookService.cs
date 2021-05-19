using AutoMapper;
using Microsoft.Extensions.Logging;
using RestWithAspNetUdemy.DataComunication;
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
        private IMapper _mapper;

        public BookService(IBookRepository bookRepository, ILogger<BookService> logger, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<BookDto> CreateAsync(BookDto book, CancellationToken cancellationToken) => _mapper.Map<BookDto>(await _bookRepository.CreateAsync(_mapper.Map<Book>(book), cancellationToken));

        public async Task<bool> DeleteAsync(Guid id, CancellationToken cancellationToken) => await _bookRepository.DeleteAsync(id, cancellationToken);

        public async Task<IEnumerable<BookDto>> GetAsync(CancellationToken cancellationToken) => _mapper.Map<IEnumerable<BookDto>>(await _bookRepository.GetAsync(cancellationToken));

        public async Task<BookDto> GetByIdAsync(Guid id, CancellationToken cancellationToken) => _mapper.Map<BookDto>(await _bookRepository.GetByIdAsync(id, cancellationToken));

        public async Task<BookDto> UpdateAsync(BookDto book, CancellationToken cancellationToken) => _mapper.Map<BookDto>(await _bookRepository.UpdateAsync(_mapper.Map<Book>(book), cancellationToken));        
    }
}
