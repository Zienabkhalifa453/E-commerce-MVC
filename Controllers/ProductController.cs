using E_commerce.Models;
using E_commerce_MVC.Repository;
using E_commerce_MVC.viewModels;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_MVC.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository ProductRepository;
        private readonly ICategoryRepository CategoryRepository;

        public ProductController(IProductRepository ProductRepository ,ICategoryRepository CategoryRepository)
        {
            this.ProductRepository = ProductRepository;
            this.CategoryRepository = CategoryRepository;
        }


        public IActionResult Index()
        {
            return View();
        } 

        //dina controllers

        public IActionResult GetAllProducts()
        {
            List<Product> products = (List<Product>)ProductRepository.GetAll();
            return View("GetAllProducts");
        }

        public IActionResult GetProductsByCategoryId(int CategoryId)
        {
            List<string> productNames = ProductRepository.GetProductNamesByCatId(CategoryId);
            List<string> productImages = ProductRepository.GetProductImagesByCatId(CategoryId);
            List<double> productPrices = ProductRepository.GetProductPricesByCatId(CategoryId);
            List<int> productIds = ProductRepository.GetProductIDsByCatId(CategoryId);

            string CategoryName = CategoryRepository.GetName(CategoryId);

            ProductPartViewModel productPartViewModel = new ProductPartViewModel()
            {
                CategoryId = CategoryId,
                CategoryName = CategoryName,
                Price = productPrices,
                ProductNames = productNames,
                ProductsId = productIds
            };

            return View("GetProductsByCategoryId" , productPartViewModel);
        }

        public IActionResult AddToCart(int ProductId)
        {
            Product product = ProductRepository.Get(p => p.Id == ProductId);
            return View("ShoppingCart",product);
        }

        
        public IActionResult AddToWishList(int ProductId)
        {
            Product product = ProductRepository.Get(p => p.Id == ProductId);
            return View("wishingList",product);
        }


       
    }
}
