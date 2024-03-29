using E_commerce.Repository;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class WishList:ISoftDeletable
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; } = false;
        [ForeignKey("customer")]
        public int Customer_Id { get; set; }
        public customer customer { get; set; }
        [ForeignKey("product")]
        public int Product_Id { get; set; }
        public Product product { get; set; }
    }
}