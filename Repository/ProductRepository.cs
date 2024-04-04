using E_commerce.Models;
using E_commerce.Repository;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_MVC.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(Context context) : base(context)
        {
        }

        public List<Product> GetProductsByCatgoryId(int CategoryId)
        {
            return context.Products.Where(p => p.Category_Id == CategoryId).ToList();
        }

        public List<string> GetProductNamesByCatId(int CategoryId)
        {
            return context.Products.Where(p => p.Category_Id == CategoryId).Select(p => p.Name).ToList();
        }
        
        public List<int> GetProductIDsByCatId(int CategoryId)
        {
            return context.Products.Where(p => p.Category_Id == CategoryId).Select(p => p.Id).ToList();
        }
           
        public List<string> GetProductImagesByCatId(int CategoryId)
        {
            return context.Products.Where(p => p.Category_Id == CategoryId).Select(p => p.Image_Url).ToList();
        }
 
        public List<double> GetProductPricesByCatId(int CategoryId)
        {
            return context.Products.Where(p => p.Category_Id == CategoryId).Select(p => p.Price).ToList();
        }

        //Get latest product in each category
        public List<Product> GetLatestProduct()
        {
            var latestProductsInCategories = context.Products
                 .GroupBy(p => p.Category_Id)
                 .Select(g => g.OrderByDescending(p => p.Id).FirstOrDefault())
                 .ToList();

            return latestProductsInCategories;
        }

    }
}
