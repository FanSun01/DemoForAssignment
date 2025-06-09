using AutoMapper;
using DemoForAssignment.Data;
using DemoForAssignment.Models;
using DemoForAssignment.Services.Models;
using DemoForAssignment.Services.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Moq;

namespace DemoForAssignment.Test
{
    public class OrderServiceIntegrationTests : IDisposable
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;
        private readonly OrderService _service;

        public OrderServiceIntegrationTests()
        {
            var options = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer("Server=localhost\\SQLEXPRESS;Initial Catalog=demoDb;Integrated Security=SSPI;TrustServerCertificate=True;", opts => opts.EnableRetryOnFailure())
                .Options;

            _context = new AppDbContext(options);
            _mapper = new Mapper(new MapperConfiguration(x =>
            {
                x.CreateMap<OrderItem, OrderItemVM>().ReverseMap();
                x.CreateMap<Order, OrderVM>().ReverseMap();
            }));
            _service = new OrderService(_context, _mapper, new Mock<ILogger<OrderService>>().Object);
        }

        [Fact]
        public async Task CreateOrderAsync_ShouldReturnOrderId()
        {
            // Arrange
            var request = new OrderVM { 
                CustomerName = "John Doe",
                CreatedAt = DateTime.UtcNow, 
                Items = new List<OrderItemVM> { new() { ProductId = "string", Quantity = 2 } }
            };

            // Act
            var result = await _service.AddAsync(request, CancellationToken.None);

            // Assert
            var orderFromDb = await _context.Orders.FirstOrDefaultAsync(o => o.Id == result);
            Assert.NotNull(orderFromDb);
            Assert.Equal(request.CustomerName, orderFromDb.CustomerName);
        }


        public void Dispose()
        {
            _context.Dispose();
        }
    }
}