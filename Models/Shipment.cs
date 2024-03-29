using E_commerce_MVC.interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class Shipment:ISoftDeletable
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Country { get; set; }
        public string Zip_Code { get; set; }
        public bool IsDeleted { get; set; } = false;
        [ForeignKey("customer")]
        public string Customer_Id { get; set; }
        public ApplicationUser customer { get; set; }
        public ICollection<Order>? orders { get; set; }

    }
}