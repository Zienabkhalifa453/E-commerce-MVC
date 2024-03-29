using E_commerce.Repository;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class Product:ISoftDeletable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public String Image_Url { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<Cart>? carts { get; set; }
        public ICollection<WishList>? wishLists { get; set; }
        public ICollection<OrderItem>? orderItems { get; set; }
        [ForeignKey("category")]
        public int Category_Id { get; set; }
        public Category category { get; set; }
    }
}