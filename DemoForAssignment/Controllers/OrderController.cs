using DemoForAssignment.Services.Interfaces;
using DemoForAssignment.Services.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoForAssignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] OrderVM request, CancellationToken ct)
        {
            var orderId = await _orderService.AddAsync(request, ct);
            return Created($"/api/orders/{orderId}", new { OrderId = orderId });
        }
    }
}
