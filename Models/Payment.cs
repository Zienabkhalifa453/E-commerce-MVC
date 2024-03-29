using E_commerce.Repository;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce.Models
{
    public class Payment:ISoftDeletable
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Method { get; set; }
        public Double Amount { get; set; }
        public bool IsDeleted { get; set; } = false;

        [ForeignKey("customer")]
        public int Customer_Id { get; set; }
        public customer customer { get; set; }
        public ICollection<Order>? orders { get; set; }
    }
}