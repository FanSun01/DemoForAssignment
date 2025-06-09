using AutoMapper;
using DemoForAssignment.Data;
using DemoForAssignment.Models;
using DemoForAssignment.Services.Interfaces;
using DemoForAssignment.Services.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoForAssignment.Services.Services
{
    public class OrderService : BaseService, IOrderService
    {
        private ILogger<OrderService> _logger;
        public OrderService(AppDbContext context, IMapper mapper, ILogger<OrderService> logger) : base(context, mapper)
        {
            _logger = logger;
        }

        public async Task<Guid> AddAsync(OrderVM order, CancellationToken ct)
        {
            try
            {
                var entity = _mapper.Map<Order>(order);
                await _context.Orders.AddAsync(entity, ct);
                await _context.SaveChangesAsync(ct);
                return entity.Id;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Failed to create order.");
                throw;
            }

        }

    }
}
