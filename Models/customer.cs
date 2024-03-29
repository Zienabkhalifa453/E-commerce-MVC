using E_commerce.Repository;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class customer:ISoftDeletable
    {

        public int id { get; set; }

 
        public string ApplicationUserId { get; set; }

    
        [ForeignKey("ApplicationUserId")]
        public ApplicationUser ApplicationUser { get; set; }


        public bool IsDeleted { get; set; } = false;
        public ICollection<Order>? orders { get; set; }
        public ICollection<Payment>? payments { get; set; }
        public ICollection<Cart>? carts { get; set; }
        public ICollection<WishList>? wishLists { get; set; }
        public ICollection<Shipment>? shipments { get; set; }
    }
}
