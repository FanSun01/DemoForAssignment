using DemoForAssignment.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoForAssignment.Services.Interfaces
{
    public interface IOrderService
    {
        Task<Guid> AddAsync(OrderVM order, CancellationToken ct);
    }
}
