using HelpDesk.Api.Models;

namespace HelpDesk.Api.Repositories
{
    public interface ITicketRepository
    {
        Task<IEnumerable<Ticket>> GetAllAsync();

        Task<Ticket?> GetByIdAsync(int id);

        Task<IEnumerable<Ticket>> GetByStatusAsync(string status);

        Task<Ticket> AddAsync(Ticket ticket);

        Task UpdateAsync(Ticket ticket);

        Task DeleteAsync(int id);
    }
}
