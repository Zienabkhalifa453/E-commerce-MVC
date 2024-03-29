using E_commerce_MVC.interfaces;
using E_commerce_MVC.Models;
using Microsoft.AspNetCore.Identity;


namespace E_commerce.Models
{
    public class ApplicationUser : IdentityUser,ISoftDeletable
    {
        public string Address { get; set; }
        public bool IsDeleted { get; set; }
        public List<Order>? orders { get; set; }
        public List<Payment>? payments { get; set; }
        public List<Cart>? carts { get; set; }
        public List<WishList>? wishLists { get; set; }
        public List<Shipment>? shipments { get; set; }

        public List<Comments>? comments { get; set; }


    }
}
