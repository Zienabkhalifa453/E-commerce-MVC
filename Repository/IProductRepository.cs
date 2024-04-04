using E_commerce.Models;
using E_commerce.Repository;

namespace E_commerce_MVC.Repository
{
    public interface IProductRepository : IRepository<Product>
    {
        public List<Product> GetProductsByCatgoryId(int CategoryId);
        public List<string> GetProductNamesByCatId(int CategoryId);
        public List<int> GetProductIDsByCatId(int CategoryId);
        public List<string> GetProductImagesByCatId(int CategoryId);
        public List<double> GetProductPricesByCatId(int CategoryId);
        public List<Product> GetLatestProduct();

    }
}
