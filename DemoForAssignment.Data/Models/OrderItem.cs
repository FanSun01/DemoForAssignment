using System.ComponentModel.DataAnnotations.Schema;

namespace DemoForAssignment.Models
{
    public class OrderItem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid OrderItemId { get; set; }
        public string ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
