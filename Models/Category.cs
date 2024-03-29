using E_commerce.Repository;

namespace E_commerce.Models
{
    public class Category:ISoftDeletable
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; } = false;
        public ICollection<Product>? products { get; set; }

    }
}