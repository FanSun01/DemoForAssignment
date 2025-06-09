using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoForAssignment.Services.Models
{
    public class OrderVM
    {
        public string CustomerName { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; }
        public ICollection<OrderItemVM> Items { get; set; } = new List<OrderItemVM>();
    }
}
