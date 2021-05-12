using Microsoft.AspNetCore.Mvc;
using RestWithAspNetUdemy.Model;
using RestWithAspNetUdemy.Services.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithAspNetUdemy.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly IPersonService _personService;

        public PersonController(IPersonService personService)
        {
            _personService = personService;
        }

        [HttpGet("{id:Guid}")]
        public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            var person = await _personService.GetByIdAsync(id, cancellationToken);

            if (person == null)
                return NotFound();

            return Ok(person);
        }

        [HttpGet()]
        public IActionResult Get(CancellationToken cancellationToken)
        {
            var persons = _personService.Get(cancellationToken);

            if (!persons.Any())
                return NoContent();

            return Ok(persons);
        }

        [HttpPost()]
        public async Task<IActionResult> CreateAsync([FromBody] Person person, CancellationToken cancellationToken)
        {
            var personCreated = await _personService.CreateAsync( person, cancellationToken);

            if (personCreated == null) return BadRequest("Error: Person not create! Please, try again");

            return Ok(personCreated);
        }

        [HttpPut()]
        public async Task<IActionResult> UpdateAsync([FromBody] Person person, CancellationToken cancellationToken)
        {
            var personupDated = await _personService.UpdateAsync(person, cancellationToken);

            if (personupDated == null) return BadRequest("Error: Person not updated! Please, try again");

            return Ok(personupDated);
        }

        [HttpDelete("{id:Guid}")]
        public async Task<IActionResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
        {
            await _personService.DeleteAsync(id, cancellationToken);           

            return Accepted();
        }
    }
}
