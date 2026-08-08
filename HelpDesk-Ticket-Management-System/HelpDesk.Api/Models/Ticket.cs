using System.ComponentModel.DataAnnotations;

namespace HelpDesk.Api.Models
{
    public class Ticket
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; } = "";

        [Required]
        public string Description { get; set; } = "";

        [Required]
        public string Priority { get; set; } = "";

        [Required]
        public string Status { get; set; } = "";

        [Required]
        public string RaisedBy { get; set; } = "";

        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}