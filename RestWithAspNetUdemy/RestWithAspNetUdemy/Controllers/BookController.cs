using Microsoft.AspNetCore.Mvc;
using RestWithAspNetUdemy.DataComunication;
using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Services.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/[controller]/v{version:apiVersion}")]
    public class BookController : Controller
    {
        private readonly IBookService _service;

        public BookController(IBookService service)
        {
            _service = service;
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var book = await _service.GetByIdAsync(id, cancellationToken);

            if (book == null)
                return NotFound();

            return Ok(book);
        }

        [HttpGet()]
        public async Task<IActionResult> GetAsync(CancellationToken cancellationToken)
        {
            var books = await _service.GetAsync(cancellationToken);

            if (!books.Any())
                return NoContent();

            return Ok(books);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateAsync([FromBody] BookDto book, CancellationToken cancellationToken)
        {
            var bookCreated = await _service.CreateAsync(book, cancellationToken);

            if (bookCreated == null) return BadRequest("Error: Book not create! Please, try again");

            return Ok(bookCreated);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateAsync([FromBody] BookDto book, CancellationToken cancellationToken)
        {
            var bookUpdated = await _service.UpdateAsync(book, cancellationToken);

            if (bookUpdated == null) return BadRequest("Error: Book not updated! Please, try again");

            return Ok(bookUpdated);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            var deleted = await _service.DeleteAsync(id, cancellationToken);
            if (!deleted)
                return BadRequest("Error: Book not deleted! Please, try again");

            return Accepted();
        }
    }
}
