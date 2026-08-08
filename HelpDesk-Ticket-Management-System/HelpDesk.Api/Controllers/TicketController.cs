using HelpDesk.Api.Models;
using HelpDesk.Api.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TicketController : ControllerBase
    {
        private readonly ITicketRepository _repository;

        public TicketController(ITicketRepository repository)
        {
            _repository = repository;
        }

        // GET: api/Ticket/All
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetAllTickets()
        {
            var tickets = await _repository.GetAllAsync();
            return Ok(tickets);
        }

        // GET: api/Ticket/1
        [HttpGet("{id}")]
        public async Task<ActionResult<Ticket>> GetTicketById(int id)
        {
            var ticket = await _repository.GetByIdAsync(id);

            if (ticket == null)
                return NotFound();

            return Ok(ticket);
        }

        // GET: api/Ticket/Status/Open
        [HttpGet("Status/{status}")]
        public async Task<ActionResult<IEnumerable<Ticket>>> GetTicketsByStatus(string status)
        {
            var tickets = await _repository.GetByStatusAsync(status);
            return Ok(tickets);
        }

        // POST: api/Ticket
        [HttpPost]
        public async Task<ActionResult<Ticket>> CreateTicket(Ticket ticket)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var createdTicket = await _repository.AddAsync(ticket);

            return CreatedAtAction(
                nameof(GetTicketById),
                new { id = createdTicket.Id },
                createdTicket);
        }

        // PUT: api/Ticket/1
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTicket(int id, Ticket ticket)
        {
            if (id != ticket.Id)
                return BadRequest();

            var existingTicket = await _repository.GetByIdAsync(id);

            if (existingTicket == null)
                return NotFound();

            existingTicket.Title = ticket.Title;
            existingTicket.Description = ticket.Description;
            existingTicket.Priority = ticket.Priority;
            existingTicket.Status = ticket.Status;
            existingTicket.RaisedBy = ticket.RaisedBy;

            await _repository.UpdateAsync(existingTicket);

            return NoContent();
        }

        // DELETE: api/Ticket/1
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTicket(int id)
        {
            var ticket = await _repository.GetByIdAsync(id);

            if (ticket == null)
                return NotFound();

            await _repository.DeleteAsync(id);

            return NoContent();
        }
    }
}
