using System.ComponentModel.DataAnnotations;

namespace E_Commerce.Entities
{
    public class Order
    {
        public int OrderId{ get; set; }
        public DateTime OrderDate { get; set; }
        [Required]
        public int UserId { get; set; }
        [Required]
        public decimal TotalAmount{ get; set; }
        [Required]
        public User? User{ get; set; }

        public ICollection<OrderItem>OrderItems{ get; set; }
    }
}
