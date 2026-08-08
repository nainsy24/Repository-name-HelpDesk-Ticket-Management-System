using HelpDesk.Api.Controllers;
using HelpDesk.Api.Models;
using HelpDesk.Api.Repositories;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit;

namespace HelpDesk.Tests.Controllers
{
    public class TicketControllerTests
    {
        private readonly Mock<ITicketRepository> _mockRepository;
        private readonly TicketController _controller;

        public TicketControllerTests()
        {
            _mockRepository = new Mock<ITicketRepository>();
            _controller = new TicketController(_mockRepository.Object);
        }

        [Fact]
        public async Task GetAllTickets_ReturnsOkResult_WhenTicketsExist()
        {
            // Arrange
            var tickets = new List<Ticket>
            {
                new Ticket
                {
                    Id = 1,
                    Title = "Printer",
                    Description = "Paper Jam",
                    Priority = "High",
                    Status = "Open",
                    RaisedBy = "John"
                }
            };

            _mockRepository
                .Setup(x => x.GetAllAsync())
                .ReturnsAsync(tickets);

            // Act
            var result = await _controller.GetAllTickets();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var data = Assert.IsAssignableFrom<IEnumerable<Ticket>>(okResult.Value);

            Assert.Single(data);
        }

        [Fact]
        public async Task GetTicketById_ReturnsOkResult_WhenTicketExists()
        {
            // Arrange
            var ticket = new Ticket
            {
                Id = 1,
                Title = "Printer",
                Description = "Paper Jam",
                Priority = "High",
                Status = "Open",
                RaisedBy = "John"
            };

            _mockRepository
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync(ticket);

            // Act
            var result = await _controller.GetTicketById(1);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var data = Assert.IsType<Ticket>(okResult.Value);

            Assert.Equal(1, data.Id);
        }

        [Fact]
        public async Task GetTicketById_ReturnsNotFound_WhenTicketDoesNotExist()
        {
            // Arrange
            _mockRepository
                .Setup(x => x.GetByIdAsync(1))
                .ReturnsAsync((Ticket?)null);

            // Act
            var result = await _controller.GetTicketById(1);

            // Assert
            Assert.IsType<NotFoundResult>(result.Result);
        }

        [Fact]
        public async Task CreateTicket_ReturnsCreated_WhenTicketIsCreatedSuccessfully()
        {
            // Arrange
            var ticket = new Ticket
            {
                Id = 1,
                Title = "Printer",
                Description = "Paper Jam",
                Priority = "High",
                Status = "Open",
                RaisedBy = "John"
            };

            _mockRepository
                .Setup(x => x.AddAsync(It.IsAny<Ticket>()))
                .ReturnsAsync(ticket);

            // Act
            var result = await _controller.CreateTicket(ticket);

            // Assert
            Assert.IsType<CreatedAtActionResult>(result.Result);
        }

        [Fact]
        public async Task CreateTicket_ReturnsBadRequest_WhenModelStateIsInvalid()
        {
            // Arrange
            _controller.ModelState.AddModelError("Title", "Required");

            var ticket = new Ticket();

            // Act
            var result = await _controller.CreateTicket(ticket);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result.Result);
        }

        [Fact]
        public async Task GetTicketsByStatus_ReturnsOkResult_WhenMatchingTicketsExist()
        {
            // Arrange
            var tickets = new List<Ticket>
            {
                new Ticket
                {
                    Id = 1,
                    Title = "Printer",
                    Description = "Paper Jam",
                    Priority = "High",
                    Status = "Open",
                    RaisedBy = "John"
                }
            };

            _mockRepository
                .Setup(x => x.GetByStatusAsync("Open"))
                .ReturnsAsync(tickets);

            // Act
            var result = await _controller.GetTicketsByStatus("Open");

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var data = Assert.IsAssignableFrom<IEnumerable<Ticket>>(okResult.Value);

            Assert.Single(data);
        }
    }
}
