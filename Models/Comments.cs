using E_commerce.Models;
using E_commerce_MVC.interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace E_commerce_MVC.Models
{
    public class Comments : ISoftDeletable
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int Rating { get; set; }

        [ForeignKey("product")]
        public int ProductId { get; set; }
        public Product product { get; set; }


        public ApplicationUser applicationUser { get; set; }
        [ForeignKey("applicationUser")]
        public string userId { get; set; }

        public bool IsDeleted { set; get; }
    }
}
