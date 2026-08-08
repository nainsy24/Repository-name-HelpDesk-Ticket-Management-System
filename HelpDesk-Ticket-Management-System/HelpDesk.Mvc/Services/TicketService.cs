using System.Net.Http.Json;
using HelpDesk.Mvc.Models;

namespace HelpDesk.Mvc.Services
{
    public class TicketService : ITicketService
    {
        private readonly HttpClient _httpClient;

        public TicketService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Ticket>> GetAllTicketsAsync()
        {
            return await _httpClient.GetFromJsonAsync<List<Ticket>>("api/Ticket/All")
                   ?? new List<Ticket>();
        }

        public async Task<Ticket?> GetTicketByIdAsync(int id)
        {
            return await _httpClient.GetFromJsonAsync<Ticket>($"api/Ticket/{id}");
        }

        public async Task<List<Ticket>> GetTicketsByStatusAsync(string status)
        {
            if (string.IsNullOrWhiteSpace(status))
            {
                return await GetAllTicketsAsync();
            }

            return await _httpClient.GetFromJsonAsync<List<Ticket>>
                ($"api/Ticket/Status/{status}") ?? new List<Ticket>();
        }

        public async Task CreateTicketAsync(Ticket ticket)
        {
            await _httpClient.PostAsJsonAsync("api/Ticket", ticket);
        }

        public async Task UpdateTicketAsync(Ticket ticket)
        {
            await _httpClient.PutAsJsonAsync($"api/Ticket/{ticket.Id}", ticket);
        }

        public async Task DeleteTicketAsync(int id)
        {
            await _httpClient.DeleteAsync($"api/Ticket/{id}");
        }
    }
}
