using E_commerce_MVC.interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class Order:ISoftDeletable
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Double TotalPrice { get; set; }
        public bool IsDeleted { get; set; } = false;

        [ForeignKey("payment")]
        public int Payment_Id { get; set; }
        public Payment payment { get; set; }
        [ForeignKey("shipment")]
        public int Shipment_Id { get; set; }
        public Shipment shipment { get; set; }
        [ForeignKey("customer")]
        public string Customer_Id { get; set; }
        public ApplicationUser customer { get; set; }
        public ICollection<OrderItem>? orderItems { get; set; }

    }
}