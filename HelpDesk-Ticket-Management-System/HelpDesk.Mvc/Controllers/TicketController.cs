using HelpDesk.Mvc.Models;
using HelpDesk.Mvc.Services;
using Microsoft.AspNetCore.Mvc;

namespace HelpDesk.Mvc.Controllers
{
    public class TicketController : Controller
    {
        private readonly ITicketService _service;

        public TicketController(ITicketService service)
        {
            _service = service;
        }

        // Dashboard
        public async Task<IActionResult> Index()
        {
            var tickets = await _service.GetAllTicketsAsync();

            DashboardViewModel model = new DashboardViewModel
            {
                Tickets = tickets,
                TotalTickets = tickets.Count,
                OpenTickets = tickets.Count(t => t.Status == "Open"),
                ClosedTickets = tickets.Count(t => t.Status == "Closed"),
                InProgressTickets = tickets.Count(t => t.Status == "In Progress")
            };

            return View(model);
        }

        // Details
        public async Task<IActionResult> Details(int id)
        {
            var ticket = await _service.GetTicketByIdAsync(id);

            if (ticket == null)
                return NotFound();

            return View(ticket);
        }

        // Create
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Ticket ticket)
        {
            if (!ModelState.IsValid)
                return View(ticket);

            ticket.Status = "Open";

            await _service.CreateTicketAsync(ticket);

            return RedirectToAction(nameof(Index));
        }

        // Edit
        public async Task<IActionResult> Edit(int id)
        {
            var ticket = await _service.GetTicketByIdAsync(id);

            if (ticket == null)
                return NotFound();

            return View(ticket);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Ticket ticket)
        {
            if (!ModelState.IsValid)
                return View(ticket);

            await _service.UpdateTicketAsync(ticket);

            return RedirectToAction(nameof(Index));
        }

        // Delete
        public async Task<IActionResult> Delete(int id)
        {
            var ticket = await _service.GetTicketByIdAsync(id);

            if (ticket == null)
                return NotFound();

            return View(ticket);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteTicketAsync(id);

            return RedirectToAction(nameof(Index));
        }

        // Filter by Status
        public async Task<IActionResult> Filter(string? status)
        {
            List<Ticket> tickets;

            if (string.IsNullOrWhiteSpace(status))
            {
                tickets = await _service.GetAllTicketsAsync();
            }
            else
            {
                tickets = await _service.GetTicketsByStatusAsync(status);
            }

            DashboardViewModel model = new DashboardViewModel
            {
                Tickets = tickets,
                TotalTickets = tickets.Count,
                OpenTickets = tickets.Count(t => t.Status == "Open"),
                ClosedTickets = tickets.Count(t => t.Status == "Closed"),
                InProgressTickets = tickets.Count(t => t.Status == "In Progress")
            };

            return View("Index", model);
        }
    }
}
