using System.ComponentModel.DataAnnotations;

namespace ProducerApplication.Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }

        public string ProductName { get; set; }

        public decimal Price { get; set; }

        public int Quantity { get; set; }
    }
}
