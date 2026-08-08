using HelpDesk.Mvc.Models;

namespace HelpDesk.Mvc.Services
{
    public interface ITicketService
    {
        Task<List<Ticket>> GetAllTicketsAsync();

        Task<Ticket?> GetTicketByIdAsync(int id);

        Task<List<Ticket>> GetTicketsByStatusAsync(string status);

        Task CreateTicketAsync(Ticket ticket);

        Task UpdateTicketAsync(Ticket ticket);

        Task DeleteTicketAsync(int id);
    }
}
