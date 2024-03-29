using E_commerce_MVC.interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class OrderItem:ISoftDeletable
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public bool IsDeleted { get; set; } = false;

        [ForeignKey("product")]
        public int Product_Id { get; set; }
        public Product product { get; set; }
        [ForeignKey("order")]
        public int Order_Id { get; set; }
        public Order order { get; set; }

    }
}